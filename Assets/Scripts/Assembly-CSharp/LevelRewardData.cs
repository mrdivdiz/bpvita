using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelRewardData : MonoBehaviour
{
	public List<SandboxUnlock> sandboxUnlocks;

	[Serializable]
	public class SandboxUnlock
	{
		public string levelIdentifier;

		public string sandboxIdentifier;
	}
}
