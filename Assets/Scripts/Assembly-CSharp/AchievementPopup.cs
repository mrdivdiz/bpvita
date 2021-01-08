using System.Collections;
using UnityEngine;

public class AchievementPopup : MonoBehaviour
{
	private void Start()
	{
		this.m_popup = base.transform.Find("Popup").gameObject;
		this.m_text = base.transform.Find("Popup/Text").GetComponent<TextMesh>();
		this.m_icon = base.transform.Find("Popup/Icon").GetComponent<Renderer>();
		this.m_sprite = base.transform.Find("Popup/SpriteIcon").GetComponent<SpriteRenderer>();
		this.m_localeText = base.transform.Find("Popup/Text").GetComponent<TextMeshLocale>();
		this.m_popup.transform.position = Vector3.up * 13f;
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public void Show(string achievementId)
	{
		if (this.sprites == null)
		{
			this.sprites = Resources.LoadAll<UnityEngine.Sprite>("Achievements/Achievements_Sheet");
		}
		string spriteId = Singleton<AchievementData>.Instance.AchievementsLimits[achievementId].iconFileName;
        foreach (UnityEngine.Sprite sprite in this.sprites)
        {
            if (sprite.name == spriteId)
            {
                this.m_sprite.sprite = sprite;
                break;
            }
        }
		if (this.m_sprite.sprite == null)
		{
			string path = "Achievements/" + Singleton<AchievementData>.Instance.AchievementsLimits[achievementId].iconFileName;
			this.m_icon.material.mainTexture = (Resources.Load(path, typeof(Texture2D)) as Texture2D);
			this.m_sprite.enabled = false;
			this.m_icon.enabled = true;
		}
		else
		{
			this.m_sprite.enabled = true;
			this.m_icon.enabled = false;
		}
		this.m_text.text = achievementId;
		this.m_localeText.RefreshTranslation(Singleton<Localizer>.Instance.CurrentLocale);
		this.m_popup.GetComponent<Animation>().Play("AchievementPopupEnter");
		base.StartCoroutine(this.UnloadIconAfterAnimation());
	}

	private IEnumerator UnloadIconAfterAnimation()
	{
		while (this.m_popup.GetComponent<Animation>().isPlaying)
		{
			yield return new WaitForSeconds(0.5f);
		}
        Object res = this.m_icon.material.mainTexture;
		this.m_icon.material.mainTexture = null;
		Resources.UnloadAsset(res);
		res = null;
		yield break;
	}

	private IEnumerator Test()
	{
		int i = 0;
		foreach (string key in Singleton<AchievementData>.Instance.AchievementsLimits.Keys)
		{
			i++;
			this.Show(key);
			yield return new WaitForSeconds(3f);
		}
		yield break;
	}

	private GameObject m_popup;

	private Renderer m_icon;

	private TextMesh m_text;

	private TextMeshLocale m_localeText;

	private SpriteRenderer m_sprite;

	private UnityEngine.Sprite[] sprites;
}
