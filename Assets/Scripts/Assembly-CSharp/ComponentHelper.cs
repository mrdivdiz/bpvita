using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class ComponentHelper
{
	public static Type GetComponentTypeByName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		if (ComponentHelper._knownComponents == null)
		{
			ComponentHelper._knownComponents = new Dictionary<string, Type>();
			Type typeFromHandle = typeof(Component);
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (Type type in assembly.GetTypes())
				{
					if (typeFromHandle.IsAssignableFrom(type) && !ComponentHelper._knownComponents.ContainsKey(type.Name))
					{
						ComponentHelper._knownComponents.Add(type.Name, type);
					}
				}
			}
		}
		return (!ComponentHelper._knownComponents.ContainsKey(name)) ? null : ComponentHelper._knownComponents[name];
	}

	public static Component AddComponent(this GameObject go, string name)
	{
		if (go == null)
		{
			throw new ArgumentNullException("go");
		}
		Type componentTypeByName = ComponentHelper.GetComponentTypeByName(name);
		return (componentTypeByName == null) ? null : go.AddComponent(componentTypeByName);
	}

	private static Dictionary<string, Type> _knownComponents;
}
