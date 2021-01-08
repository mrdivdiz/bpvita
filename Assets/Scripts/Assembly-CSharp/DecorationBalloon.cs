using UnityEngine;

public class DecorationBalloon : WPFMonoBehaviour
{
	private void Start()
	{
		this.m_rope = base.gameObject.AddComponent<RopeVisualization>();
		this.m_rope.m_stringMaterial = this.m_stringMaterial;
		this.m_rope.m_pos1Anchor = Vector3.down * 0.5f + 1.1f * Vector3.forward;
		if (this.m_anchor == null)
		{
			this.m_anchor = new GameObject("Anchor")
			{
				transform = 
				{
					parent = base.transform,
					localPosition = Vector3.down * 2.5f
				}
			}.transform;
		}
		this.m_rope.m_pos2Transform = this.m_anchor;
		Vector3 pos2Anchor = this.m_anchor.transform.InverseTransformPoint(base.transform.position);
		pos2Anchor.y = 0f;
		this.m_rope.m_pos2Anchor = pos2Anchor;
	}

	private void Update()
	{
		if (WPFMonoBehaviour.mainCamera == null)
		{
			return;
		}
		Vector3 position = Vector3.zero;
		bool flag = false;
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began)
			{
				position = touch.position;
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		Ray ray = WPFMonoBehaviour.mainCamera.ScreenPointToRay(position);
		int layerMask = 1 << LayerMask.NameToLayer("Default");
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit, 3.40282347E+38f, layerMask) && raycastHit.transform == base.transform)
		{
			this.Pop();
		}
	}

	[ContextMenu("Pop")]
	public void Pop()
	{
		AudioSource balloonPop = WPFMonoBehaviour.gameData.commonAudioCollection.balloonPop;
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(balloonPop, WPFMonoBehaviour.hudCamera.transform);
		ParticleSystem component = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_ballonParticles).GetComponent<ParticleSystem>();
		component.transform.position = base.transform.position;
		LayerHelper.SetLayer(component.gameObject, base.gameObject.layer, true);
		component.Play();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	[SerializeField]
	protected Material m_stringMaterial;

	[SerializeField]
	protected Transform m_anchor;

	protected RopeVisualization m_rope;
}
