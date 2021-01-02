using UnityEngine;

public class PigMechanic : MonoBehaviour
{
	private void Start()
	{
		this.m_wrenchAnimationTimer = UnityEngine.Random.Range(this.m_minWrenchAnimationDelay, this.m_minWrenchAnimationDelay);
		this.m_blinkAnimationTimer = UnityEngine.Random.Range(this.m_minBlinkAnimationDelay, this.m_maxBlinkAnimationDelay);
		this.m_pig = base.transform.Find("Pig").gameObject;
		this.m_blinkAnimation = this.m_pig.GetComponent<SpriteAnimation>();
		this.m_wrench = base.transform.Find("Wrench").gameObject;
	}

	public void SetTime(float time)
	{
		this.m_wrench.GetComponent<Animation>()["PigMechanicWrench"].time = time;
		this.m_pig.GetComponent<Animation>()["PigMechanic"].time = time;
	}

	public void Play()
	{
		this.m_wrench.GetComponent<Animation>().Play();
		this.m_pig.GetComponent<Animation>().Play();
	}

	private void Update()
	{
		this.m_wrenchAnimationTimer -= Time.deltaTime;
		this.m_blinkAnimationTimer -= Time.deltaTime;
		if (this.m_wrenchAnimationTimer <= 0f)
		{
			this.m_wrench.GetComponent<Animation>().Play();
			this.m_pig.GetComponent<Animation>().Play();
			this.m_wrenchAnimationTimer = UnityEngine.Random.Range(this.m_minWrenchAnimationDelay, this.m_minWrenchAnimationDelay);
		}
		if (this.m_blinkAnimationTimer <= 0f)
		{
			this.m_blinkAnimationTimer = UnityEngine.Random.Range(this.m_minBlinkAnimationDelay, this.m_maxBlinkAnimationDelay);
			this.m_blinkAnimation.Play("Blink");
		}
	}

	public float m_minWrenchAnimationDelay;

	public float m_maxWrenchAnimationDelay;

	public float m_minBlinkAnimationDelay;

	public float m_maxBlinkAnimationDelay;

	private float m_wrenchAnimationTimer;

	private float m_blinkAnimationTimer;

	private GameObject m_pig;

	private SpriteAnimation m_blinkAnimation;

	private GameObject m_wrench;
}
