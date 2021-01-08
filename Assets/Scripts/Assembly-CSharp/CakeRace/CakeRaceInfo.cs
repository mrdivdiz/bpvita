using System;
using UnityEngine;

namespace CakeRace
{
	[Serializable]
	public struct CakeRaceInfo
	{
		public CakeRaceInfo(int episodeIndex, int levelIndex, int trackIndex)
		{
			this.m_episodeIndex = episodeIndex;
			this.m_levelIndex = levelIndex;
			this.m_identifier = string.Empty;
			this.m_trackIndex = trackIndex;
			this.m_timeLimit = 10;
			this.m_cakeLocations = new ObjectLocation[0];
			this.m_customParts = new LevelManager.PartCount[0];
			this.m_startInfo = default(StartInfo);
			this.m_jsonReplay = string.Empty;
			this.m_cameraLimits = new LevelManager.CameraLimits();
			this.m_props = new ObjectLocation[0];
			this.m_tutorialBookPrefab = null;
			this.m_gridCellPrefab = null;
			this.m_tag = CakeRaceInfo.Tag.Undefined;
			this.m_cakeZoomLevels = new float[0];
		}

		public CakeRaceInfo(string identifier, int trackIndex)
		{
			this.m_episodeIndex = -1;
			this.m_levelIndex = -1;
			this.m_identifier = identifier;
			this.m_trackIndex = trackIndex;
			this.m_timeLimit = 10;
			this.m_cakeLocations = new ObjectLocation[0];
			this.m_customParts = new LevelManager.PartCount[0];
			this.m_startInfo = default(StartInfo);
			this.m_jsonReplay = string.Empty;
			this.m_cameraLimits = new LevelManager.CameraLimits();
			this.m_props = new ObjectLocation[0];
			this.m_tutorialBookPrefab = null;
			this.m_gridCellPrefab = null;
			this.m_tag = CakeRaceInfo.Tag.Undefined;
			this.m_cakeZoomLevels = new float[0];
		}

		public int EpisodeIndex
		{
			get
			{
				return this.m_episodeIndex;
			}
		}

		public int LevelIndex
		{
			get
			{
				return this.m_levelIndex;
			}
		}

		public int TrackIndex
		{
			get
			{
				return this.m_trackIndex;
			}
		}

		public string Identifier
		{
			get
			{
				return this.m_identifier;
			}
		}

		public string UniqueIdentifier
		{
			get
			{
				return (!this.RegularLevel) ? string.Format("{0}_{1}", this.Identifier, this.TrackIndex) : string.Format("{0}-{1}_{2}", this.EpisodeIndex, this.LevelIndex, this.TrackIndex);
			}
		}

		public int TimeLimit
		{
			get
			{
				return this.m_timeLimit;
			}
		}

		public ObjectLocation[] CakeLocations
		{
			get
			{
				return this.m_cakeLocations;
			}
		}

		public LevelManager.PartCount[] CustomParts
		{
			get
			{
				return this.m_customParts;
			}
		}

		public StartInfo Start
		{
			get
			{
				return this.m_startInfo;
			}
		}

		public string Replay
		{
			get
			{
				return this.m_jsonReplay;
			}
		}

		public bool RegularLevel
		{
			get
			{
				return string.IsNullOrEmpty(this.m_identifier);
			}
		}

		public bool SpecialLevel
		{
			get
			{
				return !string.IsNullOrEmpty(this.m_identifier);
			}
		}

		public LevelManager.CameraLimits CameraLimits
		{
			get
			{
				return this.m_cameraLimits;
			}
		}

		public ObjectLocation[] Props
		{
			get
			{
				return this.m_props;
			}
		}

		public GameObject TutorialBookPrefab
		{
			get
			{
				return this.m_tutorialBookPrefab;
			}
		}

		public GameObject GridCellPrefab
		{
			get
			{
				return this.m_gridCellPrefab;
			}
		}

		public Tag InfoTag
		{
			get
			{
				return this.m_tag;
			}
		}

		public float[] CakeZoomLevels
		{
			get
			{
				return this.m_cakeZoomLevels;
			}
		}

		public static bool operator ==(CakeRaceInfo a, CakeRaceInfo b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(CakeRaceInfo a, CakeRaceInfo b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is CakeRaceInfo))
			{
				return false;
			}
			CakeRaceInfo other = (CakeRaceInfo)obj;
			return this.Equals(other);
		}

		public bool Equals(CakeRaceInfo other)
		{
			return this.m_episodeIndex == other.m_episodeIndex && this.m_levelIndex == other.m_levelIndex && this.m_identifier == other.m_identifier && this.m_trackIndex == other.m_trackIndex;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num *= this.m_episodeIndex * 23;
			num *= this.m_levelIndex * 79;
			num *= this.m_trackIndex * 773;
			return num * this.m_identifier.GetHashCode();
		}

		private const int DEFAULT_TIME_LIMIT = 10;

		[SerializeField]
		private int m_episodeIndex;

		[SerializeField]
		private int m_levelIndex;

		[SerializeField]
		private string m_identifier;

		[SerializeField]
		private int m_trackIndex;

		[SerializeField]
		private int m_timeLimit;

		[SerializeField]
		private ObjectLocation[] m_cakeLocations;

		[SerializeField]
		private LevelManager.PartCount[] m_customParts;

		[SerializeField]
		private StartInfo m_startInfo;

		[SerializeField]
		private string m_jsonReplay;

		[SerializeField]
		private LevelManager.CameraLimits m_cameraLimits;

		[SerializeField]
		private ObjectLocation[] m_props;

		[SerializeField]
		private GameObject m_tutorialBookPrefab;

		[SerializeField]
		private GameObject m_gridCellPrefab;

		[SerializeField]
		private Tag m_tag;

		[SerializeField]
		private float[] m_cakeZoomLevels;

		public enum Tag
		{
			Undefined = -1,
			Easy,
			Normal,
			Hard,
			Locked
		}
	}
}
