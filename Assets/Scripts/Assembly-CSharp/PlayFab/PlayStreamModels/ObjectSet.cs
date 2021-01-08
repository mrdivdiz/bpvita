using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class ObjectSet
	{
		public object DataObject;

		public string Name;

		public OperationTypes? Operation;
	}
}
