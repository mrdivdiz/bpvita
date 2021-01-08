using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class MethodCaller
{
	public GameObject TargetObject
	{
		get
		{
			return this.m_targetObject;
		}
	}

	public string TargetComponent
	{
		get
		{
			return this.m_targetComponent;
		}
	}

	public string MethodToInvoke
	{
		get
		{
			return this.m_methodToInvoke;
		}
	}

	public void Reset()
	{
		this.m_targetObject = null;
		this.m_targetComponent = null;
		this.m_methodToInvoke = null;
		this.m_parameters = null;
		this.m_methodInfo = null;
	}

	public void ResetTargetObject(GameObject obj)
	{
		this.m_targetObject = obj;
		this.m_targetComponent = null;
		this.m_methodToInvoke = null;
		this.m_parameters = null;
		this.m_methodInfo = null;
	}

	public void ResetComponent(string component)
	{
		this.m_targetComponent = component;
		this.m_methodToInvoke = null;
		this.m_parameters = null;
		this.m_methodInfo = null;
	}

	public void SetMethod(Component targetComponent, string method)
	{
		this.m_targetObject = targetComponent.gameObject;
		this.m_targetComponent = targetComponent.GetType().Name;
		this.m_methodToInvoke = method;
		this.PrepareCall();
	}

	public void SetMethod(Component targetComponent, string method, object parameter)
	{
		this.SetMethod(targetComponent, method);
		this.SetParameter(parameter);
	}

	public void SetMethod(Component targetComponent, string method, object[] parameters)
	{
		this.SetMethod(targetComponent, method);
		this.SetParameters(parameters);
	}

	public void SetParameter(object parameter)
	{
		List<Parameter> parameters = this.GetParameters();
		parameters[0].SetValue(parameter);
		this.PrepareCall();
	}

	public void SetParameters(object[] parameters)
	{
		List<Parameter> parameters2 = this.GetParameters();
		for (int i = 0; i < parameters.Length; i++)
		{
			parameters2[i].SetValue(parameters[i]);
		}
		this.PrepareCall();
	}

	public T GetParameter<T>(int index)
	{
		List<Parameter> parameters = this.GetParameters();
		if (index >= parameters.Count)
		{
			throw new Exception(string.Concat(new object[]
			{
				"MethodCaller: invalid parameter index ",
				index,
				" for ",
				this.m_methodToInvoke
			}));
		}
        Parameter parameter = parameters[index];
		if (parameter.type != typeof(T))
		{
			throw new Exception(string.Concat(new object[]
			{
				"MethodCaller: invalid parameter index ",
				index,
				" for ",
				this.m_methodToInvoke
			}));
		}
		if (parameter.type.IsSubclassOf(typeof(Enum)))
		{
			return (T)((object)Enum.Parse(parameter.type, parameter.stringValue));
		}
		if (parameter.type == typeof(int))
		{
			return (T)((object)parameter.intValue);
		}
		if (parameter.type == typeof(bool))
		{
			return (T)((object)parameter.boolValue);
		}
		if (parameter.type == typeof(string))
		{
			return (T)((object)parameter.stringValue);
		}
		throw new Exception("MethodCaller.GetParameter: type not implemented");
	}

	public List<Parameter> GetParametersForInspector()
	{
		return this.GetParameters();
	}

	private List<Parameter> GetParameters()
	{
		List<Parameter> list = new List<Parameter>();
		Component component = this.m_targetObject.GetComponent(this.m_targetComponent);
		MethodInfo method = component.GetType().GetMethod(this.m_methodToInvoke);
		if (method != null)
		{
			ParameterInfo[] parameters = method.GetParameters();
			foreach (ParameterInfo parameterInfo in parameters)
			{
				list.Add(new Parameter(parameterInfo.ParameterType, parameterInfo.ParameterType.FullName, parameterInfo.Name));
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

	public void PrepareCall()
	{
		if (this.m_targetObject && this.m_targetComponent != string.Empty && this.m_methodToInvoke != string.Empty)
		{
			this.m_component = this.m_targetObject.GetComponent(this.m_targetComponent);
			if (this.m_component)
			{
				this.m_methodInfo = this.m_component.GetType().GetMethod(this.m_methodToInvoke);
				if (this.m_methodInfo != null)
				{
					this.m_callParameters = this.CreateParameterObjects();
				}
			}
		}
	}

	public void Call()
	{
		if (this.m_methodInfo == null)
		{
			if (!this.m_targetObject)
			{
				return;
			}
			this.PrepareCall();
		}
		this.m_methodInfo.Invoke(this.m_component, this.m_callParameters);
	}

	[SerializeField]
	private GameObject m_targetObject;

	[SerializeField]
	private string m_targetComponent;

	[SerializeField]
	private string m_methodToInvoke;

	[SerializeField]
	private List<Parameter> m_parameters;

	private MethodInfo m_methodInfo;

	private Component m_component;

	private object[] m_callParameters;

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

		public void SetValue(object value)
		{
			if (value.GetType() == this.type)
			{
				if (this.type.IsSubclassOf(typeof(Enum)))
				{
					this.stringValue = value.ToString();
				}
				else if (this.type == typeof(int))
				{
					this.intValue = (int)value;
				}
				else if (this.type == typeof(bool))
				{
					this.boolValue = (bool)value;
				}
				else if (this.type == typeof(string))
				{
					this.stringValue = (string)value;
				}
			}
		}

		public Type type;

		public string typeName;

		public string name;

		public string stringValue;

		public int intValue;

		public bool boolValue;
	}
}
