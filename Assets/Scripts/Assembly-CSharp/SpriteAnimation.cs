using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class SpriteAnimation : MonoBehaviour
{
	private void OnEnable()
	{
		if (this.m_AutoPlay && !string.IsNullOrEmpty(this.m_AutoPlayName))
		{
			this.Play(this.m_AutoPlayName);
		}
	}

	public List<Animation> GetAnimations()
	{
		return this.m_animations;
	}

	public Animation GetAnimation(string name)
	{
		for (int i = 0; i < this.m_animations.Count; i++)
		{
			if (this.m_animations[i].name == name)
			{
				return this.m_animations[i];
			}
		}
		return null;
	}

	public void CopyFrom(SpriteAnimation source)
	{
		this.m_animations = new List<Animation>(source.m_animations);
		this.m_childAnimations = new List<SpriteAnimation>(source.m_childAnimations);
		this.InitializeAnimations(Singleton<RuntimeSpriteDatabase>.Instance);
	}

	public void Play(string name)
	{
		if (!this.m_initialized)
		{
			this.InitializeAnimations(Singleton<RuntimeSpriteDatabase>.Instance);
		}
		this.m_nextAnimation = null;
		for (int i = 0; i < this.m_animations.Count; i++)
		{
			if (this.m_animations[i].name == name)
			{
				this.m_nextAnimation = this.m_animations[i];
				break;
			}
		}
		if (this.m_nextAnimation == null && this.m_animations.Count > 0)
		{
			this.m_nextAnimation = this.m_animations[0];
		}
		if (this.m_currentAnimation == null && this.m_nextAnimation != null)
		{
			this.PlayImmediately(this.m_nextAnimation);
		}
	}

	private void PlayImmediately(Animation animation)
	{
		if (!this.m_initialized)
		{
			this.InitializeAnimations(Singleton<RuntimeSpriteDatabase>.Instance);
		}
		this.m_currentAnimation = animation;
		this.m_nextAnimation = null;
		this.m_timer = 0f;
		this.m_frame = 0;
		this.m_meshFilter.sharedMesh = this.m_currentAnimation.frames[this.m_frame].mesh;
		for (int i = 0; i < this.m_childAnimations.Count; i++)
		{
			this.m_childAnimations[i].PlayImmediately(animation.name);
		}
		if (this.onPlay != null)
		{
			this.onPlay(animation.name);
		}
	}

	private void PlayImmediately(string name)
	{
		this.m_currentAnimation = null;
		this.Play(name);
	}

	public List<Animation> Animations
	{
		get
		{
			return this.m_animations;
		}
		set
		{
			this.m_animations = value;
		}
	}

	public void InitializeAnimations(RuntimeSpriteDatabase db)
	{
		this.m_timer = 0f;
		this.m_frame = 0;
		this.m_sprite = base.GetComponent<global::Sprite>();
		this.m_meshFilter = base.GetComponent<MeshFilter>();
		string id = this.m_sprite.Id;
		foreach (Animation animation in this.m_animations)
		{
			float num = 0f;
			foreach (FrameTiming frameTiming in animation.frames)
			{
				num += frameTiming.time;
				frameTiming.endTime = num;
				SpriteData data = db.Find(frameTiming.id);
				this.m_sprite.SelectSprite(data, true);
				frameTiming.mesh = this.m_sprite.GetComponent<MeshFilter>().sharedMesh;
			}
		}
		this.m_sprite.SelectSprite(db.Find(id), true);
		this.m_initialized = true;
	}

	private void Awake()
	{
		if (!this.m_initialized)
		{
			this.m_sprite = base.GetComponent<global::Sprite>();
			this.m_meshFilter = base.GetComponent<MeshFilter>();
			this.m_timer = 0f;
			this.m_frame = 0;
			this.InitializeAnimations(Singleton<RuntimeSpriteDatabase>.Instance);
		}
	}

	private void Update()
	{
		if (this.m_currentAnimation != null)
		{
			this.m_timer += Time.deltaTime;
			if (this.m_timer >= this.m_currentAnimation.frames[this.m_frame].endTime)
			{
				if (this.m_frame >= this.m_currentAnimation.frames.Count - 1)
				{
					if (this.m_nextAnimation != null)
					{
						this.PlayImmediately(this.m_nextAnimation);
					}
					else if (this.m_currentAnimation.loop)
					{
						this.m_frame = 0;
						this.m_timer = 0f;
						this.m_meshFilter.sharedMesh = this.m_currentAnimation.frames[this.m_frame].mesh;
					}
				}
				else
				{
					this.m_frame++;
					this.m_meshFilter.sharedMesh = this.m_currentAnimation.frames[this.m_frame].mesh;
				}
			}
		}
	}

	public OnPlay onPlay;

	[SerializeField]
	private List<Animation> m_animations = new List<Animation>();

	[SerializeField]
	private List<SpriteAnimation> m_childAnimations;

	[SerializeField]
	private bool m_AutoPlay;

	[SerializeField]
	private string m_AutoPlayName;

	[SerializeField]
	private bool m_useTestKeys;

	private Sprite m_sprite;

	private float m_timer;

	private int m_frame;

	private Animation m_currentAnimation;

	private Animation m_nextAnimation;

	private MeshFilter m_meshFilter;

	private bool m_initialized;

	public delegate void OnPlay(string name);

	[Serializable]
	public class Animation
	{
		public Animation(string name)
		{
			this.name = name;
			this.frames = new List<FrameTiming>();
		}

		public Animation()
		{
			this.name = string.Empty;
			this.frames = new List<FrameTiming>();
		}

		public string name;

		public bool loop;

		public List<FrameTiming> frames;
	}

	[Serializable]
	public class FrameTiming
	{
		public FrameTiming(string id, float time, Rect uvRect)
		{
			this.id = id;
			this.time = time;
			this.timeText = this.time.ToString();
			this.uv = new Vector2[4];
			this.uv[0].x = uvRect.x;
			this.uv[0].y = uvRect.y;
			this.uv[1].x = uvRect.x;
			this.uv[1].y = uvRect.y + uvRect.height;
			this.uv[2].x = uvRect.x + uvRect.width;
			this.uv[2].y = uvRect.y + uvRect.height;
			this.uv[3].x = uvRect.x + uvRect.width;
			this.uv[3].y = uvRect.y;
		}

		public string id;

		public float time = 0.2f;

		[NonSerialized]
		public float endTime;

		[NonSerialized]
		public Vector2[] uv;

		[NonSerialized]
		public string timeText;

		[NonSerialized]
		public Mesh mesh;
	}
}
