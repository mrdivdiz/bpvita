using UnityEngine;

public class InstantiateOnStart : MonoBehaviour
{
	private void Start()
	{
		if (base.GetComponent<Renderer>())
		{
			base.GetComponent<Renderer>().enabled = this.m_selfRendererEnabled;
		}
		if (this.m_Prefab)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_Prefab, base.transform.position, base.transform.rotation);
			if (this.m_MakeItChild)
			{
				gameObject.transform.parent = base.transform;
			}
		}
	}

	public GameObject m_Prefab;

	public bool m_MakeItChild = true;

	public bool m_selfRendererEnabled = true;
}
