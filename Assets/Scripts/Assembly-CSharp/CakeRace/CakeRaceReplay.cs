using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CakeRace
{
	public class CakeRaceReplay
	{
		public CakeRaceReplay(string uniqueIdentifier, string playerName, int playerLevel, bool kingsFavoriteUsed, Dictionary<int, int> collectTimes)
		{
			this.uniqueIdentifier = uniqueIdentifier;
			this.playerName = playerName;
			this.playerLevel = playerLevel;
			this.kingsFavoriteUsed = kingsFavoriteUsed;
			this.collectTimes = collectTimes;
			this.IsValid = true;
		}

		public CakeRaceReplay(string jsonString)
		{
			try
			{
				bool flag = false;
				Hashtable hashtable = MiniJSON.jsonDecode(jsonString) as Hashtable;
				if (hashtable != null)
				{
					if (hashtable.Contains("uniqueIdentifier"))
					{
						this.uniqueIdentifier = (string)hashtable["uniqueIdentifier"];
					}
					else
					{
						flag = true;
					}
					if (hashtable.Contains("playerName"))
					{
						this.playerName = (string)hashtable["playerName"];
					}
					else
					{
						flag = true;
					}
					if (hashtable.Contains("playerLevel"))
					{
						int num;
						if (int.TryParse((string)hashtable["playerLevel"], out num))
						{
							this.playerLevel = num;
						}
					}
					else
					{
						flag = true;
					}
					int num2;
					if (hashtable.Contains("kingsFavorite") && int.TryParse((string)hashtable["kingsFavorite"], out num2))
					{
						this.kingsFavoriteUsed = (num2 != 0);
					}
					this.collectTimes = new Dictionary<int, int>();
					if (hashtable.Contains("collectTimes") && hashtable["collectTimes"] is Hashtable)
					{
						IDictionaryEnumerator enumerator = ((Hashtable)hashtable["collectTimes"]).GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
								int key;
								int value;
								if (int.TryParse((string)dictionaryEntry.Key, out key) && int.TryParse((string)dictionaryEntry.Value, out value))
								{
									this.collectTimes.Add(key, value);
								}
							}
						}
						finally
						{
							IDisposable disposable;
							if ((disposable = (enumerator as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				this.IsValid = !flag;
			}
			catch
			{
				this.IsValid = false;
			}
		}

		public string UniqueIdentifier
		{
			get
			{
				return this.uniqueIdentifier;
			}
		}

		public string PlayerName
		{
			get
			{
				return this.playerName;
			}
		}

		public int PlayerLevel
		{
			get
			{
				return this.playerLevel;
			}
		}

		public bool HasKingsFavoritePart
		{
			get
			{
				return this.kingsFavoriteUsed;
			}
		}

		public bool IsValid { get; private set; }

		public int CakesCollected
		{
			get
			{
                int count = 0;
                foreach (KeyValuePair<int, int> value in this.collectTimes)
                {
                    if (value.Key >= 0)
                    {
                        count++;
                    }
                }
                return count;
			}
		}

		public void SetPlayerLevel(int level)
		{
			this.playerLevel = level;
		}

		public string GetPlayerName()
		{
			string result = "guest";
			if (!string.IsNullOrEmpty(this.playerName))
			{
				if (this.playerName.Contains("|"))
				{
					string[] array = this.PlayerName.Split(new char[]
					{
						'|'
					});
					result = array[0];
				}
				else
				{
					result = this.playerName;
				}
			}
			return result;
		}

		public int GetCollectedCakeCount()
		{
			if (this.collectTimes != null)
			{
				return this.collectTimes.Count;
			}
			return 0;
		}

		public int GetCakeCollectTime(int index)
		{
			if (this.collectTimes.ContainsKey(index))
			{
				return this.collectTimes[index];
			}
			return -1;
		}

		public Dictionary<int, int> GetAllCakeCollectedTimes()
		{
			return this.collectTimes;
		}

		public void SetPlayerName(string playerName)
		{
			this.playerName = playerName;
		}

		public void SetCollectedCake(int cakeIndex, int collectTime)
		{
			if (this.collectTimes == null)
			{
				this.collectTimes = new Dictionary<int, int>();
			}
			if (this.collectTimes.ContainsKey(cakeIndex))
			{
				this.collectTimes[cakeIndex] = collectTime;
			}
			else
			{
				this.collectTimes.Add(cakeIndex, collectTime);
			}
		}

		public void SetKingsFavoritePartUsed(bool newState = true)
		{
			this.kingsFavoriteUsed = newState;
		}

		public static int TotalScore(CakeRaceReplay replay)
		{
			if (replay == null)
			{
				return 0;
			}
			int num = 0;
			foreach (KeyValuePair<int, int> keyValuePair in replay.GetAllCakeCollectedTimes())
			{
				num += CakeRaceReplay.CalculateCakeScore(keyValuePair.Key < 0, keyValuePair.Value, replay.PlayerLevel, replay.HasKingsFavoritePart);
			}
			return num;
		}

		public static int CalculateCakeScore(bool explosion, int collectTime, int playerLevel, bool kingsFavoritePartUsed = false)
		{
			float num = Singleton<GameConfigurationManager>.Instance.GetValue<float>("cake_race", "kings_favorite_bonus");
			num = Mathf.Clamp(num, 1f, float.MaxValue);
			return Mathf.FloorToInt(((!explosion) ? 1f : 0.1f) * (float)collectTime * (float)Mathf.Clamp(playerLevel, 1, 30) * ((!kingsFavoritePartUsed) ? 1f : num));
		}

		public string TrimmedString()
		{
			int count = this.collectTimes.Count;
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			stringBuilder.Append("\"uniqueIdentifier\":\"" + this.uniqueIdentifier + "\",");
			stringBuilder.Append("\"playerName\":\"" + this.playerName + "\",");
			stringBuilder.Append("\"playerLevel\":\"" + this.playerLevel.ToString() + "\",");
			stringBuilder.Append("\"kingsFavorite\":\"" + ((!this.kingsFavoriteUsed) ? "0" : "1") + "\",");
			stringBuilder.Append("\"collectTimes\":{");
			foreach (KeyValuePair<int, int> keyValuePair in this.collectTimes)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"\"",
					keyValuePair.Key.ToString(),
					"\":\"",
					keyValuePair.Value.ToString(),
					"\""
				}));
				if (num < count - 1)
				{
					stringBuilder.Append(",");
				}
				num++;
			}
			stringBuilder.Append("}}");
			return stringBuilder.ToString();
		}

		public override string ToString()
		{
			int num = (this.collectTimes != null) ? this.collectTimes.Count : 0;
			int num2 = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("{");
			stringBuilder.AppendLine("    \"uniqueIdentifier\":\"" + this.uniqueIdentifier + "\",");
			stringBuilder.AppendLine("    \"playerName\":\"" + this.playerName + "\",");
			stringBuilder.AppendLine("    \"playerLevel\":\"" + this.playerLevel.ToString() + "\",");
			stringBuilder.AppendLine("    \"kingsFavorite\":\"" + ((!this.kingsFavoriteUsed) ? "0" : "1") + "\",");
			stringBuilder.AppendLine("    \"collectTimes\": {");
			foreach (KeyValuePair<int, int> keyValuePair in this.collectTimes)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"        \"",
					keyValuePair.Key.ToString(),
					"\":\"",
					keyValuePair.Value.ToString(),
					"\""
				}));
				if (num2 < num - 1)
				{
					stringBuilder.AppendLine(",");
				}
				num2++;
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("    }");
			stringBuilder.AppendLine("}");
			return stringBuilder.ToString();
		}

		private string uniqueIdentifier;

		private string playerName;

		private int playerLevel;

		private bool kingsFavoriteUsed;

		private bool isValid;

		private Dictionary<int, int> collectTimes;
	}
}
