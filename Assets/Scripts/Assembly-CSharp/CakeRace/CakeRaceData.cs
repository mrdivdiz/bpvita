using System;
using System.Collections.Generic;
using UnityEngine;

namespace CakeRace
{
	[Serializable]
	public class CakeRaceData : ScriptableObject
	{
		public bool GetInfo(int episodeIndex, int levelIndex, int trackIndex, out CakeRaceInfo? info)
		{
			info = null;
			for (int i = 0; i < this.data.Count; i++)
			{
				if (this.data[i].EpisodeIndex == episodeIndex && this.data[i].LevelIndex == levelIndex && this.data[i].TrackIndex == trackIndex && this.data[i].RegularLevel)
				{
					info = new CakeRaceInfo?(this.data[i]);
					return true;
				}
			}
			return false;
		}

		public bool GetInfo(string identifier, int trackIndex, out CakeRaceInfo? info)
		{
			info = null;
			if (string.IsNullOrEmpty(identifier))
			{
				return false;
			}
			for (int i = 0; i < this.data.Count; i++)
			{
				if (this.data[i].Identifier == identifier && this.data[i].TrackIndex == trackIndex && this.data[i].SpecialLevel)
				{
					info = new CakeRaceInfo?(this.data[i]);
					return true;
				}
			}
			return false;
		}

		public bool GetInfo(string uniqueIdentifier, out CakeRaceInfo? info)
		{
			info = null;
			if (string.IsNullOrEmpty(uniqueIdentifier) || !uniqueIdentifier.Contains("_") || !uniqueIdentifier.Contains("-"))
			{
				return false;
			}
			string[] array = uniqueIdentifier.Split(new char[]
			{
				'_'
			});
			string text = array[0];
			string[] array2 = text.Split(new char[]
			{
				'-'
			});
			int num = -1;
			int num2 = -1;
			int trackIndex = -1;
			if (array2.Length >= 2 && int.TryParse(array2[0], out num) && int.TryParse(array2[1], out num2))
			{
				text = string.Empty;
			}
			if (array.Length >= 2 && !int.TryParse(array[1], out trackIndex))
			{
				return false;
			}
			if (!string.IsNullOrEmpty(text))
			{
				return this.GetInfo(text, trackIndex, out info);
			}
			return num >= 0 && num2 >= 0 && this.GetInfo(num, num2, trackIndex, out info);
		}

		public int GetTrackCount(int episodeIndex, int levelIndex)
		{
			int num = 0;
			for (int i = 0; i < this.data.Count; i++)
			{
				if (this.data[i].EpisodeIndex == episodeIndex && this.data[i].LevelIndex == levelIndex && this.data[i].RegularLevel)
				{
					num++;
				}
			}
			return num;
		}

		public int GetTrackCount(string identifier)
		{
			int num = 0;
			if (string.IsNullOrEmpty(identifier))
			{
				return num;
			}
			for (int i = 0; i < this.data.Count; i++)
			{
				if (this.data[i].Identifier == identifier && this.data[i].SpecialLevel)
				{
					num++;
				}
			}
			return num;
		}

		private static CakeRaceData instance;

		[SerializeField]
		private List<CakeRaceInfo> data;
	}
}
