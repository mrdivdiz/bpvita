using UnityEngine;

public class RewardIcon : MonoBehaviour
{
	public State ButtonState
	{
		get
		{
			return this.m_buttonState;
		}
	}

	public void Awake()
	{
		this.RefreshButtonImage();
	}

	public RewardIcon SetButtonState(State state)
	{
		this.m_buttonState = state;
		this.RefreshButtonImage();
		return this;
	}

	private void RefreshButtonImage()
	{
        State buttonState = this.m_buttonState;
		if (buttonState != RewardIcon.State.NotAvailable)
		{
			if (buttonState != RewardIcon.State.ClaimNow)
			{
				if (buttonState == RewardIcon.State.Claimed)
				{
					this.disabledSprite.SetActive(true);
					this.claimNowSprite.SetActive(false);
				}
			}
			else
			{
				this.disabledSprite.SetActive(false);
				this.claimNowSprite.SetActive(true);
			}
		}
		else
		{
			this.disabledSprite.SetActive(true);
			this.claimNowSprite.SetActive(false);
		}
	}

	[SerializeField]
	public GameObject disabledSprite;

	[SerializeField]
	public GameObject claimNowSprite;

	private State m_buttonState;

	public enum State
	{
		NotAvailable,
		ClaimNow,
		Claimed
	}
}
