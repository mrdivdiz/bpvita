using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spine
{
	public class SkeletonBinary
	{
		public SkeletonBinary(params Atlas[] atlasArray) : this(new AtlasAttachmentLoader(atlasArray))
		{
		}

		public SkeletonBinary(AttachmentLoader attachmentLoader)
		{
			if (attachmentLoader == null)
			{
				throw new ArgumentNullException("attachmentLoader");
			}
			this.attachmentLoader = attachmentLoader;
			this.Scale = 1f;
		}

		public float Scale { get; set; }

		public SkeletonData ReadSkeletonData(string path)
		{
			SkeletonData result;
			using (BufferedStream bufferedStream = new BufferedStream(new FileStream(path, FileMode.Open)))
			{
				SkeletonData skeletonData = this.ReadSkeletonData(bufferedStream);
				skeletonData.name = Path.GetFileNameWithoutExtension(path);
				result = skeletonData;
			}
			return result;
		}

		public SkeletonData ReadSkeletonData(Stream input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			float scale = this.Scale;
			SkeletonData skeletonData = new SkeletonData();
			skeletonData.hash = this.ReadString(input);
			if (skeletonData.hash.Length == 0)
			{
				skeletonData.hash = null;
			}
			skeletonData.version = this.ReadString(input);
			if (skeletonData.version.Length == 0)
			{
				skeletonData.version = null;
			}
			skeletonData.width = this.ReadFloat(input);
			skeletonData.height = this.ReadFloat(input);
			bool flag = SkeletonBinary.ReadBoolean(input);
			if (flag)
			{
				skeletonData.imagesPath = this.ReadString(input);
				if (skeletonData.imagesPath.Length == 0)
				{
					skeletonData.imagesPath = null;
				}
			}
			int i = 0;
			int num = SkeletonBinary.ReadVarint(input, true);
			while (i < num)
			{
				string name = this.ReadString(input);
				BoneData parent = (i != 0) ? skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)] : null;
				BoneData boneData = new BoneData(i, name, parent);
				boneData.rotation = this.ReadFloat(input);
				boneData.x = this.ReadFloat(input) * scale;
				boneData.y = this.ReadFloat(input) * scale;
				boneData.scaleX = this.ReadFloat(input);
				boneData.scaleY = this.ReadFloat(input);
				boneData.shearX = this.ReadFloat(input);
				boneData.shearY = this.ReadFloat(input);
				boneData.length = this.ReadFloat(input) * scale;
				boneData.inheritRotation = SkeletonBinary.ReadBoolean(input);
				boneData.inheritScale = SkeletonBinary.ReadBoolean(input);
				if (flag)
				{
					SkeletonBinary.ReadInt(input);
				}
				skeletonData.bones.Add(boneData);
				i++;
			}
			int j = 0;
			int num2 = SkeletonBinary.ReadVarint(input, true);
			while (j < num2)
			{
				string name2 = this.ReadString(input);
				BoneData boneData2 = skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)];
				SlotData slotData = new SlotData(j, name2, boneData2);
				int num3 = SkeletonBinary.ReadInt(input);
				slotData.r = (float)((num3 & 4278190080u) >> 24) / 255f;
				slotData.g = (float)((num3 & 16711680) >> 16) / 255f;
				slotData.b = (float)((num3 & 65280) >> 8) / 255f;
				slotData.a = (float)(num3 & 255) / 255f;
				slotData.attachmentName = this.ReadString(input);
				slotData.blendMode = (BlendMode)SkeletonBinary.ReadVarint(input, true);
				skeletonData.slots.Add(slotData);
				j++;
			}
			int k = 0;
			int num4 = SkeletonBinary.ReadVarint(input, true);
			while (k < num4)
			{
				IkConstraintData ikConstraintData = new IkConstraintData(this.ReadString(input));
				int l = 0;
				int num5 = SkeletonBinary.ReadVarint(input, true);
				while (l < num5)
				{
					ikConstraintData.bones.Add(skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)]);
					l++;
				}
				ikConstraintData.target = skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)];
				ikConstraintData.mix = this.ReadFloat(input);
				ikConstraintData.bendDirection = (int)SkeletonBinary.ReadSByte(input);
				skeletonData.ikConstraints.Add(ikConstraintData);
				k++;
			}
			int m = 0;
			int num6 = SkeletonBinary.ReadVarint(input, true);
			while (m < num6)
			{
				TransformConstraintData transformConstraintData = new TransformConstraintData(this.ReadString(input));
				int n = 0;
				int num7 = SkeletonBinary.ReadVarint(input, true);
				while (n < num7)
				{
					transformConstraintData.bones.Add(skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)]);
					n++;
				}
				transformConstraintData.target = skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)];
				transformConstraintData.offsetRotation = this.ReadFloat(input);
				transformConstraintData.offsetX = this.ReadFloat(input) * scale;
				transformConstraintData.offsetY = this.ReadFloat(input) * scale;
				transformConstraintData.offsetScaleX = this.ReadFloat(input);
				transformConstraintData.offsetScaleY = this.ReadFloat(input);
				transformConstraintData.offsetShearY = this.ReadFloat(input);
				transformConstraintData.rotateMix = this.ReadFloat(input);
				transformConstraintData.translateMix = this.ReadFloat(input);
				transformConstraintData.scaleMix = this.ReadFloat(input);
				transformConstraintData.shearMix = this.ReadFloat(input);
				skeletonData.transformConstraints.Add(transformConstraintData);
				m++;
			}
			int num8 = 0;
			int num9 = SkeletonBinary.ReadVarint(input, true);
			while (num8 < num9)
			{
				PathConstraintData pathConstraintData = new PathConstraintData(this.ReadString(input));
				int num10 = 0;
				int num11 = SkeletonBinary.ReadVarint(input, true);
				while (num10 < num11)
				{
					pathConstraintData.bones.Add(skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)]);
					num10++;
				}
				pathConstraintData.target = skeletonData.slots.Items[SkeletonBinary.ReadVarint(input, true)];
				pathConstraintData.positionMode = (PositionMode)Enum.GetValues(typeof(PositionMode)).GetValue(SkeletonBinary.ReadVarint(input, true));
				pathConstraintData.spacingMode = (SpacingMode)Enum.GetValues(typeof(SpacingMode)).GetValue(SkeletonBinary.ReadVarint(input, true));
				pathConstraintData.rotateMode = (RotateMode)Enum.GetValues(typeof(RotateMode)).GetValue(SkeletonBinary.ReadVarint(input, true));
				pathConstraintData.offsetRotation = this.ReadFloat(input);
				pathConstraintData.position = this.ReadFloat(input);
				if (pathConstraintData.positionMode == PositionMode.Fixed)
				{
					pathConstraintData.position *= scale;
				}
				pathConstraintData.spacing = this.ReadFloat(input);
				if (pathConstraintData.spacingMode == SpacingMode.Length || pathConstraintData.spacingMode == SpacingMode.Fixed)
				{
					pathConstraintData.spacing *= scale;
				}
				pathConstraintData.rotateMix = this.ReadFloat(input);
				pathConstraintData.translateMix = this.ReadFloat(input);
				skeletonData.pathConstraints.Add(pathConstraintData);
				num8++;
			}
			Skin skin = this.ReadSkin(input, "default", flag);
			if (skin != null)
			{
				skeletonData.defaultSkin = skin;
				skeletonData.skins.Add(skin);
			}
			int num12 = 0;
			int num13 = SkeletonBinary.ReadVarint(input, true);
			while (num12 < num13)
			{
				skeletonData.skins.Add(this.ReadSkin(input, this.ReadString(input), flag));
				num12++;
			}
			int num14 = 0;
			int count = this.linkedMeshes.Count;
			while (num14 < count)
			{
				SkeletonJson.LinkedMesh linkedMesh = this.linkedMeshes[num14];
				Skin skin2 = (linkedMesh.skin != null) ? skeletonData.FindSkin(linkedMesh.skin) : skeletonData.DefaultSkin;
				if (skin2 == null)
				{
					throw new Exception("Skin not found: " + linkedMesh.skin);
				}
				Attachment attachment = skin2.GetAttachment(linkedMesh.slotIndex, linkedMesh.parent);
				if (attachment == null)
				{
					throw new Exception("Parent mesh not found: " + linkedMesh.parent);
				}
				linkedMesh.mesh.ParentMesh = (MeshAttachment)attachment;
				linkedMesh.mesh.UpdateUVs();
				num14++;
			}
			this.linkedMeshes.Clear();
			int num15 = 0;
			int num16 = SkeletonBinary.ReadVarint(input, true);
			while (num15 < num16)
			{
				EventData eventData = new EventData(this.ReadString(input));
				eventData.Int = SkeletonBinary.ReadVarint(input, false);
				eventData.Float = this.ReadFloat(input);
				eventData.String = this.ReadString(input);
				skeletonData.events.Add(eventData);
				num15++;
			}
			int num17 = 0;
			int num18 = SkeletonBinary.ReadVarint(input, true);
			while (num17 < num18)
			{
				this.ReadAnimation(this.ReadString(input), input, skeletonData);
				num17++;
			}
			skeletonData.bones.TrimExcess();
			skeletonData.slots.TrimExcess();
			skeletonData.skins.TrimExcess();
			skeletonData.events.TrimExcess();
			skeletonData.animations.TrimExcess();
			skeletonData.ikConstraints.TrimExcess();
			skeletonData.pathConstraints.TrimExcess();
			return skeletonData;
		}

		private Skin ReadSkin(Stream input, string skinName, bool nonessential)
		{
			int num = SkeletonBinary.ReadVarint(input, true);
			if (num == 0)
			{
				return null;
			}
			Skin skin = new Skin(skinName);
			for (int i = 0; i < num; i++)
			{
				int slotIndex = SkeletonBinary.ReadVarint(input, true);
				int j = 0;
				int num2 = SkeletonBinary.ReadVarint(input, true);
				while (j < num2)
				{
					string text = this.ReadString(input);
					skin.AddAttachment(slotIndex, text, this.ReadAttachment(input, skin, slotIndex, text, nonessential));
					j++;
				}
			}
			return skin;
		}

		private Attachment ReadAttachment(Stream input, Skin skin, int slotIndex, string attachmentName, bool nonessential)
		{
			float scale = this.Scale;
			string text = this.ReadString(input);
			if (text == null)
			{
				text = attachmentName;
			}
			switch (input.ReadByte())
			{
			case 0:
			{
				string text2 = this.ReadString(input);
				float rotation = this.ReadFloat(input);
				float num = this.ReadFloat(input);
				float num2 = this.ReadFloat(input);
				float scaleX = this.ReadFloat(input);
				float scaleY = this.ReadFloat(input);
				float num3 = this.ReadFloat(input);
				float num4 = this.ReadFloat(input);
				int num5 = SkeletonBinary.ReadInt(input);
				if (text2 == null)
				{
					text2 = text;
				}
				RegionAttachment regionAttachment = this.attachmentLoader.NewRegionAttachment(skin, text, text2);
				if (regionAttachment == null)
				{
					return null;
				}
				regionAttachment.Path = text2;
				regionAttachment.x = num * scale;
				regionAttachment.y = num2 * scale;
				regionAttachment.scaleX = scaleX;
				regionAttachment.scaleY = scaleY;
				regionAttachment.rotation = rotation;
				regionAttachment.width = num3 * scale;
				regionAttachment.height = num4 * scale;
				regionAttachment.r = (float)((num5 & 4278190080u) >> 24) / 255f;
				regionAttachment.g = (float)((num5 & 16711680) >> 16) / 255f;
				regionAttachment.b = (float)((num5 & 65280) >> 8) / 255f;
				regionAttachment.a = (float)(num5 & 255) / 255f;
				regionAttachment.UpdateOffset();
				return regionAttachment;
			}
			case 1:
			{
				int num6 = SkeletonBinary.ReadVarint(input, true);
                        Vertices vertices = this.ReadVertices(input, num6);
				if (nonessential)
				{
					SkeletonBinary.ReadInt(input);
				}
				BoundingBoxAttachment boundingBoxAttachment = this.attachmentLoader.NewBoundingBoxAttachment(skin, text);
				if (boundingBoxAttachment == null)
				{
					return null;
				}
				boundingBoxAttachment.worldVerticesLength = num6 << 1;
				boundingBoxAttachment.vertices = vertices.vertices;
				boundingBoxAttachment.bones = vertices.bones;
				return boundingBoxAttachment;
			}
			case 2:
			{
				string text3 = this.ReadString(input);
				int num7 = SkeletonBinary.ReadInt(input);
				int num8 = SkeletonBinary.ReadVarint(input, true);
				float[] regionUVs = this.ReadFloatArray(input, num8 << 1, 1f);
				int[] triangles = this.ReadShortArray(input);
                        Vertices vertices2 = this.ReadVertices(input, num8);
				int num9 = SkeletonBinary.ReadVarint(input, true);
				int[] edges = null;
				float num10 = 0f;
				float num11 = 0f;
				if (nonessential)
				{
					edges = this.ReadShortArray(input);
					num10 = this.ReadFloat(input);
					num11 = this.ReadFloat(input);
				}
				if (text3 == null)
				{
					text3 = text;
				}
				MeshAttachment meshAttachment = this.attachmentLoader.NewMeshAttachment(skin, text, text3);
				if (meshAttachment == null)
				{
					return null;
				}
				meshAttachment.Path = text3;
				meshAttachment.r = (float)((num7 & 4278190080u) >> 24) / 255f;
				meshAttachment.g = (float)((num7 & 16711680) >> 16) / 255f;
				meshAttachment.b = (float)((num7 & 65280) >> 8) / 255f;
				meshAttachment.a = (float)(num7 & 255) / 255f;
				meshAttachment.bones = vertices2.bones;
				meshAttachment.vertices = vertices2.vertices;
				meshAttachment.WorldVerticesLength = num8 << 1;
				meshAttachment.triangles = triangles;
				meshAttachment.regionUVs = regionUVs;
				meshAttachment.UpdateUVs();
				meshAttachment.HullLength = num9 << 1;
				if (nonessential)
				{
					meshAttachment.Edges = edges;
					meshAttachment.Width = num10 * scale;
					meshAttachment.Height = num11 * scale;
				}
				return meshAttachment;
			}
			case 3:
			{
				string text4 = this.ReadString(input);
				int num12 = SkeletonBinary.ReadInt(input);
				string skin2 = this.ReadString(input);
				string parent = this.ReadString(input);
				bool inheritDeform = SkeletonBinary.ReadBoolean(input);
				float num13 = 0f;
				float num14 = 0f;
				if (nonessential)
				{
					num13 = this.ReadFloat(input);
					num14 = this.ReadFloat(input);
				}
				if (text4 == null)
				{
					text4 = text;
				}
				MeshAttachment meshAttachment2 = this.attachmentLoader.NewMeshAttachment(skin, text, text4);
				if (meshAttachment2 == null)
				{
					return null;
				}
				meshAttachment2.Path = text4;
				meshAttachment2.r = (float)((num12 & 4278190080u) >> 24) / 255f;
				meshAttachment2.g = (float)((num12 & 16711680) >> 16) / 255f;
				meshAttachment2.b = (float)((num12 & 65280) >> 8) / 255f;
				meshAttachment2.a = (float)(num12 & 255) / 255f;
				meshAttachment2.inheritDeform = inheritDeform;
				if (nonessential)
				{
					meshAttachment2.Width = num13 * scale;
					meshAttachment2.Height = num14 * scale;
				}
				this.linkedMeshes.Add(new SkeletonJson.LinkedMesh(meshAttachment2, skin2, slotIndex, parent));
				return meshAttachment2;
			}
			case 4:
			{
				bool closed = SkeletonBinary.ReadBoolean(input);
				bool constantSpeed = SkeletonBinary.ReadBoolean(input);
				int num15 = SkeletonBinary.ReadVarint(input, true);
                        Vertices vertices3 = this.ReadVertices(input, num15);
				float[] array = new float[num15 / 3];
				int i = 0;
				int num16 = array.Length;
				while (i < num16)
				{
					array[i] = this.ReadFloat(input) * scale;
					i++;
				}
				if (nonessential)
				{
					SkeletonBinary.ReadInt(input);
				}
				PathAttachment pathAttachment = this.attachmentLoader.NewPathAttachment(skin, text);
				if (pathAttachment == null)
				{
					return null;
				}
				pathAttachment.closed = closed;
				pathAttachment.constantSpeed = constantSpeed;
				pathAttachment.worldVerticesLength = num15 << 1;
				pathAttachment.vertices = vertices3.vertices;
				pathAttachment.bones = vertices3.bones;
				pathAttachment.lengths = array;
				return pathAttachment;
			}
			default:
				return null;
			}
		}

		private Vertices ReadVertices(Stream input, int vertexCount)
		{
			float scale = this.Scale;
			int num = vertexCount << 1;
            Vertices vertices = new Vertices();
			if (!SkeletonBinary.ReadBoolean(input))
			{
				vertices.vertices = this.ReadFloatArray(input, num, scale);
				return vertices;
			}
			ExposedList<float> exposedList = new ExposedList<float>(num * 3 * 3);
			ExposedList<int> exposedList2 = new ExposedList<int>(num * 3);
			for (int i = 0; i < vertexCount; i++)
			{
				int num2 = SkeletonBinary.ReadVarint(input, true);
				exposedList2.Add(num2);
				for (int j = 0; j < num2; j++)
				{
					exposedList2.Add(SkeletonBinary.ReadVarint(input, true));
					exposedList.Add(this.ReadFloat(input) * scale);
					exposedList.Add(this.ReadFloat(input) * scale);
					exposedList.Add(this.ReadFloat(input));
				}
			}
			vertices.vertices = exposedList.ToArray();
			vertices.bones = exposedList2.ToArray();
			return vertices;
		}

		private float[] ReadFloatArray(Stream input, int n, float scale)
		{
			float[] array = new float[n];
			if (scale == 1f)
			{
				for (int i = 0; i < n; i++)
				{
					array[i] = this.ReadFloat(input);
				}
			}
			else
			{
				for (int j = 0; j < n; j++)
				{
					array[j] = this.ReadFloat(input) * scale;
				}
			}
			return array;
		}

		private int[] ReadShortArray(Stream input)
		{
			int num = SkeletonBinary.ReadVarint(input, true);
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (input.ReadByte() << 8 | input.ReadByte());
			}
			return array;
		}

		private void ReadAnimation(string name, Stream input, SkeletonData skeletonData)
		{
			ExposedList<Timeline> exposedList = new ExposedList<Timeline>();
			float scale = this.Scale;
			float num = 0f;
			int i = 0;
			int num2 = SkeletonBinary.ReadVarint(input, true);
			while (i < num2)
			{
				int slotIndex = SkeletonBinary.ReadVarint(input, true);
				int j = 0;
				int num3 = SkeletonBinary.ReadVarint(input, true);
				while (j < num3)
				{
					int num4 = input.ReadByte();
					int num5 = SkeletonBinary.ReadVarint(input, true);
					if (num4 != 1)
					{
						if (num4 == 0)
						{
							AttachmentTimeline attachmentTimeline = new AttachmentTimeline(num5);
							attachmentTimeline.slotIndex = slotIndex;
							for (int k = 0; k < num5; k++)
							{
								attachmentTimeline.SetFrame(k, this.ReadFloat(input), this.ReadString(input));
							}
							exposedList.Add(attachmentTimeline);
							num = Math.Max(num, attachmentTimeline.frames[num5 - 1]);
						}
					}
					else
					{
						ColorTimeline colorTimeline = new ColorTimeline(num5);
						colorTimeline.slotIndex = slotIndex;
						for (int l = 0; l < num5; l++)
						{
							float time = this.ReadFloat(input);
							int num6 = SkeletonBinary.ReadInt(input);
							float r = (float)((num6 & 4278190080u) >> 24) / 255f;
							float g = (float)((num6 & 16711680) >> 16) / 255f;
							float b = (float)((num6 & 65280) >> 8) / 255f;
							float a = (float)(num6 & 255) / 255f;
							colorTimeline.SetFrame(l, time, r, g, b, a);
							if (l < num5 - 1)
							{
								this.ReadCurve(input, l, colorTimeline);
							}
						}
						exposedList.Add(colorTimeline);
						num = Math.Max(num, colorTimeline.frames[(colorTimeline.FrameCount - 1) * 5]);
					}
					j++;
				}
				i++;
			}
			int m = 0;
			int num7 = SkeletonBinary.ReadVarint(input, true);
			while (m < num7)
			{
				int boneIndex = SkeletonBinary.ReadVarint(input, true);
				int n = 0;
				int num8 = SkeletonBinary.ReadVarint(input, true);
				while (n < num8)
				{
					int num9 = input.ReadByte();
					int num10 = SkeletonBinary.ReadVarint(input, true);
					switch (num9)
					{
					case 0:
					{
						RotateTimeline rotateTimeline = new RotateTimeline(num10);
						rotateTimeline.boneIndex = boneIndex;
						for (int num11 = 0; num11 < num10; num11++)
						{
							rotateTimeline.SetFrame(num11, this.ReadFloat(input), this.ReadFloat(input));
							if (num11 < num10 - 1)
							{
								this.ReadCurve(input, num11, rotateTimeline);
							}
						}
						exposedList.Add(rotateTimeline);
						num = Math.Max(num, rotateTimeline.frames[(num10 - 1) * 2]);
						break;
					}
					case 1:
					case 2:
					case 3:
					{
						float num12 = 1f;
						TranslateTimeline translateTimeline;
						if (num9 == 2)
						{
							translateTimeline = new ScaleTimeline(num10);
						}
						else if (num9 == 3)
						{
							translateTimeline = new ShearTimeline(num10);
						}
						else
						{
							translateTimeline = new TranslateTimeline(num10);
							num12 = scale;
						}
						translateTimeline.boneIndex = boneIndex;
						for (int num13 = 0; num13 < num10; num13++)
						{
							translateTimeline.SetFrame(num13, this.ReadFloat(input), this.ReadFloat(input) * num12, this.ReadFloat(input) * num12);
							if (num13 < num10 - 1)
							{
								this.ReadCurve(input, num13, translateTimeline);
							}
						}
						exposedList.Add(translateTimeline);
						num = Math.Max(num, translateTimeline.frames[(num10 - 1) * 3]);
						break;
					}
					}
					n++;
				}
				m++;
			}
			int num14 = 0;
			int num15 = SkeletonBinary.ReadVarint(input, true);
			while (num14 < num15)
			{
				int ikConstraintIndex = SkeletonBinary.ReadVarint(input, true);
				int num16 = SkeletonBinary.ReadVarint(input, true);
				IkConstraintTimeline ikConstraintTimeline = new IkConstraintTimeline(num16);
				ikConstraintTimeline.ikConstraintIndex = ikConstraintIndex;
				for (int num17 = 0; num17 < num16; num17++)
				{
					ikConstraintTimeline.SetFrame(num17, this.ReadFloat(input), this.ReadFloat(input), (int)SkeletonBinary.ReadSByte(input));
					if (num17 < num16 - 1)
					{
						this.ReadCurve(input, num17, ikConstraintTimeline);
					}
				}
				exposedList.Add(ikConstraintTimeline);
				num = Math.Max(num, ikConstraintTimeline.frames[(num16 - 1) * 3]);
				num14++;
			}
			int num18 = 0;
			int num19 = SkeletonBinary.ReadVarint(input, true);
			while (num18 < num19)
			{
				int transformConstraintIndex = SkeletonBinary.ReadVarint(input, true);
				int num20 = SkeletonBinary.ReadVarint(input, true);
				TransformConstraintTimeline transformConstraintTimeline = new TransformConstraintTimeline(num20);
				transformConstraintTimeline.transformConstraintIndex = transformConstraintIndex;
				for (int num21 = 0; num21 < num20; num21++)
				{
					transformConstraintTimeline.SetFrame(num21, this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input));
					if (num21 < num20 - 1)
					{
						this.ReadCurve(input, num21, transformConstraintTimeline);
					}
				}
				exposedList.Add(transformConstraintTimeline);
				num = Math.Max(num, transformConstraintTimeline.frames[(num20 - 1) * 5]);
				num18++;
			}
			int num22 = 0;
			int num23 = SkeletonBinary.ReadVarint(input, true);
			while (num22 < num23)
			{
				int num24 = SkeletonBinary.ReadVarint(input, true);
				PathConstraintData pathConstraintData = skeletonData.pathConstraints.Items[num24];
				int num25 = 0;
				int num26 = SkeletonBinary.ReadVarint(input, true);
				while (num25 < num26)
				{
					int num27 = (int)SkeletonBinary.ReadSByte(input);
					int num28 = SkeletonBinary.ReadVarint(input, true);
					if (num27 != 0 && num27 != 1)
					{
						if (num27 == 2)
						{
							PathConstraintMixTimeline pathConstraintMixTimeline = new PathConstraintMixTimeline(num28);
							pathConstraintMixTimeline.pathConstraintIndex = num24;
							for (int num29 = 0; num29 < num28; num29++)
							{
								pathConstraintMixTimeline.SetFrame(num29, this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input));
								if (num29 < num28 - 1)
								{
									this.ReadCurve(input, num29, pathConstraintMixTimeline);
								}
							}
							exposedList.Add(pathConstraintMixTimeline);
							num = Math.Max(num, pathConstraintMixTimeline.frames[(num28 - 1) * 3]);
						}
					}
					else
					{
						float num30 = 1f;
						PathConstraintPositionTimeline pathConstraintPositionTimeline;
						if (num27 == 1)
						{
							pathConstraintPositionTimeline = new PathConstraintSpacingTimeline(num28);
							if (pathConstraintData.spacingMode == SpacingMode.Length || pathConstraintData.spacingMode == SpacingMode.Fixed)
							{
								num30 = scale;
							}
						}
						else
						{
							pathConstraintPositionTimeline = new PathConstraintPositionTimeline(num28);
							if (pathConstraintData.positionMode == PositionMode.Fixed)
							{
								num30 = scale;
							}
						}
						pathConstraintPositionTimeline.pathConstraintIndex = num24;
						for (int num31 = 0; num31 < num28; num31++)
						{
							pathConstraintPositionTimeline.SetFrame(num31, this.ReadFloat(input), this.ReadFloat(input) * num30);
							if (num31 < num28 - 1)
							{
								this.ReadCurve(input, num31, pathConstraintPositionTimeline);
							}
						}
						exposedList.Add(pathConstraintPositionTimeline);
						num = Math.Max(num, pathConstraintPositionTimeline.frames[(num28 - 1) * 2]);
					}
					num25++;
				}
				num22++;
			}
			int num32 = 0;
			int num33 = SkeletonBinary.ReadVarint(input, true);
			while (num32 < num33)
			{
				Skin skin = skeletonData.skins.Items[SkeletonBinary.ReadVarint(input, true)];
				int num34 = 0;
				int num35 = SkeletonBinary.ReadVarint(input, true);
				while (num34 < num35)
				{
					int slotIndex2 = SkeletonBinary.ReadVarint(input, true);
					int num36 = 0;
					int num37 = SkeletonBinary.ReadVarint(input, true);
					while (num36 < num37)
					{
						VertexAttachment vertexAttachment = (VertexAttachment)skin.GetAttachment(slotIndex2, this.ReadString(input));
						bool flag = vertexAttachment.bones != null;
						float[] vertices = vertexAttachment.vertices;
						int num38 = (!flag) ? vertices.Length : (vertices.Length / 3 * 2);
						int num39 = SkeletonBinary.ReadVarint(input, true);
						DeformTimeline deformTimeline = new DeformTimeline(num39);
						deformTimeline.slotIndex = slotIndex2;
						deformTimeline.attachment = vertexAttachment;
						for (int num40 = 0; num40 < num39; num40++)
						{
							float time2 = this.ReadFloat(input);
							int num41 = SkeletonBinary.ReadVarint(input, true);
							float[] array;
							if (num41 == 0)
							{
								array = ((!flag) ? vertices : new float[num38]);
							}
							else
							{
								array = new float[num38];
								int num42 = SkeletonBinary.ReadVarint(input, true);
								num41 += num42;
								if (scale == 1f)
								{
									for (int num43 = num42; num43 < num41; num43++)
									{
										array[num43] = this.ReadFloat(input);
									}
								}
								else
								{
									for (int num44 = num42; num44 < num41; num44++)
									{
										array[num44] = this.ReadFloat(input) * scale;
									}
								}
								if (!flag)
								{
									int num45 = 0;
									int num46 = array.Length;
									while (num45 < num46)
									{
										array[num45] += vertices[num45];
										num45++;
									}
								}
							}
							deformTimeline.SetFrame(num40, time2, array);
							if (num40 < num39 - 1)
							{
								this.ReadCurve(input, num40, deformTimeline);
							}
						}
						exposedList.Add(deformTimeline);
						num = Math.Max(num, deformTimeline.frames[num39 - 1]);
						num36++;
					}
					num34++;
				}
				num32++;
			}
			int num47 = SkeletonBinary.ReadVarint(input, true);
			if (num47 > 0)
			{
				DrawOrderTimeline drawOrderTimeline = new DrawOrderTimeline(num47);
				int count = skeletonData.slots.Count;
				for (int num48 = 0; num48 < num47; num48++)
				{
					float time3 = this.ReadFloat(input);
					int num49 = SkeletonBinary.ReadVarint(input, true);
					int[] array2 = new int[count];
					for (int num50 = count - 1; num50 >= 0; num50--)
					{
						array2[num50] = -1;
					}
					int[] array3 = new int[count - num49];
					int num51 = 0;
					int num52 = 0;
					for (int num53 = 0; num53 < num49; num53++)
					{
						int num54 = SkeletonBinary.ReadVarint(input, true);
						while (num51 != num54)
						{
							array3[num52++] = num51++;
						}
						array2[num51 + SkeletonBinary.ReadVarint(input, true)] = num51++;
					}
					while (num51 < count)
					{
						array3[num52++] = num51++;
					}
					for (int num55 = count - 1; num55 >= 0; num55--)
					{
						if (array2[num55] == -1)
						{
							array2[num55] = array3[--num52];
						}
					}
					drawOrderTimeline.SetFrame(num48, time3, array2);
				}
				exposedList.Add(drawOrderTimeline);
				num = Math.Max(num, drawOrderTimeline.frames[num47 - 1]);
			}
			int num56 = SkeletonBinary.ReadVarint(input, true);
			if (num56 > 0)
			{
				EventTimeline eventTimeline = new EventTimeline(num56);
				for (int num57 = 0; num57 < num56; num57++)
				{
					float time4 = this.ReadFloat(input);
					EventData eventData = skeletonData.events.Items[SkeletonBinary.ReadVarint(input, true)];
					eventTimeline.SetFrame(num57, new Event(time4, eventData)
					{
						Int = SkeletonBinary.ReadVarint(input, false),
						Float = this.ReadFloat(input),
						String = ((!SkeletonBinary.ReadBoolean(input)) ? eventData.String : this.ReadString(input))
					});
				}
				exposedList.Add(eventTimeline);
				num = Math.Max(num, eventTimeline.frames[num56 - 1]);
			}
			exposedList.TrimExcess();
			skeletonData.animations.Add(new Animation(name, exposedList, num));
		}

		private void ReadCurve(Stream input, int frameIndex, CurveTimeline timeline)
		{
			int num = input.ReadByte();
			if (num != 1)
			{
				if (num == 2)
				{
					timeline.SetCurve(frameIndex, this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input));
				}
			}
			else
			{
				timeline.SetStepped(frameIndex);
			}
		}

		private static sbyte ReadSByte(Stream input)
		{
			int num = input.ReadByte();
			if (num == -1)
			{
				throw new EndOfStreamException();
			}
			return (sbyte)num;
		}

		private static bool ReadBoolean(Stream input)
		{
			return input.ReadByte() != 0;
		}

		private float ReadFloat(Stream input)
		{
			this.buffer[3] = (byte)input.ReadByte();
			this.buffer[2] = (byte)input.ReadByte();
			this.buffer[1] = (byte)input.ReadByte();
			this.buffer[0] = (byte)input.ReadByte();
			return BitConverter.ToSingle(this.buffer, 0);
		}

		private static int ReadInt(Stream input)
		{
			return (input.ReadByte() << 24) + (input.ReadByte() << 16) + (input.ReadByte() << 8) + input.ReadByte();
		}

		private static int ReadVarint(Stream input, bool optimizePositive)
		{
			int num = input.ReadByte();
			int num2 = num & 127;
			if ((num & 128) != 0)
			{
				num = input.ReadByte();
				num2 |= (num & 127) << 7;
				if ((num & 128) != 0)
				{
					num = input.ReadByte();
					num2 |= (num & 127) << 14;
					if ((num & 128) != 0)
					{
						num = input.ReadByte();
						num2 |= (num & 127) << 21;
						if ((num & 128) != 0)
						{
							num2 |= (input.ReadByte() & 127) << 28;
						}
					}
				}
			}
			return (!optimizePositive) ? (num2 >> 1 ^ -(num2 & 1)) : num2;
		}

		private string ReadString(Stream input)
		{
			int num = SkeletonBinary.ReadVarint(input, true);
			if (num == 0)
			{
				return null;
			}
			if (num != 1)
			{
				num--;
				byte[] array = this.buffer;
				if (array.Length < num)
				{
					array = new byte[num];
				}
				SkeletonBinary.ReadFully(input, array, 0, num);
				return Encoding.UTF8.GetString(array, 0, num);
			}
			return string.Empty;
		}

		private static void ReadFully(Stream input, byte[] buffer, int offset, int length)
		{
			while (length > 0)
			{
				int num = input.Read(buffer, offset, length);
				if (num <= 0)
				{
					throw new EndOfStreamException();
				}
				offset += num;
				length -= num;
			}
		}

		public const int BONE_ROTATE = 0;

		public const int BONE_TRANSLATE = 1;

		public const int BONE_SCALE = 2;

		public const int BONE_SHEAR = 3;

		public const int SLOT_ATTACHMENT = 0;

		public const int SLOT_COLOR = 1;

		public const int PATH_POSITION = 0;

		public const int PATH_SPACING = 1;

		public const int PATH_MIX = 2;

		public const int CURVE_LINEAR = 0;

		public const int CURVE_STEPPED = 1;

		public const int CURVE_BEZIER = 2;

		private AttachmentLoader attachmentLoader;

		private byte[] buffer = new byte[32];

		private List<SkeletonJson.LinkedMesh> linkedMeshes = new List<SkeletonJson.LinkedMesh>();

		internal class Vertices
		{
			public int[] bones;

			public float[] vertices;
		}
	}
}
