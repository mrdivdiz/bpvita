using System;
using UnityEngine;

namespace MentalTools
{
	public class MentalHelper
	{
		public static T EnsureComponent<T>(GameObject go) where T : Component
		{
			T component = go.GetComponent<T>();
			if (component == null)
			{
				return go.AddComponent<T>();
			}
			return component;
		}
	}
}
