using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class EntityFilesSetEventData : PlayStreamEventBase
	{
		public string EntityChain;

		public List<FileSet> Files;
	}
}
