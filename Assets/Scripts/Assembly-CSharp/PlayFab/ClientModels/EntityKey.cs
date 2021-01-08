using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class EntityKey
	{
		public string Id;

		public EntityTypes? Type;

		public string TypeString;
	}
}
