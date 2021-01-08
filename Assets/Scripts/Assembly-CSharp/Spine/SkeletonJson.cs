using System;
using System.Collections.Generic;
using System.IO;

namespace Spine
{
	public class SkeletonJson
	{
		public SkeletonJson(params Atlas[] atlasArray) : this(new AtlasAttachmentLoader(atlasArray))
		{
		}

		public SkeletonJson(AttachmentLoader attachmentLoader)
		{
			if (attachmentLoader == null)
			{
				throw new ArgumentNullException("attachmentLoader", "attachmentLoader cannot be null.");
			}
			this.attachmentLoader = attachmentLoader;
			this.Scale = 1f;
		}

		public float Scale { get; set; }

		public SkeletonData ReadSkeletonData(string path)
		{
			SkeletonData result;
			using (StreamReader streamReader = new StreamReader(path))
			{
				SkeletonData skeletonData = this.ReadSkeletonData(streamReader);
				skeletonData.name = Path.GetFileNameWithoutExtension(path);
				result = skeletonData;
			}
			return result;
		}

		public SkeletonData ReadSkeletonData(TextReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader", "reader cannot be null.");
			}
			float scale = this.Scale;
			SkeletonData skeletonData = new SkeletonData();
			Dictionary<string, object> dictionary = Json.Deserialize(reader) as Dictionary<string, object>;
			if (dictionary == null)
			{
				throw new Exception("Invalid JSON.");
			}
			if (dictionary.ContainsKey("skeleton"))
			{
				Dictionary<string, object> dictionary2 = (Dictionary<string, object>)dictionary["skeleton"];
				skeletonData.hash = (string)dictionary2["hash"];
				skeletonData.version = (string)dictionary2["spine"];
				skeletonData.width = SkeletonJson.GetFloat(dictionary2, "width", 0f);
				skeletonData.height = SkeletonJson.GetFloat(dictionary2, "height", 0f);
			}
			foreach (object obj in ((List<object>)dictionary["bones"]))
			{
				Dictionary<string, object> dictionary3 = (Dictionary<string, object>)obj;
				BoneData boneData = null;
				if (dictionary3.ContainsKey("parent"))
				{
					boneData = skeletonData.FindBone((string)dictionary3["parent"]);
					if (boneData == null)
					{
						throw new Exception("Parent bone not found: " + dictionary3["parent"]);
					}
				}
				BoneData boneData2 = new BoneData(skeletonData.Bones.Count, (string)dictionary3["name"], boneData);
				boneData2.length = SkeletonJson.GetFloat(dictionary3, "length", 0f) * scale;
				boneData2.x = SkeletonJson.GetFloat(dictionary3, "x", 0f) * scale;
				boneData2.y = SkeletonJson.GetFloat(dictionary3, "y", 0f) * scale;
				boneData2.rotation = SkeletonJson.GetFloat(dictionary3, "rotation", 0f);
				boneData2.scaleX = SkeletonJson.GetFloat(dictionary3, "scaleX", 1f);
				boneData2.scaleY = SkeletonJson.GetFloat(dictionary3, "scaleY", 1f);
				boneData2.shearX = SkeletonJson.GetFloat(dictionary3, "shearX", 0f);
				boneData2.shearY = SkeletonJson.GetFloat(dictionary3, "shearY", 0f);
				boneData2.inheritRotation = SkeletonJson.GetBoolean(dictionary3, "inheritRotation", true);
				boneData2.inheritScale = SkeletonJson.GetBoolean(dictionary3, "inheritScale", true);
				skeletonData.bones.Add(boneData2);
			}
			if (dictionary.ContainsKey("slots"))
			{
				foreach (object obj2 in ((List<object>)dictionary["slots"]))
				{
					Dictionary<string, object> dictionary4 = (Dictionary<string, object>)obj2;
					string name = (string)dictionary4["name"];
					string text = (string)dictionary4["bone"];
					BoneData boneData3 = skeletonData.FindBone(text);
					if (boneData3 == null)
					{
						throw new Exception("Slot bone not found: " + text);
					}
					SlotData slotData = new SlotData(skeletonData.Slots.Count, name, boneData3);
					if (dictionary4.ContainsKey("color"))
					{
						string hexString = (string)dictionary4["color"];
						slotData.r = SkeletonJson.ToColor(hexString, 0);
						slotData.g = SkeletonJson.ToColor(hexString, 1);
						slotData.b = SkeletonJson.ToColor(hexString, 2);
						slotData.a = SkeletonJson.ToColor(hexString, 3);
					}
					slotData.attachmentName = SkeletonJson.GetString(dictionary4, "attachment", null);
					if (dictionary4.ContainsKey("blend"))
					{
						slotData.blendMode = (BlendMode)Enum.Parse(typeof(BlendMode), (string)dictionary4["blend"], false);
					}
					else
					{
						slotData.blendMode = BlendMode.normal;
					}
					skeletonData.slots.Add(slotData);
				}
			}
			if (dictionary.ContainsKey("ik"))
			{
				foreach (object obj3 in ((List<object>)dictionary["ik"]))
				{
					Dictionary<string, object> dictionary5 = (Dictionary<string, object>)obj3;
					IkConstraintData ikConstraintData = new IkConstraintData((string)dictionary5["name"]);
					foreach (object obj4 in ((List<object>)dictionary5["bones"]))
					{
						string text2 = (string)obj4;
						BoneData boneData4 = skeletonData.FindBone(text2);
						if (boneData4 == null)
						{
							throw new Exception("IK constraint bone not found: " + text2);
						}
						ikConstraintData.bones.Add(boneData4);
					}
					string text3 = (string)dictionary5["target"];
					ikConstraintData.target = skeletonData.FindBone(text3);
					if (ikConstraintData.target == null)
					{
						throw new Exception("Target bone not found: " + text3);
					}
					ikConstraintData.bendDirection = ((!SkeletonJson.GetBoolean(dictionary5, "bendPositive", true)) ? -1 : 1);
					ikConstraintData.mix = SkeletonJson.GetFloat(dictionary5, "mix", 1f);
					skeletonData.ikConstraints.Add(ikConstraintData);
				}
			}
			if (dictionary.ContainsKey("transform"))
			{
				foreach (object obj5 in ((List<object>)dictionary["transform"]))
				{
					Dictionary<string, object> dictionary6 = (Dictionary<string, object>)obj5;
					TransformConstraintData transformConstraintData = new TransformConstraintData((string)dictionary6["name"]);
					foreach (object obj6 in ((List<object>)dictionary6["bones"]))
					{
						string text4 = (string)obj6;
						BoneData boneData5 = skeletonData.FindBone(text4);
						if (boneData5 == null)
						{
							throw new Exception("Transform constraint bone not found: " + text4);
						}
						transformConstraintData.bones.Add(boneData5);
					}
					string text5 = (string)dictionary6["target"];
					transformConstraintData.target = skeletonData.FindBone(text5);
					if (transformConstraintData.target == null)
					{
						throw new Exception("Target bone not found: " + text5);
					}
					transformConstraintData.offsetRotation = SkeletonJson.GetFloat(dictionary6, "rotation", 0f);
					transformConstraintData.offsetX = SkeletonJson.GetFloat(dictionary6, "x", 0f) * scale;
					transformConstraintData.offsetY = SkeletonJson.GetFloat(dictionary6, "y", 0f) * scale;
					transformConstraintData.offsetScaleX = SkeletonJson.GetFloat(dictionary6, "scaleX", 0f);
					transformConstraintData.offsetScaleY = SkeletonJson.GetFloat(dictionary6, "scaleY", 0f);
					transformConstraintData.offsetShearY = SkeletonJson.GetFloat(dictionary6, "shearY", 0f);
					transformConstraintData.rotateMix = SkeletonJson.GetFloat(dictionary6, "rotateMix", 1f);
					transformConstraintData.translateMix = SkeletonJson.GetFloat(dictionary6, "translateMix", 1f);
					transformConstraintData.scaleMix = SkeletonJson.GetFloat(dictionary6, "scaleMix", 1f);
					transformConstraintData.shearMix = SkeletonJson.GetFloat(dictionary6, "shearMix", 1f);
					skeletonData.transformConstraints.Add(transformConstraintData);
				}
			}
			if (dictionary.ContainsKey("path"))
			{
				foreach (object obj7 in ((List<object>)dictionary["path"]))
				{
					Dictionary<string, object> dictionary7 = (Dictionary<string, object>)obj7;
					PathConstraintData pathConstraintData = new PathConstraintData((string)dictionary7["name"]);
					foreach (object obj8 in ((List<object>)dictionary7["bones"]))
					{
						string text6 = (string)obj8;
						BoneData boneData6 = skeletonData.FindBone(text6);
						if (boneData6 == null)
						{
							throw new Exception("Path bone not found: " + text6);
						}
						pathConstraintData.bones.Add(boneData6);
					}
					string text7 = (string)dictionary7["target"];
					pathConstraintData.target = skeletonData.FindSlot(text7);
					if (pathConstraintData.target == null)
					{
						throw new Exception("Target slot not found: " + text7);
					}
					pathConstraintData.positionMode = (PositionMode)Enum.Parse(typeof(PositionMode), SkeletonJson.GetString(dictionary7, "positionMode", "percent"), true);
					pathConstraintData.spacingMode = (SpacingMode)Enum.Parse(typeof(SpacingMode), SkeletonJson.GetString(dictionary7, "spacingMode", "length"), true);
					pathConstraintData.rotateMode = (RotateMode)Enum.Parse(typeof(RotateMode), SkeletonJson.GetString(dictionary7, "rotateMode", "tangent"), true);
					pathConstraintData.offsetRotation = SkeletonJson.GetFloat(dictionary7, "rotation", 0f);
					pathConstraintData.position = SkeletonJson.GetFloat(dictionary7, "position", 0f);
					if (pathConstraintData.positionMode == PositionMode.Fixed)
					{
						pathConstraintData.position *= scale;
					}
					pathConstraintData.spacing = SkeletonJson.GetFloat(dictionary7, "spacing", 0f);
					if (pathConstraintData.spacingMode == SpacingMode.Length || pathConstraintData.spacingMode == SpacingMode.Fixed)
					{
						pathConstraintData.spacing *= scale;
					}
					pathConstraintData.rotateMix = SkeletonJson.GetFloat(dictionary7, "rotateMix", 1f);
					pathConstraintData.translateMix = SkeletonJson.GetFloat(dictionary7, "translateMix", 1f);
					skeletonData.pathConstraints.Add(pathConstraintData);
				}
			}
			if (dictionary.ContainsKey("skins"))
			{
				foreach (KeyValuePair<string, object> keyValuePair in ((Dictionary<string, object>)dictionary["skins"]))
				{
					Skin skin = new Skin(keyValuePair.Key);
					foreach (KeyValuePair<string, object> keyValuePair2 in ((Dictionary<string, object>)keyValuePair.Value))
					{
						int slotIndex = skeletonData.FindSlotIndex(keyValuePair2.Key);
						foreach (KeyValuePair<string, object> keyValuePair3 in ((Dictionary<string, object>)keyValuePair2.Value))
						{
							try
							{
								Attachment attachment = this.ReadAttachment((Dictionary<string, object>)keyValuePair3.Value, skin, slotIndex, keyValuePair3.Key);
								if (attachment != null)
								{
									skin.AddAttachment(slotIndex, keyValuePair3.Key, attachment);
								}
							}
							catch (Exception innerException)
							{
								throw new Exception(string.Concat(new object[]
								{
									"Error reading attachment: ",
									keyValuePair3.Key,
									", skin: ",
									skin
								}), innerException);
							}
						}
					}
					skeletonData.skins.Add(skin);
					if (skin.name == "default")
					{
						skeletonData.defaultSkin = skin;
					}
				}
			}
			int i = 0;
			int count = this.linkedMeshes.Count;
			while (i < count)
			{
                LinkedMesh linkedMesh = this.linkedMeshes[i];
				Skin skin2 = (linkedMesh.skin != null) ? skeletonData.FindSkin(linkedMesh.skin) : skeletonData.defaultSkin;
				if (skin2 == null)
				{
					throw new Exception("Slot not found: " + linkedMesh.skin);
				}
				Attachment attachment2 = skin2.GetAttachment(linkedMesh.slotIndex, linkedMesh.parent);
				if (attachment2 == null)
				{
					throw new Exception("Parent mesh not found: " + linkedMesh.parent);
				}
				linkedMesh.mesh.ParentMesh = (MeshAttachment)attachment2;
				linkedMesh.mesh.UpdateUVs();
				i++;
			}
			this.linkedMeshes.Clear();
			if (dictionary.ContainsKey("events"))
			{
				foreach (KeyValuePair<string, object> keyValuePair4 in ((Dictionary<string, object>)dictionary["events"]))
				{
					Dictionary<string, object> map = (Dictionary<string, object>)keyValuePair4.Value;
					EventData eventData = new EventData(keyValuePair4.Key);
					eventData.Int = SkeletonJson.GetInt(map, "int", 0);
					eventData.Float = SkeletonJson.GetFloat(map, "float", 0f);
					eventData.String = SkeletonJson.GetString(map, "string", null);
					skeletonData.events.Add(eventData);
				}
			}
			if (dictionary.ContainsKey("animations"))
			{
				foreach (KeyValuePair<string, object> keyValuePair5 in ((Dictionary<string, object>)dictionary["animations"]))
				{
					try
					{
						this.ReadAnimation((Dictionary<string, object>)keyValuePair5.Value, keyValuePair5.Key, skeletonData);
					}
					catch (Exception innerException2)
					{
						throw new Exception("Error reading animation: " + keyValuePair5.Key, innerException2);
					}
				}
			}
			skeletonData.bones.TrimExcess();
			skeletonData.slots.TrimExcess();
			skeletonData.skins.TrimExcess();
			skeletonData.events.TrimExcess();
			skeletonData.animations.TrimExcess();
			skeletonData.ikConstraints.TrimExcess();
			return skeletonData;
		}

		private Attachment ReadAttachment(Dictionary<string, object> map, Skin skin, int slotIndex, string name)
		{
			float scale = this.Scale;
			name = SkeletonJson.GetString(map, "name", name);
			string text = SkeletonJson.GetString(map, "type", "region");
			if (text == "skinnedmesh")
			{
				text = "weightedmesh";
			}
			if (text == "weightedmesh")
			{
				text = "mesh";
			}
			if (text == "weightedlinkedmesh")
			{
				text = "linkedmesh";
			}
			AttachmentType attachmentType = (AttachmentType)Enum.Parse(typeof(AttachmentType), text, true);
			string @string = SkeletonJson.GetString(map, "path", name);
			switch (attachmentType)
			{
			case AttachmentType.Region:
			{
				RegionAttachment regionAttachment = this.attachmentLoader.NewRegionAttachment(skin, name, @string);
				if (regionAttachment == null)
				{
					return null;
				}
				regionAttachment.Path = @string;
				regionAttachment.x = SkeletonJson.GetFloat(map, "x", 0f) * scale;
				regionAttachment.y = SkeletonJson.GetFloat(map, "y", 0f) * scale;
				regionAttachment.scaleX = SkeletonJson.GetFloat(map, "scaleX", 1f);
				regionAttachment.scaleY = SkeletonJson.GetFloat(map, "scaleY", 1f);
				regionAttachment.rotation = SkeletonJson.GetFloat(map, "rotation", 0f);
				regionAttachment.width = SkeletonJson.GetFloat(map, "width", 32f) * scale;
				regionAttachment.height = SkeletonJson.GetFloat(map, "height", 32f) * scale;
				regionAttachment.UpdateOffset();
				if (map.ContainsKey("color"))
				{
					string hexString = (string)map["color"];
					regionAttachment.r = SkeletonJson.ToColor(hexString, 0);
					regionAttachment.g = SkeletonJson.ToColor(hexString, 1);
					regionAttachment.b = SkeletonJson.ToColor(hexString, 2);
					regionAttachment.a = SkeletonJson.ToColor(hexString, 3);
				}
				regionAttachment.UpdateOffset();
				return regionAttachment;
			}
			case AttachmentType.Boundingbox:
			{
				BoundingBoxAttachment boundingBoxAttachment = this.attachmentLoader.NewBoundingBoxAttachment(skin, name);
				if (boundingBoxAttachment == null)
				{
					return null;
				}
				this.ReadVertices(map, boundingBoxAttachment, SkeletonJson.GetInt(map, "vertexCount", 0) << 1);
				return boundingBoxAttachment;
			}
			case AttachmentType.Mesh:
			case AttachmentType.Linkedmesh:
			{
				MeshAttachment meshAttachment = this.attachmentLoader.NewMeshAttachment(skin, name, @string);
				if (meshAttachment == null)
				{
					return null;
				}
				meshAttachment.Path = @string;
				if (map.ContainsKey("color"))
				{
					string hexString2 = (string)map["color"];
					meshAttachment.r = SkeletonJson.ToColor(hexString2, 0);
					meshAttachment.g = SkeletonJson.ToColor(hexString2, 1);
					meshAttachment.b = SkeletonJson.ToColor(hexString2, 2);
					meshAttachment.a = SkeletonJson.ToColor(hexString2, 3);
				}
				meshAttachment.Width = SkeletonJson.GetFloat(map, "width", 0f) * scale;
				meshAttachment.Height = SkeletonJson.GetFloat(map, "height", 0f) * scale;
				string string2 = SkeletonJson.GetString(map, "parent", null);
				if (string2 != null)
				{
					meshAttachment.InheritDeform = SkeletonJson.GetBoolean(map, "deform", true);
					this.linkedMeshes.Add(new LinkedMesh(meshAttachment, SkeletonJson.GetString(map, "skin", null), slotIndex, string2));
					return meshAttachment;
				}
				float[] floatArray = SkeletonJson.GetFloatArray(map, "uvs", 1f);
				this.ReadVertices(map, meshAttachment, floatArray.Length);
				meshAttachment.triangles = SkeletonJson.GetIntArray(map, "triangles");
				meshAttachment.regionUVs = floatArray;
				meshAttachment.UpdateUVs();
				if (map.ContainsKey("hull"))
				{
					meshAttachment.HullLength = SkeletonJson.GetInt(map, "hull", 0) * 2;
				}
				if (map.ContainsKey("edges"))
				{
					meshAttachment.Edges = SkeletonJson.GetIntArray(map, "edges");
				}
				return meshAttachment;
			}
			case AttachmentType.Path:
			{
				PathAttachment pathAttachment = this.attachmentLoader.NewPathAttachment(skin, name);
				if (pathAttachment == null)
				{
					return null;
				}
				pathAttachment.closed = SkeletonJson.GetBoolean(map, "closed", false);
				pathAttachment.constantSpeed = SkeletonJson.GetBoolean(map, "constantSpeed", true);
				int @int = SkeletonJson.GetInt(map, "vertexCount", 0);
				this.ReadVertices(map, pathAttachment, @int << 1);
				pathAttachment.lengths = SkeletonJson.GetFloatArray(map, "lengths", scale);
				return pathAttachment;
			}
			default:
				return null;
			}
		}

		private void ReadVertices(Dictionary<string, object> map, VertexAttachment attachment, int verticesLength)
		{
			attachment.WorldVerticesLength = verticesLength;
			float[] floatArray = SkeletonJson.GetFloatArray(map, "vertices", 1f);
			float scale = this.Scale;
			if (verticesLength == floatArray.Length)
			{
				if (scale != 1f)
				{
					for (int i = 0; i < floatArray.Length; i++)
					{
						floatArray[i] *= scale;
					}
				}
				attachment.vertices = floatArray;
				return;
			}
			ExposedList<float> exposedList = new ExposedList<float>(verticesLength * 3 * 3);
			ExposedList<int> exposedList2 = new ExposedList<int>(verticesLength * 3);
			int j = 0;
			int num = floatArray.Length;
			while (j < num)
			{
				int num2 = (int)floatArray[j++];
				exposedList2.Add(num2);
				int num3 = j + num2 * 4;
				while (j < num3)
				{
					exposedList2.Add((int)floatArray[j]);
					exposedList.Add(floatArray[j + 1] * this.Scale);
					exposedList.Add(floatArray[j + 2] * this.Scale);
					exposedList.Add(floatArray[j + 3]);
					j += 4;
				}
			}
			attachment.bones = exposedList2.ToArray();
			attachment.vertices = exposedList.ToArray();
		}

		private void ReadAnimation(Dictionary<string, object> map, string name, SkeletonData skeletonData)
		{
			float scale = this.Scale;
			ExposedList<Timeline> exposedList = new ExposedList<Timeline>();
			float num = 0f;
			if (map.ContainsKey("slots"))
			{
				foreach (KeyValuePair<string, object> keyValuePair in ((Dictionary<string, object>)map["slots"]))
				{
					string key = keyValuePair.Key;
					int slotIndex = skeletonData.FindSlotIndex(key);
					Dictionary<string, object> dictionary = (Dictionary<string, object>)keyValuePair.Value;
					foreach (KeyValuePair<string, object> keyValuePair2 in dictionary)
					{
						List<object> list = (List<object>)keyValuePair2.Value;
						string key2 = keyValuePair2.Key;
						if (key2 == "color")
						{
							ColorTimeline colorTimeline = new ColorTimeline(list.Count);
							colorTimeline.slotIndex = slotIndex;
							int num2 = 0;
							foreach (object obj in list)
							{
								Dictionary<string, object> dictionary2 = (Dictionary<string, object>)obj;
								float time = (float)dictionary2["time"];
								string hexString = (string)dictionary2["color"];
								colorTimeline.SetFrame(num2, time, SkeletonJson.ToColor(hexString, 0), SkeletonJson.ToColor(hexString, 1), SkeletonJson.ToColor(hexString, 2), SkeletonJson.ToColor(hexString, 3));
								SkeletonJson.ReadCurve(dictionary2, colorTimeline, num2);
								num2++;
							}
							exposedList.Add(colorTimeline);
							num = Math.Max(num, colorTimeline.frames[(colorTimeline.FrameCount - 1) * 5]);
						}
						else
						{
							if (!(key2 == "attachment"))
							{
								throw new Exception(string.Concat(new string[]
								{
									"Invalid timeline type for a slot: ",
									key2,
									" (",
									key,
									")"
								}));
							}
							AttachmentTimeline attachmentTimeline = new AttachmentTimeline(list.Count);
							attachmentTimeline.slotIndex = slotIndex;
							int num3 = 0;
							foreach (object obj2 in list)
							{
								Dictionary<string, object> dictionary3 = (Dictionary<string, object>)obj2;
								float time2 = (float)dictionary3["time"];
								attachmentTimeline.SetFrame(num3++, time2, (string)dictionary3["name"]);
							}
							exposedList.Add(attachmentTimeline);
							num = Math.Max(num, attachmentTimeline.frames[attachmentTimeline.FrameCount - 1]);
						}
					}
				}
			}
			if (map.ContainsKey("bones"))
			{
				foreach (KeyValuePair<string, object> keyValuePair3 in ((Dictionary<string, object>)map["bones"]))
				{
					string key3 = keyValuePair3.Key;
					int num4 = skeletonData.FindBoneIndex(key3);
					if (num4 == -1)
					{
						throw new Exception("Bone not found: " + key3);
					}
					Dictionary<string, object> dictionary4 = (Dictionary<string, object>)keyValuePair3.Value;
					foreach (KeyValuePair<string, object> keyValuePair4 in dictionary4)
					{
						List<object> list2 = (List<object>)keyValuePair4.Value;
						string key4 = keyValuePair4.Key;
						if (key4 == "rotate")
						{
							RotateTimeline rotateTimeline = new RotateTimeline(list2.Count);
							rotateTimeline.boneIndex = num4;
							int num5 = 0;
							foreach (object obj3 in list2)
							{
								Dictionary<string, object> dictionary5 = (Dictionary<string, object>)obj3;
								rotateTimeline.SetFrame(num5, (float)dictionary5["time"], (float)dictionary5["angle"]);
								SkeletonJson.ReadCurve(dictionary5, rotateTimeline, num5);
								num5++;
							}
							exposedList.Add(rotateTimeline);
							num = Math.Max(num, rotateTimeline.frames[(rotateTimeline.FrameCount - 1) * 2]);
						}
						else
						{
							if (!(key4 == "translate") && !(key4 == "scale") && !(key4 == "shear"))
							{
								throw new Exception(string.Concat(new string[]
								{
									"Invalid timeline type for a bone: ",
									key4,
									" (",
									key3,
									")"
								}));
							}
							float num6 = 1f;
							TranslateTimeline translateTimeline;
							if (key4 == "scale")
							{
								translateTimeline = new ScaleTimeline(list2.Count);
							}
							else if (key4 == "shear")
							{
								translateTimeline = new ShearTimeline(list2.Count);
							}
							else
							{
								translateTimeline = new TranslateTimeline(list2.Count);
								num6 = scale;
							}
							translateTimeline.boneIndex = num4;
							int num7 = 0;
							foreach (object obj4 in list2)
							{
								Dictionary<string, object> dictionary6 = (Dictionary<string, object>)obj4;
								float time3 = (float)dictionary6["time"];
								float @float = SkeletonJson.GetFloat(dictionary6, "x", 0f);
								float float2 = SkeletonJson.GetFloat(dictionary6, "y", 0f);
								translateTimeline.SetFrame(num7, time3, @float * num6, float2 * num6);
								SkeletonJson.ReadCurve(dictionary6, translateTimeline, num7);
								num7++;
							}
							exposedList.Add(translateTimeline);
							num = Math.Max(num, translateTimeline.frames[(translateTimeline.FrameCount - 1) * 3]);
						}
					}
				}
			}
			if (map.ContainsKey("ik"))
			{
				foreach (KeyValuePair<string, object> keyValuePair5 in ((Dictionary<string, object>)map["ik"]))
				{
					IkConstraintData item = skeletonData.FindIkConstraint(keyValuePair5.Key);
					List<object> list3 = (List<object>)keyValuePair5.Value;
					IkConstraintTimeline ikConstraintTimeline = new IkConstraintTimeline(list3.Count);
					ikConstraintTimeline.ikConstraintIndex = skeletonData.ikConstraints.IndexOf(item);
					int num8 = 0;
					foreach (object obj5 in list3)
					{
						Dictionary<string, object> dictionary7 = (Dictionary<string, object>)obj5;
						float time4 = (float)dictionary7["time"];
						float float3 = SkeletonJson.GetFloat(dictionary7, "mix", 1f);
						bool boolean = SkeletonJson.GetBoolean(dictionary7, "bendPositive", true);
						ikConstraintTimeline.SetFrame(num8, time4, float3, (!boolean) ? -1 : 1);
						SkeletonJson.ReadCurve(dictionary7, ikConstraintTimeline, num8);
						num8++;
					}
					exposedList.Add(ikConstraintTimeline);
					num = Math.Max(num, ikConstraintTimeline.frames[(ikConstraintTimeline.FrameCount - 1) * 3]);
				}
			}
			if (map.ContainsKey("transform"))
			{
				foreach (KeyValuePair<string, object> keyValuePair6 in ((Dictionary<string, object>)map["transform"]))
				{
					TransformConstraintData item2 = skeletonData.FindTransformConstraint(keyValuePair6.Key);
					List<object> list4 = (List<object>)keyValuePair6.Value;
					TransformConstraintTimeline transformConstraintTimeline = new TransformConstraintTimeline(list4.Count);
					transformConstraintTimeline.transformConstraintIndex = skeletonData.transformConstraints.IndexOf(item2);
					int num9 = 0;
					foreach (object obj6 in list4)
					{
						Dictionary<string, object> dictionary8 = (Dictionary<string, object>)obj6;
						float time5 = (float)dictionary8["time"];
						float float4 = SkeletonJson.GetFloat(dictionary8, "rotateMix", 1f);
						float float5 = SkeletonJson.GetFloat(dictionary8, "translateMix", 1f);
						float float6 = SkeletonJson.GetFloat(dictionary8, "scaleMix", 1f);
						float float7 = SkeletonJson.GetFloat(dictionary8, "shearMix", 1f);
						transformConstraintTimeline.SetFrame(num9, time5, float4, float5, float6, float7);
						SkeletonJson.ReadCurve(dictionary8, transformConstraintTimeline, num9);
						num9++;
					}
					exposedList.Add(transformConstraintTimeline);
					num = Math.Max(num, transformConstraintTimeline.frames[(transformConstraintTimeline.FrameCount - 1) * 5]);
				}
			}
			if (map.ContainsKey("paths"))
			{
				foreach (KeyValuePair<string, object> keyValuePair7 in ((Dictionary<string, object>)map["paths"]))
				{
					int num10 = skeletonData.FindPathConstraintIndex(keyValuePair7.Key);
					if (num10 == -1)
					{
						throw new Exception("Path constraint not found: " + keyValuePair7.Key);
					}
					PathConstraintData pathConstraintData = skeletonData.pathConstraints.Items[num10];
					Dictionary<string, object> dictionary9 = (Dictionary<string, object>)keyValuePair7.Value;
					foreach (KeyValuePair<string, object> keyValuePair8 in dictionary9)
					{
						List<object> list5 = (List<object>)keyValuePair8.Value;
						string key5 = keyValuePair8.Key;
						if (key5 == "position" || key5 == "spacing")
						{
							float num11 = 1f;
							PathConstraintPositionTimeline pathConstraintPositionTimeline;
							if (key5 == "spacing")
							{
								pathConstraintPositionTimeline = new PathConstraintSpacingTimeline(list5.Count);
								if (pathConstraintData.spacingMode == SpacingMode.Length || pathConstraintData.spacingMode == SpacingMode.Fixed)
								{
									num11 = scale;
								}
							}
							else
							{
								pathConstraintPositionTimeline = new PathConstraintPositionTimeline(list5.Count);
								if (pathConstraintData.positionMode == PositionMode.Fixed)
								{
									num11 = scale;
								}
							}
							pathConstraintPositionTimeline.pathConstraintIndex = num10;
							int num12 = 0;
							foreach (object obj7 in list5)
							{
								Dictionary<string, object> dictionary10 = (Dictionary<string, object>)obj7;
								pathConstraintPositionTimeline.SetFrame(num12, (float)dictionary10["time"], SkeletonJson.GetFloat(dictionary10, key5, 0f) * num11);
								SkeletonJson.ReadCurve(dictionary10, pathConstraintPositionTimeline, num12);
								num12++;
							}
							exposedList.Add(pathConstraintPositionTimeline);
							num = Math.Max(num, pathConstraintPositionTimeline.frames[(pathConstraintPositionTimeline.FrameCount - 1) * 2]);
						}
						else if (key5 == "mix")
						{
							PathConstraintMixTimeline pathConstraintMixTimeline = new PathConstraintMixTimeline(list5.Count);
							pathConstraintMixTimeline.pathConstraintIndex = num10;
							int num13 = 0;
							foreach (object obj8 in list5)
							{
								Dictionary<string, object> dictionary11 = (Dictionary<string, object>)obj8;
								pathConstraintMixTimeline.SetFrame(num13, (float)dictionary11["time"], SkeletonJson.GetFloat(dictionary11, "rotateMix", 1f), SkeletonJson.GetFloat(dictionary11, "translateMix", 1f));
								SkeletonJson.ReadCurve(dictionary11, pathConstraintMixTimeline, num13);
								num13++;
							}
							exposedList.Add(pathConstraintMixTimeline);
							num = Math.Max(num, pathConstraintMixTimeline.frames[(pathConstraintMixTimeline.FrameCount - 1) * 3]);
						}
					}
				}
			}
			if (map.ContainsKey("deform"))
			{
				foreach (KeyValuePair<string, object> keyValuePair9 in ((Dictionary<string, object>)map["deform"]))
				{
					Skin skin = skeletonData.FindSkin(keyValuePair9.Key);
					foreach (KeyValuePair<string, object> keyValuePair10 in ((Dictionary<string, object>)keyValuePair9.Value))
					{
						int num14 = skeletonData.FindSlotIndex(keyValuePair10.Key);
						if (num14 == -1)
						{
							throw new Exception("Slot not found: " + keyValuePair10.Key);
						}
						foreach (KeyValuePair<string, object> keyValuePair11 in ((Dictionary<string, object>)keyValuePair10.Value))
						{
							List<object> list6 = (List<object>)keyValuePair11.Value;
							VertexAttachment vertexAttachment = (VertexAttachment)skin.GetAttachment(num14, keyValuePair11.Key);
							if (vertexAttachment == null)
							{
								throw new Exception("Deform attachment not found: " + keyValuePair11.Key);
							}
							bool flag = vertexAttachment.bones != null;
							float[] vertices = vertexAttachment.vertices;
							int num15 = (!flag) ? vertices.Length : (vertices.Length / 3 * 2);
							DeformTimeline deformTimeline = new DeformTimeline(list6.Count);
							deformTimeline.slotIndex = num14;
							deformTimeline.attachment = vertexAttachment;
							int num16 = 0;
							foreach (object obj9 in list6)
							{
								Dictionary<string, object> dictionary12 = (Dictionary<string, object>)obj9;
								float[] array;
								if (!dictionary12.ContainsKey("vertices"))
								{
									array = ((!flag) ? vertices : new float[num15]);
								}
								else
								{
									array = new float[num15];
									int @int = SkeletonJson.GetInt(dictionary12, "offset", 0);
									float[] floatArray = SkeletonJson.GetFloatArray(dictionary12, "vertices", 1f);
									Array.Copy(floatArray, 0, array, @int, floatArray.Length);
									if (scale != 1f)
									{
										int i = @int;
										int num17 = i + floatArray.Length;
										while (i < num17)
										{
											array[i] *= scale;
											i++;
										}
									}
									if (!flag)
									{
										for (int j = 0; j < num15; j++)
										{
											array[j] += vertices[j];
										}
									}
								}
								deformTimeline.SetFrame(num16, (float)dictionary12["time"], array);
								SkeletonJson.ReadCurve(dictionary12, deformTimeline, num16);
								num16++;
							}
							exposedList.Add(deformTimeline);
							num = Math.Max(num, deformTimeline.frames[deformTimeline.FrameCount - 1]);
						}
					}
				}
			}
			if (map.ContainsKey("drawOrder") || map.ContainsKey("draworder"))
			{
				List<object> list7 = (List<object>)map[(!map.ContainsKey("drawOrder")) ? "draworder" : "drawOrder"];
				DrawOrderTimeline drawOrderTimeline = new DrawOrderTimeline(list7.Count);
				int count = skeletonData.slots.Count;
				int num18 = 0;
				foreach (object obj10 in list7)
				{
					Dictionary<string, object> dictionary13 = (Dictionary<string, object>)obj10;
					int[] array2 = null;
					if (dictionary13.ContainsKey("offsets"))
					{
						array2 = new int[count];
						for (int k = count - 1; k >= 0; k--)
						{
							array2[k] = -1;
						}
						List<object> list8 = (List<object>)dictionary13["offsets"];
						int[] array3 = new int[count - list8.Count];
						int l = 0;
						int num19 = 0;
						foreach (object obj11 in list8)
						{
							Dictionary<string, object> dictionary14 = (Dictionary<string, object>)obj11;
							int num20 = skeletonData.FindSlotIndex((string)dictionary14["slot"]);
							if (num20 == -1)
							{
								throw new Exception("Slot not found: " + dictionary14["slot"]);
							}
							while (l != num20)
							{
								array3[num19++] = l++;
							}
							int num21 = l + (int)((float)dictionary14["offset"]);
							array2[num21] = l++;
						}
						while (l < count)
						{
							array3[num19++] = l++;
						}
						for (int m = count - 1; m >= 0; m--)
						{
							if (array2[m] == -1)
							{
								array2[m] = array3[--num19];
							}
						}
					}
					drawOrderTimeline.SetFrame(num18++, (float)dictionary13["time"], array2);
				}
				exposedList.Add(drawOrderTimeline);
				num = Math.Max(num, drawOrderTimeline.frames[drawOrderTimeline.FrameCount - 1]);
			}
			if (map.ContainsKey("events"))
			{
				List<object> list9 = (List<object>)map["events"];
				EventTimeline eventTimeline = new EventTimeline(list9.Count);
				int num22 = 0;
				foreach (object obj12 in list9)
				{
					Dictionary<string, object> dictionary15 = (Dictionary<string, object>)obj12;
					EventData eventData = skeletonData.FindEvent((string)dictionary15["name"]);
					if (eventData == null)
					{
						throw new Exception("Event not found: " + dictionary15["name"]);
					}
					Event @event = new Event((float)dictionary15["time"], eventData);
					@event.Int = SkeletonJson.GetInt(dictionary15, "int", eventData.Int);
					@event.Float = SkeletonJson.GetFloat(dictionary15, "float", eventData.Float);
					@event.String = SkeletonJson.GetString(dictionary15, "string", eventData.String);
					eventTimeline.SetFrame(num22++, @event);
				}
				exposedList.Add(eventTimeline);
				num = Math.Max(num, eventTimeline.frames[eventTimeline.FrameCount - 1]);
			}
			exposedList.TrimExcess();
			skeletonData.animations.Add(new Animation(name, exposedList, num));
		}

		private static void ReadCurve(Dictionary<string, object> valueMap, CurveTimeline timeline, int frameIndex)
		{
			if (!valueMap.ContainsKey("curve"))
			{
				return;
			}
			object obj = valueMap["curve"];
			if (obj.Equals("stepped"))
			{
				timeline.SetStepped(frameIndex);
			}
			else
			{
				List<object> list = obj as List<object>;
				if (list != null)
				{
					timeline.SetCurve(frameIndex, (float)list[0], (float)list[1], (float)list[2], (float)list[3]);
				}
			}
		}

		private static float[] GetFloatArray(Dictionary<string, object> map, string name, float scale)
		{
			List<object> list = (List<object>)map[name];
			float[] array = new float[list.Count];
			if (scale == 1f)
			{
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					array[i] = (float)list[i];
					i++;
				}
			}
			else
			{
				int j = 0;
				int count2 = list.Count;
				while (j < count2)
				{
					array[j] = (float)list[j] * scale;
					j++;
				}
			}
			return array;
		}

		private static int[] GetIntArray(Dictionary<string, object> map, string name)
		{
			List<object> list = (List<object>)map[name];
			int[] array = new int[list.Count];
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				array[i] = (int)((float)list[i]);
				i++;
			}
			return array;
		}

		private static float GetFloat(Dictionary<string, object> map, string name, float defaultValue)
		{
			if (!map.ContainsKey(name))
			{
				return defaultValue;
			}
			return (float)map[name];
		}

		private static int GetInt(Dictionary<string, object> map, string name, int defaultValue)
		{
			if (!map.ContainsKey(name))
			{
				return defaultValue;
			}
			return (int)((float)map[name]);
		}

		private static bool GetBoolean(Dictionary<string, object> map, string name, bool defaultValue)
		{
			if (!map.ContainsKey(name))
			{
				return defaultValue;
			}
			return (bool)map[name];
		}

		private static string GetString(Dictionary<string, object> map, string name, string defaultValue)
		{
			if (!map.ContainsKey(name))
			{
				return defaultValue;
			}
			return (string)map[name];
		}

		private static float ToColor(string hexString, int colorIndex)
		{
			if (hexString.Length != 8)
			{
				throw new ArgumentException("Color hexidecimal length must be 8, recieved: " + hexString, "hexString");
			}
			return (float)Convert.ToInt32(hexString.Substring(colorIndex * 2, 2), 16) / 255f;
		}

		private AttachmentLoader attachmentLoader;

		private List<LinkedMesh> linkedMeshes = new List<LinkedMesh>();

		internal class LinkedMesh
		{
			public LinkedMesh(MeshAttachment mesh, string skin, int slotIndex, string parent)
			{
				this.mesh = mesh;
				this.skin = skin;
				this.slotIndex = slotIndex;
				this.parent = parent;
			}

			internal string parent;

			internal string skin;

			internal int slotIndex;

			internal MeshAttachment mesh;
		}
	}
}
