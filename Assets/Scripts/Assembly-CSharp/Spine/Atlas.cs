using System;
using System.Collections.Generic;
using System.IO;

namespace Spine
{
	public class Atlas
	{
		public Atlas(string path, TextureLoader textureLoader)
		{
			using (StreamReader streamReader = new StreamReader(path))
			{
				try
				{
					this.Load(streamReader, Path.GetDirectoryName(path), textureLoader);
				}
				catch (Exception innerException)
				{
					throw new Exception("Error reading atlas file: " + path, innerException);
				}
			}
		}

		public Atlas(TextReader reader, string dir, TextureLoader textureLoader)
		{
			this.Load(reader, dir, textureLoader);
		}

		public Atlas(List<AtlasPage> pages, List<AtlasRegion> regions)
		{
			this.pages = pages;
			this.regions = regions;
			this.textureLoader = null;
		}

		private void Load(TextReader reader, string imagesDir, TextureLoader textureLoader)
		{
			if (textureLoader == null)
			{
				throw new ArgumentNullException("textureLoader cannot be null.");
			}
			this.textureLoader = textureLoader;
			string[] array = new string[4];
			AtlasPage atlasPage = null;
			for (;;)
			{
				string text = reader.ReadLine();
				if (text == null)
				{
					break;
				}
				if (text.Trim().Length == 0)
				{
					atlasPage = null;
				}
				else if (atlasPage == null)
				{
					atlasPage = new AtlasPage();
					atlasPage.name = text;
					if (Atlas.ReadTuple(reader, array) == 2)
					{
						atlasPage.width = int.Parse(array[0]);
						atlasPage.height = int.Parse(array[1]);
						Atlas.ReadTuple(reader, array);
					}
					atlasPage.format = (Format)Enum.Parse(typeof(Format), array[0], false);
					Atlas.ReadTuple(reader, array);
					atlasPage.minFilter = (TextureFilter)Enum.Parse(typeof(TextureFilter), array[0], false);
					atlasPage.magFilter = (TextureFilter)Enum.Parse(typeof(TextureFilter), array[1], false);
					string a = Atlas.ReadValue(reader);
					atlasPage.uWrap = TextureWrap.ClampToEdge;
					atlasPage.vWrap = TextureWrap.ClampToEdge;
					if (a == "x")
					{
						atlasPage.uWrap = TextureWrap.Repeat;
					}
					else if (a == "y")
					{
						atlasPage.vWrap = TextureWrap.Repeat;
					}
					else if (a == "xy")
					{
						atlasPage.uWrap = (atlasPage.vWrap = TextureWrap.Repeat);
					}
					textureLoader.Load(atlasPage, Path.Combine(imagesDir, text));
					this.pages.Add(atlasPage);
				}
				else
				{
					AtlasRegion atlasRegion = new AtlasRegion();
					atlasRegion.name = text;
					atlasRegion.page = atlasPage;
					atlasRegion.rotate = bool.Parse(Atlas.ReadValue(reader));
					Atlas.ReadTuple(reader, array);
					int num = int.Parse(array[0]);
					int num2 = int.Parse(array[1]);
					Atlas.ReadTuple(reader, array);
					int num3 = int.Parse(array[0]);
					int num4 = int.Parse(array[1]);
					atlasRegion.u = (float)num / (float)atlasPage.width;
					atlasRegion.v = (float)num2 / (float)atlasPage.height;
					if (atlasRegion.rotate)
					{
						atlasRegion.u2 = (float)(num + num4) / (float)atlasPage.width;
						atlasRegion.v2 = (float)(num2 + num3) / (float)atlasPage.height;
					}
					else
					{
						atlasRegion.u2 = (float)(num + num3) / (float)atlasPage.width;
						atlasRegion.v2 = (float)(num2 + num4) / (float)atlasPage.height;
					}
					atlasRegion.x = num;
					atlasRegion.y = num2;
					atlasRegion.width = Math.Abs(num3);
					atlasRegion.height = Math.Abs(num4);
					if (Atlas.ReadTuple(reader, array) == 4)
					{
						atlasRegion.splits = new int[]
						{
							int.Parse(array[0]),
							int.Parse(array[1]),
							int.Parse(array[2]),
							int.Parse(array[3])
						};
						if (Atlas.ReadTuple(reader, array) == 4)
						{
							atlasRegion.pads = new int[]
							{
								int.Parse(array[0]),
								int.Parse(array[1]),
								int.Parse(array[2]),
								int.Parse(array[3])
							};
							Atlas.ReadTuple(reader, array);
						}
					}
					atlasRegion.originalWidth = int.Parse(array[0]);
					atlasRegion.originalHeight = int.Parse(array[1]);
					Atlas.ReadTuple(reader, array);
					atlasRegion.offsetX = (float)int.Parse(array[0]);
					atlasRegion.offsetY = (float)int.Parse(array[1]);
					atlasRegion.index = int.Parse(Atlas.ReadValue(reader));
					this.regions.Add(atlasRegion);
				}
			}
		}

		private static string ReadValue(TextReader reader)
		{
			string text = reader.ReadLine();
			int num = text.IndexOf(':');
			if (num == -1)
			{
				throw new Exception("Invalid line: " + text);
			}
			return text.Substring(num + 1).Trim();
		}

		private static int ReadTuple(TextReader reader, string[] tuple)
		{
			string text = reader.ReadLine();
			int num = text.IndexOf(':');
			if (num == -1)
			{
				throw new Exception("Invalid line: " + text);
			}
			int i = 0;
			int num2 = num + 1;
			while (i < 3)
			{
				int num3 = text.IndexOf(',', num2);
				if (num3 == -1)
				{
					break;
				}
				tuple[i] = text.Substring(num2, num3 - num2).Trim();
				num2 = num3 + 1;
				i++;
			}
			tuple[i] = text.Substring(num2).Trim();
			return i + 1;
		}

		public void FlipV()
		{
			int i = 0;
			int count = this.regions.Count;
			while (i < count)
			{
				AtlasRegion atlasRegion = this.regions[i];
				atlasRegion.v = 1f - atlasRegion.v;
				atlasRegion.v2 = 1f - atlasRegion.v2;
				i++;
			}
		}

		public AtlasRegion FindRegion(string name)
		{
			int i = 0;
			int count = this.regions.Count;
			while (i < count)
			{
				if (this.regions[i].name == name)
				{
					return this.regions[i];
				}
				i++;
			}
			return null;
		}

		public void Dispose()
		{
			if (this.textureLoader == null)
			{
				return;
			}
			int i = 0;
			int count = this.pages.Count;
			while (i < count)
			{
				this.textureLoader.Unload(this.pages[i].rendererObject);
				i++;
			}
		}

		private List<AtlasPage> pages = new List<AtlasPage>();

		private List<AtlasRegion> regions = new List<AtlasRegion>();

		private TextureLoader textureLoader;
	}
}
