using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class EventSender
{
	public bool HasEvent()
	{
		return this.m_event.EventType != null;
	}

	public string EventName
	{
		get
		{
			return this.m_event.m_eventTypeName;
		}
	}

	public void SetEvent(string eventName, List<Parameter> parameters)
	{
		this.m_event.m_eventTypeName = eventName;
		this.m_parameters = parameters;
	}

	public List<Parameter> GetParameters()
	{
		List<Parameter> list = new List<Parameter>();
		Type eventType = this.m_event.EventType;
		if (eventType != null)
		{
			ConstructorInfo[] constructors = eventType.GetConstructors();
			ConstructorInfo[] array = constructors;
			int num = 0;
			if (num < array.Length)
			{
				ConstructorInfo constructorInfo = array[num];
				ParameterInfo[] parameters = constructorInfo.GetParameters();
				foreach (ParameterInfo parameterInfo in parameters)
				{
					list.Add(new Parameter(parameterInfo.ParameterType, parameterInfo.ParameterType.FullName, parameterInfo.Name));
				}
			}
			if (this.m_parameters == null)
			{
				this.m_parameters = list;
			}
			else
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (j < this.m_parameters.Count)
					{
						this.m_parameters[j].typeName = list[j].typeName;
						this.m_parameters[j].type = list[j].type;
						this.m_parameters[j].name = list[j].name;
					}
					else
					{
						this.m_parameters.Add(list[j]);
					}
				}
				for (int k = list.Count; k < this.m_parameters.Count; k++)
				{
					this.m_parameters[k].type = null;
				}
			}
			return this.m_parameters;
		}
		return new List<Parameter>();
	}

	public object[] CreateParameterObjects()
	{
		List<Parameter> parameters = this.GetParameters();
		int num = 0;
		for (int i = 0; i < parameters.Count; i++)
		{
			if (parameters[i].type != null)
			{
				num++;
			}
		}
		object[] array = new object[num];
		for (int j = 0; j < num; j++)
		{
            Parameter parameter = parameters[j];
			if (parameter.type.IsSubclassOf(typeof(Enum)))
			{
				array[j] = Enum.Parse(parameter.type, parameter.stringValue);
			}
			else if (parameter.type == typeof(int))
			{
				array[j] = parameter.intValue;
			}
			else if (parameter.type == typeof(bool))
			{
				array[j] = parameter.boolValue;
			}
			else if (parameter.type == typeof(string))
			{
				array[j] = parameter.stringValue;
			}
		}
		return array;
	}

	public void PrepareSend()
	{
		Type eventType = this.m_event.EventType;
		if (eventType != null)
		{
			MethodInfo method = typeof(EventManager).GetMethod("Send");
			this.m_genericSendMethod = method.MakeGenericMethod(new Type[]
			{
				eventType
			});
			EventManager.Event @event = (EventManager.Event)Activator.CreateInstance(eventType, this.CreateParameterObjects());
			this.m_sendParameters = new object[]
			{
				@event
			};
		}
	}

	public void Send()
	{
		if (this.m_genericSendMethod == null)
		{
			if (this.m_event.EventType == null)
			{
				return;
			}
			this.PrepareSend();
		}
		this.PrepareSend();
		this.m_genericSendMethod.Invoke(null, this.m_sendParameters);
	}

	[SerializeField]
	private EventProperty m_event = new EventProperty();

	[SerializeField]
	private List<Parameter> m_parameters;

	private MethodInfo m_genericSendMethod;

	private object[] m_sendParameters;

	[Serializable]
	public class Parameter
	{
		public Parameter(Type type, string typeName, string name)
		{
			this.type = type;
			this.typeName = typeName;
			this.name = name;
			this.stringValue = string.Empty;
		}

		public Type type;

		public string typeName;

		public string name;

		public string stringValue;

		public int intValue;

		public bool boolValue;
	}
}
