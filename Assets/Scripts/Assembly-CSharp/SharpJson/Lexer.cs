using System;
using System.Globalization;
using System.Text;

namespace SharpJson
{
	internal class Lexer
	{
		public Lexer(string text)
		{
			this.Reset();
			this.json = text.ToCharArray();
			this.parseNumbersAsFloat = false;
		}

		public bool hasError
		{
			get
			{
				return !this.success;
			}
		}

		public int lineNumber { get; private set; }

		public bool parseNumbersAsFloat { get; set; }

		public void Reset()
		{
			this.index = 0;
			this.lineNumber = 1;
			this.success = true;
		}

		public string ParseString()
		{
			int num = 0;
			StringBuilder stringBuilder = null;
			this.SkipWhiteSpaces();
			char c = this.json[this.index++];
			bool flag = false;
			bool flag2 = false;
			while (!flag2 && !flag)
			{
				if (this.index == this.json.Length)
				{
					break;
				}
				c = this.json[this.index++];
				if (c == '"')
				{
					flag2 = true;
					break;
				}
				if (c == '\\')
				{
					if (this.index == this.json.Length)
					{
						break;
					}
					c = this.json[this.index++];
					switch (c)
					{
					case 'r':
						this.stringBuffer[num++] = '\r';
						break;
					default:
						if (c != '"')
						{
							if (c != '/')
							{
								if (c != '\\')
								{
									if (c != 'b')
									{
										if (c != 'f')
										{
											if (c == 'n')
											{
												this.stringBuffer[num++] = '\n';
											}
										}
										else
										{
											this.stringBuffer[num++] = '\f';
										}
									}
									else
									{
										this.stringBuffer[num++] = '\b';
									}
								}
								else
								{
									this.stringBuffer[num++] = '\\';
								}
							}
							else
							{
								this.stringBuffer[num++] = '/';
							}
						}
						else
						{
							this.stringBuffer[num++] = '"';
						}
						break;
					case 't':
						this.stringBuffer[num++] = '\t';
						break;
					case 'u':
					{
						int num2 = this.json.Length - this.index;
						if (num2 >= 4)
						{
							string value = new string(this.json, this.index, 4);
							this.stringBuffer[num++] = (char)Convert.ToInt32(value, 16);
							this.index += 4;
						}
						else
						{
							flag = true;
						}
						break;
					}
					}
				}
				else
				{
					this.stringBuffer[num++] = c;
				}
				if (num >= this.stringBuffer.Length)
				{
					if (stringBuilder == null)
					{
						stringBuilder = new StringBuilder();
					}
					stringBuilder.Append(this.stringBuffer, 0, num);
					num = 0;
				}
			}
			if (!flag2)
			{
				this.success = false;
				return null;
			}
			if (stringBuilder != null)
			{
				return stringBuilder.ToString();
			}
			return new string(this.stringBuffer, 0, num);
		}

		private string GetNumberString()
		{
			this.SkipWhiteSpaces();
			int lastIndexOfNumber = this.GetLastIndexOfNumber(this.index);
			int length = lastIndexOfNumber - this.index + 1;
			string result = new string(this.json, this.index, length);
			this.index = lastIndexOfNumber + 1;
			return result;
		}

		public float ParseFloatNumber()
		{
			string numberString = this.GetNumberString();
			float result;
			if (!float.TryParse(numberString, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				return 0f;
			}
			return result;
		}

		public double ParseDoubleNumber()
		{
			string numberString = this.GetNumberString();
			double result;
			if (!double.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				return 0.0;
			}
			return result;
		}

		private int GetLastIndexOfNumber(int index)
		{
			int i;
			for (i = index; i < this.json.Length; i++)
			{
				char c = this.json[i];
				if ((c < '0' || c > '9') && c != '+' && c != '-' && c != '.' && c != 'e' && c != 'E')
				{
					break;
				}
			}
			return i - 1;
		}

		private void SkipWhiteSpaces()
		{
			while (this.index < this.json.Length)
			{
				char c = this.json[this.index];
				if (c == '\n')
				{
					this.lineNumber++;
				}
				if (!char.IsWhiteSpace(this.json[this.index]))
				{
					break;
				}
				this.index++;
			}
		}

		public Token LookAhead()
		{
			this.SkipWhiteSpaces();
			int num = this.index;
			return Lexer.NextToken(this.json, ref num);
		}

		public Token NextToken()
		{
			this.SkipWhiteSpaces();
			return Lexer.NextToken(this.json, ref this.index);
		}

		private static Token NextToken(char[] json, ref int index)
		{
			if (index == json.Length)
			{
				return Lexer.Token.None;
			}
			char c = json[index++];
			switch (c)
			{
			case ',':
				return Lexer.Token.Comma;
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return Lexer.Token.Number;
			default:
				switch (c)
				{
				case '[':
					return Lexer.Token.SquaredOpen;
				default:
					switch (c)
					{
					case '{':
						return Lexer.Token.CurlyOpen;
					default:
					{
						if (c == '"')
						{
							return Lexer.Token.String;
						}
						index--;
						int num = json.Length - index;
						if (num >= 5 && json[index] == 'f' && json[index + 1] == 'a' && json[index + 2] == 'l' && json[index + 3] == 's' && json[index + 4] == 'e')
						{
							index += 5;
							return Lexer.Token.False;
						}
						if (num >= 4 && json[index] == 't' && json[index + 1] == 'r' && json[index + 2] == 'u' && json[index + 3] == 'e')
						{
							index += 4;
							return Lexer.Token.True;
						}
						if (num >= 4 && json[index] == 'n' && json[index + 1] == 'u' && json[index + 2] == 'l' && json[index + 3] == 'l')
						{
							index += 4;
							return Lexer.Token.Null;
						}
						return Lexer.Token.None;
					}
					case '}':
						return Lexer.Token.CurlyClose;
					}
					break;
				case ']':
					return Lexer.Token.SquaredClose;
				}
				break;
			case ':':
				return Lexer.Token.Colon;
			}
		}

		private char[] json;

		private int index;

		private bool success = true;

		private char[] stringBuffer = new char[4096];

		public enum Token
		{
			None,
			Null,
			True,
			False,
			Colon,
			Comma,
			String,
			Number,
			CurlyOpen,
			CurlyClose,
			SquaredOpen,
			SquaredClose
		}
	}
}
