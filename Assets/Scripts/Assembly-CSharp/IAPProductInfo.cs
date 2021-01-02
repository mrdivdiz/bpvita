using System.Collections.Generic;
using System.Text;

public class IAPProductInfo
{
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (this.clientData != null)
		{
			int num = 0;
			stringBuilder.Append("{ ");
			foreach (KeyValuePair<string, string> keyValuePair in this.clientData)
			{
				if (num > 0)
				{
					stringBuilder.Append(", ");
				}
				num++;
				stringBuilder.Append(string.Format("{0}:{1}", keyValuePair.Key, keyValuePair.Value));
			}
			stringBuilder.Append(" }");
		}
		else
		{
			stringBuilder.Append("NULL");
		}
		return string.Format("[IAPProductInfo] {0}, {1}, {2}, {3}", new object[]
		{
			this.productId,
			this.title,
			stringBuilder.ToString()
		});
	}

	public string productId;

	public string title;

	public string formattedPrice;

	public string unformattedPrice;

	public Dictionary<string, string> clientData;
}
