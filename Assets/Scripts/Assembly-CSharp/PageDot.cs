using UnityEngine;

public class PageDot : MonoBehaviour
{
	private void Awake()
	{
		this.m_spriteOn = base.transform.Find("SpriteOn").gameObject;
		this.m_spriteOff = base.transform.Find("SpriteOff").gameObject;
	}

	public void Enable()
	{
		this.m_spriteOn.SetActive(true);
		this.m_spriteOff.SetActive(false);
	}

	public void Disable()
	{
		this.m_spriteOn.SetActive(false);
		this.m_spriteOff.SetActive(true);
	}

	private GameObject m_spriteOn;

	private GameObject m_spriteOff;
}
