using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

public class ObjectDeserializer
{
	public static void ReadFile(GameObject obj, ObjectDeserializer.ObjectReader reader)
	{
		ObjectDeserializer.PropertyData propertyData = reader.ReadTypeAndName();
		if (propertyData.type == "GameObject" && propertyData.name == obj.name)
		{
			ObjectDeserializer.ReadObject(obj, 1, reader);
		}
	}

	private static void ReadObject(GameObject obj, int depth, ObjectDeserializer.ObjectReader reader)
	{
		while (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.PropertyData propertyData = reader.ReadTypeAndName();
			if (propertyData.type == "Component")
			{
				string text;
				if (propertyData.name.Contains("."))
				{
					text = propertyData.name.Substring(propertyData.name.LastIndexOf(".") + 1);
				}
				else
				{
					text = propertyData.name;
				}
				Component component = obj.GetComponent(text);
				if (component == null)
				{
					Type componentTypeByName = ComponentHelper.GetComponentTypeByName(text);
					component = (componentTypeByName == null) ? null : obj.AddComponent(componentTypeByName);
				}
				if (component != null)
				{
					if (component is ParticleSystem)
					{
						ObjectDeserializer.ReadParticleSystem((ParticleSystem)component, depth + 1, reader);
					}
					else
					{
						ObjectDeserializer.ReadComponent(component, depth + 1, reader);
					}
				}
			}
			else if (propertyData.type == "GameObject")
			{
				GameObject gameObject = obj.transform.Find(propertyData.name).gameObject;
				if (gameObject)
				{
					ObjectDeserializer.ReadObject(gameObject, depth + 1, reader);
				}
			}
		}
	}

	private static void ReadComponent(object component, int depth, ObjectDeserializer.ObjectReader reader)
	{
		while (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.PropertyData propertyData = reader.ReadProperty();
			if (propertyData.type == "Integer")
			{
				ObjectDeserializer.SetProperty(component, propertyData.name, propertyData.IntegerValue);
			}
			else if (propertyData.type == "Float")
			{
				ObjectDeserializer.SetProperty(component, propertyData.name, propertyData.FloatValue);
			}
			else if (propertyData.type == "String")
			{
				ObjectDeserializer.SetProperty(component, propertyData.name, propertyData.StringValue);
				reader.ReadProperty();
			}
			else if (propertyData.type == "Boolean")
			{
				ObjectDeserializer.SetProperty(component, propertyData.name, propertyData.BoolValue);
			}
			else if (propertyData.type == "Enum")
			{
				ObjectDeserializer.SetProperty(component, propertyData.name, propertyData.IntegerValue);
			}
			else if (propertyData.type == "Bounds")
			{
				ObjectDeserializer.SetProperty(component, propertyData.name, ObjectDeserializer.ReadBounds(depth + 1, reader));
			}
			else if (propertyData.type == "ObjectReference")
			{
				UnityEngine.Object referencedObject = reader.GetReferencedObject(propertyData.IntegerValue);
				if (referencedObject)
				{
					ObjectDeserializer.SetProperty(component, propertyData.name, referencedObject);
				}
				else
				{
					ObjectDeserializer.SetProperty(component, propertyData.name, null);
				}
				if (reader.GetIndentation() == depth + 1)
				{
					reader.ReadProperty();
				}
				if (reader.GetIndentation() == depth + 1)
				{
					reader.ReadProperty();
				}
			}
			else if (propertyData.type == "Array")
			{
				ObjectDeserializer.ReadArray(component, propertyData.name, depth + 1, reader);
			}
			else if (propertyData.type == "AnimationCurve")
			{
				ObjectDeserializer.ReadAnimationCurve(component, propertyData.name, depth + 1, reader);
			}
			else if (propertyData.type == "Generic" || propertyData.type == "Color" || propertyData.type == "Vector2" || propertyData.type == "Vector3" || propertyData.type == "Rect" || propertyData.type == "16" || propertyData.type == "Quaternion")
			{
				FieldInfo field = component.GetType().GetField(propertyData.name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (field != null)
				{
					object value = field.GetValue(component);
					ObjectDeserializer.ReadGeneric(value, depth + 1, reader);
					if (field.FieldType.IsValueType)
					{
						field.SetValue(component, value);
					}
				}
				else if (component is Camera && propertyData.name == "m_BackGroundColor")
				{
					object obj = default(Color);
					ObjectDeserializer.ReadGeneric(obj, depth + 1, reader);
					((Camera)component).backgroundColor = (Color)obj;
				}
				else if (component is BoxCollider && propertyData.name == "m_Center")
				{
					Vector3 center = ((BoxCollider)component).center;
					object obj2 = new Vector3(center.x, center.y, center.z);
					ObjectDeserializer.ReadGeneric(obj2, depth + 1, reader);
					((BoxCollider)component).center = (Vector3)obj2;
				}
				else if (component is BoxCollider && propertyData.name == "m_Size")
				{
					Vector3 size = ((BoxCollider)component).size;
					object obj3 = new Vector3(size.x, size.y, size.z);
					ObjectDeserializer.ReadGeneric(obj3, depth + 1, reader);
					((BoxCollider)component).size = (Vector3)obj3;
				}
				else if (component is Transform && propertyData.name == "m_LocalRotation")
				{
					Quaternion localRotation = ((Transform)component).localRotation;
					object obj4 = new Quaternion(localRotation.x, localRotation.y, localRotation.z, localRotation.w);
					ObjectDeserializer.ReadGeneric(obj4, depth + 1, reader);
					((Transform)component).localRotation = (Quaternion)obj4;
				}
				else if (component is Transform && propertyData.name == "m_LocalPosition")
				{
					Vector3 localPosition = ((Transform)component).localPosition;
					object obj5 = new Vector3(localPosition.x, localPosition.y, localPosition.z);
					ObjectDeserializer.ReadGeneric(obj5, depth + 1, reader);
					((Transform)component).localPosition = (Vector3)obj5;
				}
				else if (component is Transform && propertyData.name == "m_LocalScale")
				{
					Vector3 localScale = ((Transform)component).localScale;
					object obj6 = new Vector3(localScale.x, localScale.y, localScale.z);
					ObjectDeserializer.ReadGeneric(obj6, depth + 1, reader);
					((Transform)component).localScale = (Vector3)obj6;
				}
				else if (component is HingeJoint)
				{
				}
			}
		}
	}

	private static void ReadParticleSystemModule(ParticleSystem particleSystem, string module, int depth, ObjectDeserializer.ObjectReader reader)
	{
		while (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.PropertyData propertyData = reader.ReadProperty();
			if (module == "InitialModule")
			{
				if (propertyData.type == "Generic" && propertyData.name == "startLifetime")
				{
					if (reader.GetIndentation() == depth + 1)
					{
						propertyData = reader.ReadProperty();
						particleSystem.startLifetime = propertyData.FloatValue;
					}
				}
				else if (propertyData.type == "Generic" && propertyData.name == "startSpeed" && reader.GetIndentation() == depth + 1)
				{
					propertyData = reader.ReadProperty();
					particleSystem.startSpeed = propertyData.FloatValue;
				}
			}
			else if (module == "EmissionModule")
			{
				if (propertyData.type == "Generic" && propertyData.name == "rate" && reader.GetIndentation() == depth + 1)
				{
					propertyData = reader.ReadProperty();
				}
			}
			else if (!(module == "ShapeModule") || propertyData.type != "Boolean" || propertyData.name != "enabled" || !propertyData.BoolValue)
			{
			}
		}
	}

	private static void ReadParticleSystem(ParticleSystem particleSystem, int depth, ObjectDeserializer.ObjectReader reader)
	{
		while (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.PropertyData propertyData = reader.ReadProperty();
			if (propertyData.type == "Generic" && (propertyData.name == "InitialModule" || propertyData.name == "EmissionModule" || propertyData.name == "ShapeModule"))
			{
				ObjectDeserializer.ReadParticleSystemModule(particleSystem, propertyData.name, depth + 1, reader);
			}
		}
	}

	private static void SetProperty(object obj, string name, object value)
	{
		if (obj is Keyframe && name == "time")
		{
			name = "m_Time";
		}
		FieldInfo field = obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (field != null)
		{
			field.SetValue(obj, value);
		}
		else
		{
			if (obj is Rigidbody && name == "m_IsKinematic")
			{
				name = "isKinematic";
			}
			PropertyInfo property = obj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (property != null)
			{
				property.SetValue(obj, value, null);
			}
			else if (obj is Behaviour && name == "m_Enabled")
			{
				((Behaviour)obj).enabled = (bool)value;
			}
			else if (obj is Camera && name == "orthographic size")
			{
				((Camera)obj).orthographicSize = (float)value;
			}
			else if (obj is Keyframe && name == "inSlope")
			{
				field = obj.GetType().GetField("m_InTangent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				field.SetValue(obj, value);
			}
			else if (obj is Keyframe && name == "outSlope")
			{
				field = obj.GetType().GetField("m_OutTangent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				field.SetValue(obj, value);
			}
			else if (name == "m_ObjectHideFlags" || name == "m_EditorHideFlags" || name == "m_Name" || name == "m_PrefabParentObject" || name == "m_PrefabInternal" || name == "m_GameObject" || name == "m_EditorClassIdentifier" || name == "m_Script" || name == "m_Mesh" || name == "m_ConnectedBody" || name == "m_RootOrder" || name == "m_Mass")
			{
			}
		}
	}

	private static Bounds ReadBounds(int depth, ObjectDeserializer.ObjectReader reader)
	{
		Bounds result = default(Bounds);
		reader.GetIndentation();
		reader.ReadProperty();
		result.center = ObjectDeserializer.ReadVector3(depth + 1, reader);
		reader.GetIndentation();
		reader.ReadProperty();
		result.extents = ObjectDeserializer.ReadVector3(depth + 1, reader);
		return result;
	}

	private static Vector3 ReadVector3(int depth, ObjectDeserializer.ObjectReader reader)
	{
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < 3; i++)
		{
			if (reader.GetIndentation() == depth)
			{
				ObjectDeserializer.PropertyData propertyData = reader.ReadProperty();
				if (propertyData.name == "x")
				{
					zero.x = propertyData.FloatValue;
				}
				else if (propertyData.name == "y")
				{
					zero.y = propertyData.FloatValue;
				}
				else if (propertyData.name == "z")
				{
					zero.z = propertyData.FloatValue;
				}
			}
		}
		return zero;
	}

	private static object GetDefaultValue(Type type)
	{
		object result = null;
		if (type == typeof(int))
		{
			result = 0;
		}
		else if (type == typeof(float))
		{
			result = 0f;
		}
		else if (type == typeof(string))
		{
			result = string.Empty;
		}
		else if (type == typeof(bool))
		{
			result = false;
		}
		else if (type == typeof(Bounds))
		{
			result = default(Bounds);
		}
		else if (type == typeof(Color))
		{
			result = default(Color);
		}
		else if (type == typeof(Vector2))
		{
			result = default(Vector2);
		}
		else if (type == typeof(Vector3))
		{
			result = default(Vector3);
		}
		else if (type == typeof(Quaternion))
		{
			result = default(Quaternion);
		}
		else if (type == typeof(Rect))
		{
			result = default(Rect);
		}
		else if (type == typeof(Keyframe))
		{
			result = default(Keyframe);
		}
		return result;
	}

	private static object ReadValueType(int depth, ObjectDeserializer.ObjectReader reader)
	{
		while (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.PropertyData propertyData = reader.ReadProperty();
			if (propertyData.type == "Integer")
			{
				return propertyData.IntegerValue;
			}
			if (propertyData.type == "Float")
			{
				return propertyData.FloatValue;
			}
			if (propertyData.type == "String")
			{
				return propertyData.StringValue;
			}
			if (propertyData.type == "Boolean")
			{
				return propertyData.BoolValue;
			}
			if (propertyData.type == "Enum")
			{
				return propertyData.IntegerValue;
			}
			if (propertyData.type == "Bounds")
			{
				return ObjectDeserializer.ReadBounds(depth + 1, reader);
			}
			if (propertyData.type == "Color")
			{
				object obj = default(Color);
				ObjectDeserializer.ReadGeneric(obj, depth, reader);
				return obj;
			}
			if (propertyData.type == "Vector2")
			{
				object obj2 = default(Vector2);
				ObjectDeserializer.ReadGeneric(obj2, depth, reader);
				return obj2;
			}
			if (propertyData.type == "Vector3")
			{
				object obj3 = default(Vector3);
				ObjectDeserializer.ReadGeneric(obj3, depth, reader);
				return obj3;
			}
			if (propertyData.type == "Quaternion")
			{
				object obj4 = default(Quaternion);
				ObjectDeserializer.ReadGeneric(obj4, depth, reader);
				return obj4;
			}
			if (propertyData.type == "Rect")
			{
				object obj5 = default(Rect);
				ObjectDeserializer.ReadGeneric(obj5, depth, reader);
				return obj5;
			}
			if (propertyData.type == "Keyframe")
			{
				object obj6 = default(Keyframe);
				ObjectDeserializer.ReadGeneric(obj6, depth, reader);
				return obj6;
			}
		}
		return null;
	}

	private static void ReadGeneric(object obj, int depth, ObjectDeserializer.ObjectReader reader)
	{
		while (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.ReadComponent(obj, depth, reader);
		}
	}

	private static Type FindListInterface(Type listType)
	{
		foreach (Type type in listType.GetInterfaces())
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
			{
				return type;
			}
		}
		return null;
	}

	private static void ReadAnimationCurve(object component, string fieldName, int depth, ObjectDeserializer.ObjectReader reader)
	{
		FieldInfo field = component.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (field == null)
		{
			return;
		}
		object obj = field.GetValue(component);
		if (obj == null)
		{
			obj = Activator.CreateInstance(field.FieldType);
			field.SetValue(component, obj);
		}
		while (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.PropertyData propertyData = reader.ReadProperty();
			Type type = obj.GetType();
			PropertyInfo property = type.GetProperty("keys", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			object value = property.GetValue(obj, null);
			int length = 0;
			depth++;
			if (reader.GetIndentation() == depth)
			{
				propertyData = reader.ReadProperty();
				length = propertyData.IntegerValue;
			}
			IEnumerable enumerable = (IEnumerable)value;
			Type type2 = null;
			Array array = null;
			int num = 0;
			IEnumerator enumerator = enumerable.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj2 = enumerator.Current;
					if (array == null)
					{
						type2 = obj2.GetType();
						array = Array.CreateInstance(type2, length);
					}
					if (array.GetLength(0) <= num)
					{
						break;
					}
					array.SetValue(obj2, num);
					num++;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			while (array.GetLength(0) > num)
			{
				if (array.GetValue(num) == null)
				{
					array.SetValue(Activator.CreateInstance(type2), num);
				}
				num++;
			}
			while (reader.GetIndentation() == depth)
			{
				propertyData = reader.ReadProperty();
				if (propertyData.type == "Element")
				{
					num = int.Parse(propertyData.name);
					while (reader.GetIndentation() == depth + 1)
					{
						propertyData = reader.ReadProperty();
						if (propertyData.type == "Generic" || propertyData.type == "Keyframe")
						{
							object value2 = array.GetValue(num);
							ObjectDeserializer.ReadGeneric(value2, depth + 1, reader);
							array.SetValue(value2, num);
						}
					}
				}
			}
			depth--;
			property.SetValue(obj, array, null);
			field.SetValue(component, obj);
		}
	}

	private static void ReadArray(object component, string fieldName, int depth, ObjectDeserializer.ObjectReader reader)
	{
		FieldInfo field = component.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (field == null)
		{
			return;
		}
		object obj = field.GetValue(component);
		if (obj == null)
		{
			obj = Activator.CreateInstance(field.FieldType);
			field.SetValue(component, obj);
		}
		int num = 0;
		if (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.PropertyData propertyData = reader.ReadProperty();
			num = propertyData.IntegerValue;
		}
		IList list = (IList)obj;
		while (list.Count > num)
		{
			list.RemoveAt(list.Count - 1);
		}
		int num2 = 0;
		while (reader.GetIndentation() == depth)
		{
			ObjectDeserializer.PropertyData propertyData2 = reader.ReadProperty();
			if (propertyData2.type == "Element")
			{
				int num3 = int.Parse(propertyData2.name);
				Type type = list.GetType().GetGenericArguments()[0];
				if (type.IsValueType)
				{
					if (num3 > list.Count)
					{
						list.Add(ObjectDeserializer.GetDefaultValue(type));
						num3 -= num3 - list.Count;
					}
					if (num3 < list.Count)
					{
						list[num3] = ObjectDeserializer.ReadValueType(depth + 1, reader);
					}
					else
					{
						list.Insert(num3, ObjectDeserializer.ReadValueType(depth + 1, reader));
					}
				}
				else if (type.IsSubclassOf(typeof(UnityEngine.Object)))
				{
					reader.GetIndentation();
					propertyData2 = reader.ReadProperty();
					UnityEngine.Object referencedObject = reader.GetReferencedObject(propertyData2.IntegerValue);
					if (referencedObject != null)
					{
						if (list.Count <= num3)
						{
							list.Insert(num3, referencedObject);
						}
						else
						{
							list[num3] = referencedObject;
						}
					}
				}
				else
				{
					reader.GetIndentation();
					propertyData2 = reader.ReadProperty();
					if (list.Count <= num3)
					{
						list.Insert(num3, Activator.CreateInstance(type));
					}
					object obj2 = list[num3];
					ObjectDeserializer.ReadGeneric(obj2, depth + 1, reader);
				}
			}
			num2++;
		}
	}

	private static void PrintObjectInfo(object obj)
	{
		StringBuilder stringBuilder = new StringBuilder();
		PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (properties.Length < 1)
		{
			stringBuilder.Append("Object " + obj.ToString() + " doesn't have any properties");
		}
		else
		{
			stringBuilder.Append("Object " + obj.ToString() + " has properties:");
			foreach (PropertyInfo propertyInfo in properties)
			{
				stringBuilder.Append("\n\tObject property: " + propertyInfo.ToString());
			}
		}
		stringBuilder.Remove(0, stringBuilder.Length);
		FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (fields.Length < 1)
		{
			stringBuilder.Append("Object " + obj.ToString() + " doesn't have any fields");
		}
		else
		{
			stringBuilder.Append("Object " + obj.ToString() + " has fields:");
			foreach (FieldInfo fieldInfo in fields)
			{
				stringBuilder.Append("\n\tObject field: " + fieldInfo.ToString());
			}
		}
		stringBuilder.Remove(0, stringBuilder.Length);
		MemberInfo[] members = obj.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (members.Length < 1)
		{
			stringBuilder.Append("Object " + obj.ToString() + " doesn't have any members");
		}
		else
		{
			stringBuilder.Append("Object " + obj.ToString() + " has members:");
			foreach (MemberInfo memberInfo in members)
			{
				stringBuilder.Append("\n\tObject member: " + memberInfo.ToString());
			}
		}
		stringBuilder.Remove(0, stringBuilder.Length);
		MethodInfo[] methods = obj.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (methods.Length < 1)
		{
			stringBuilder.Append("Object " + obj.ToString() + " doesn't have any methods");
		}
		else
		{
			stringBuilder.Append("Object " + obj.ToString() + " has methods");
			foreach (MethodInfo methodInfo in methods)
			{
				stringBuilder.Append("\n\tObject method: " + methodInfo.ToString());
			}
		}
	}

	private const string GameObjectType = "GameObject";

	private const string ComponentType = "Component";

	private const string IntegerType = "Integer";

	private const string FloatType = "Float";

	private const string StringType = "String";

	private const string BooleanType = "Boolean";

	private const string EnumType = "Enum";

	private const string Vector2Type = "Vector2";

	private const string Vector3Type = "Vector3";

	private const string QuaternionType = "Quaternion";

	private const string AnimationCurveType = "AnimationCurve";

	private const string ColorType = "Color";

	private const string RectType = "Rect";

	private const string BoundsType = "Bounds";

	private const string ObjectReferenceType = "ObjectReference";

	private const string GenericType = "Generic";

	private const string ArrayType = "Array";

	private const string ArrayElementType = "Element";

	private const string KeyframeType = "Keyframe";

	public class PropertyData
	{
		public PropertyData(string type, string name)
		{
			this.type = type;
			this.name = name;
		}

		public PropertyData(string type, string name, string value)
		{
			this.type = type;
			this.name = name;
			this.value = value;
		}

		public int IntegerValue
		{
			get
			{
				return int.Parse(this.value);
			}
		}

		public float FloatValue
		{
			get
			{
				return float.Parse(this.value, CultureInfo.InvariantCulture);
			}
		}

		public string StringValue
		{
			get
			{
				return this.value.Substring(1, this.value.Length - 2);
			}
		}

		public bool BoolValue
		{
			get
			{
				return this.value == "True";
			}
		}

		public string type;

		public string name;

		public string value;
	}

	public class ObjectReader
	{
		public ObjectReader(StreamReader reader, List<UnityEngine.Object> references)
		{
			this.m_reader = reader;
			this.m_references = references;
		}

		public UnityEngine.Object GetReferencedObject(int index)
		{
			if (this.m_references != null)
			{
				return this.m_references[index];
			}
			return null;
		}

		private string ReadLine()
		{
			this.m_indentationRead = false;
			return this.m_reader.ReadLine();
		}

		public ObjectDeserializer.PropertyData ReadProperty()
		{
			string text = this.ReadLine();
			string[] array = text.Split(new char[]
			{
				' '
			});
			if (array.Length == 2)
			{
				return new ObjectDeserializer.PropertyData(array[0], array[1]);
			}
			if (array.Length == 4 && array[2] == "=")
			{
				return new ObjectDeserializer.PropertyData(array[0], array[1], array[3]);
			}
			if (array.Length > 4)
			{
				string text2 = string.Empty;
				for (int i = 1; i < array.Length; i++)
				{
					if (!(array[i] != "="))
					{
						break;
					}
					if (i > 1)
					{
						text2 += " ";
					}
					text2 += array[i];
				}
				return new ObjectDeserializer.PropertyData(array[0], text2, array[array.Length - 1]);
			}
			return null;
		}

		public ObjectDeserializer.PropertyData ReadTypeAndName()
		{
			string text = this.ReadLine();
			string[] array = text.Split(this.Delimiters, 2);
			if (array.Length == 2)
			{
				return new ObjectDeserializer.PropertyData(array[0], array[1]);
			}
			return null;
		}

		public int GetIndentation()
		{
			if (this.m_indentationRead)
			{
				return this.m_indentation;
			}
			int num = 0;
			while (this.m_reader.Peek() == 9)
			{
				num++;
				this.m_reader.Read();
			}
			this.m_indentation = num;
			this.m_indentationRead = true;
			return num;
		}

		private StreamReader m_reader;

		private int m_indentation;

		private bool m_indentationRead;

		private List<UnityEngine.Object> m_references;

		private readonly char[] Delimiters = new char[]
		{
			' '
		};
	}
}
