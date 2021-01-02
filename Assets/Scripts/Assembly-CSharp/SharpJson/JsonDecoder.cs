using System.Collections.Generic;

namespace SharpJson
{
    public class JsonDecoder
	{
		public JsonDecoder()
		{
			this.errorMessage = null;
			this.parseNumbersAsFloat = false;
		}

		public string errorMessage { get; private set; }

		public bool parseNumbersAsFloat { get; set; }

		public object Decode(string text)
		{
			this.errorMessage = null;
			this.lexer = new Lexer(text);
			this.lexer.parseNumbersAsFloat = this.parseNumbersAsFloat;
			return this.ParseValue();
		}

		public static object DecodeText(string text)
		{
			JsonDecoder jsonDecoder = new JsonDecoder();
			return jsonDecoder.Decode(text);
		}

		private IDictionary<string, object> ParseObject()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			this.lexer.NextToken();
			for (;;)
			{
				Lexer.Token token = this.lexer.LookAhead();
				if (token == Lexer.Token.None)
				{
					break;
				}
				if (token != Lexer.Token.Comma)
				{
					if (token == Lexer.Token.CurlyClose)
					{
						goto IL_56;
					}
					string key = this.EvalLexer(this.lexer.ParseString());
					if (this.errorMessage != null)
					{
						goto Block_4;
					}
					token = this.lexer.NextToken();
					if (token != Lexer.Token.Colon)
					{
						goto Block_5;
					}
					object value = this.ParseValue();
					if (this.errorMessage != null)
					{
						goto Block_6;
					}
					dictionary[key] = value;
				}
				else
				{
					this.lexer.NextToken();
				}
			}
			this.TriggerError("Invalid token");
			return null;
			IL_56:
			this.lexer.NextToken();
			return dictionary;
			Block_4:
			return null;
			Block_5:
			this.TriggerError("Invalid token; expected ':'");
			return null;
			Block_6:
			return null;
		}

		private IList<object> ParseArray()
		{
			List<object> list = new List<object>();
			this.lexer.NextToken();
			for (;;)
			{
				Lexer.Token token = this.lexer.LookAhead();
				if (token == Lexer.Token.None)
				{
					break;
				}
				if (token != Lexer.Token.Comma)
				{
					if (token == Lexer.Token.SquaredClose)
					{
						goto IL_56;
					}
					object item = this.ParseValue();
					if (this.errorMessage != null)
					{
						goto Block_4;
					}
					list.Add(item);
				}
				else
				{
					this.lexer.NextToken();
				}
			}
			this.TriggerError("Invalid token");
			return null;
			IL_56:
			this.lexer.NextToken();
			return list;
			Block_4:
			return null;
		}

		private object ParseValue()
		{
			switch (this.lexer.LookAhead())
			{
			case Lexer.Token.Null:
				this.lexer.NextToken();
				return null;
			case Lexer.Token.True:
				this.lexer.NextToken();
				return true;
			case Lexer.Token.False:
				this.lexer.NextToken();
				return false;
			case Lexer.Token.String:
				return this.EvalLexer(this.lexer.ParseString());
			case Lexer.Token.Number:
				if (this.parseNumbersAsFloat)
				{
					return this.EvalLexer(this.lexer.ParseFloatNumber());
				}
				return this.EvalLexer(this.lexer.ParseDoubleNumber());
			case Lexer.Token.CurlyOpen:
				return this.ParseObject();
			case Lexer.Token.SquaredOpen:
				return this.ParseArray();
			}
			this.TriggerError("Unable to parse value");
			return null;
		}

		private void TriggerError(string message)
		{
			this.errorMessage = string.Format("Error: '{0}' at line {1}", message, this.lexer.lineNumber);
		}

		private T EvalLexer<T>(T value)
		{
			if (this.lexer.hasError)
			{
				this.TriggerError("Lexical error ocurred");
			}
			return value;
		}

		private Lexer lexer;
	}
}
