using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class FileSet
	{
		public int ByteCount;

		public string Checksum;

		public string FileName;

		public OperationTypes? Operation;

		public int? PreviousByteCount;

		public string PreviousChecksum;

		public string PreviousStoragePath;

		public string StoragePath;
	}
}
