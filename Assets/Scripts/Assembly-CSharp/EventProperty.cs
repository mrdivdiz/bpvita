using System;

[Serializable]
public class EventProperty
{
	public Type EventType
	{
		get
		{
			if (this.m_eventTypeName != "None")
			{
				return Type.GetType(this.m_eventTypeName);
			}
			return null;
		}
	}

	public const string None = "None";

	public string m_eventTypeName = "None";
}
