using UnityEngine;

public class LevelEndPig : MonoBehaviour
{
	private void Start()
	{
		this.m_blinkAnimationTimer = UnityEngine.Random.Range(this.m_minBlinkAnimationDelay, this.m_maxBlinkAnimationDelay);
	}

	private void Update()
	{
		this.m_blinkAnimationTimer -= Time.deltaTime;
		if (this.m_blinkAnimationTimer <= 0f)
		{
			this.m_blinkAnimationTimer = UnityEngine.Random.Range(this.m_minBlinkAnimationDelay, this.m_maxBlinkAnimationDelay);
			base.GetComponent<SpriteAnimation>().Play("Blink");
		}
	}

	public float m_minBlinkAnimationDelay;

	public float m_maxBlinkAnimationDelay;

	private float m_blinkAnimationTimer;

	private GameObject m_wrench;
}
