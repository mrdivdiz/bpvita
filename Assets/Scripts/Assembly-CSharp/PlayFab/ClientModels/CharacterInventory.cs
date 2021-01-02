using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CharacterInventory
	{
		public string CharacterId;

		public List<ItemInstance> Inventory;
	}
}
