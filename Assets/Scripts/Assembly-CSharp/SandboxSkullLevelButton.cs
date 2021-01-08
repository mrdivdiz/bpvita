using System;
using System.Collections.Generic;
using UnityEngine;

public class SandboxSkullLevelButton : MonoBehaviour
{
	private void Start()
	{
		if (base.transform.parent != null)
		{
			this.m_sandboxSelector = base.transform.parent.GetComponent<SandboxSelector>();
		}
		this.starSet = base.transform.Find("StarSet");
		this.collectSet = base.transform.Find("Set");
		this.m_Limit = 10;
		bool isOdyssey = Singleton<BuildCustomizationLoader>.Instance.IsOdyssey;
		bool flag = false;
		string collectable = string.Empty;
		string arg = string.Empty;
		CollectableType collectableType = this.collectableType;
		if (collectableType != CollectableType.Skull)
		{
			if (collectableType == CollectableType.Statue)
			{
				flag = (GameProgress.SecretStatueCount() >= this.m_Limit || GameProgress.GetSandboxUnlocked(this.m_sandboxIdentifier));
				collectable = "Statues";
				arg = "[statue]";
			}
		}
		else
		{
			flag = (GameProgress.SecretSkullCount() >= this.m_Limit || GameProgress.GetSandboxUnlocked(this.m_sandboxIdentifier));
			collectable = "Skulls";
			arg = "[skull]";
		}
		GameProgress.ButtonUnlockState buttonUnlockState = GameProgress.GetButtonUnlockState("SandboxLevelButton_" + this.m_sandboxIdentifier);
		if (flag && buttonUnlockState == GameProgress.ButtonUnlockState.Locked && base.GetComponent<UnlockSandboxSequence>() == null)
		{
			base.gameObject.AddComponent<UnlockSandboxSequence>();
		}
		if (flag)
		{
			Button component = base.GetComponent<Button>();
			component.MethodToCall.SetMethod(this.m_sandboxSelector.gameObject.GetComponent<SandboxSelector>(), "LoadSandboxLevel", this.m_sandboxIdentifier);
			if (this.collectSet != null)
			{
				this.collectSet.gameObject.SetActive(false);
			}
			if (this.starSet != null)
			{
				this.starSet.gameObject.SetActive(true);
			}
			string str = WPFMonoBehaviour.gameData.m_sandboxLevels.GetLevelData(this.m_sandboxIdentifier).m_starBoxCount.ToString();
			this.m_starsText.text = GameProgress.SandboxStarCount(this.m_sandboxSelector.FindLevelFile(this.m_sandboxIdentifier)).ToString() + "/" + str;
		}
		else
		{
			if (this.starSet != null)
			{
				this.starSet.gameObject.SetActive(false);
			}
			int num = 0;
			CollectableType collectableType2 = this.collectableType;
			if (collectableType2 != CollectableType.Skull)
			{
				if (collectableType2 == CollectableType.Statue)
				{
					num = GameProgress.SecretStatueCount();
				}
			}
			else
			{
				num = GameProgress.SecretSkullCount();
			}
			this.m_Text.text = string.Format("{0} {1}/{2}", arg, num, this.m_Limit);
			this.m_Text.SendMessage("TextUpdated", SendMessageOptions.DontRequireReceiver);
			if (isOdyssey)
			{
				TooltipInfo component2 = base.GetComponent<TooltipInfo>();
				if (component2 != null)
				{
					Button component3 = base.GetComponent<Button>();
					component3.MethodToCall.SetMethod(component2, "Show");
					component3.Lock(false);
				}
			}
			else
			{
				string id = (this.collectableType != CollectableType.Statue) ? "sandbox_unlock_skull_collectable" : "sandbox_unlock_statue_collectable";
				int num2 = Singleton<VirtualCatalogManager>.Instance.GetProductPrice(id);
				if (num2 <= 0)
				{
					num2 = 50;
				}
				int cost = (this.m_Limit - num) * num2;
				this.AddUnlockPopup(base.GetComponent<Button>(), this.m_sandboxIdentifier, collectable, num, this.m_Limit, cost, () => GameProgress.SnoutCoinCount() >= cost);
			}
		}
	}

	private void AddUnlockPopup(Button button, string levelName, string collectable, int collected, int required, int cost, Func<bool> requirements)
	{
		GameData gameData = Singleton<GameManager>.Instance.gameData;
		if (gameData.m_specialSandboxUnlockDialog != null && gameData.m_genericButtonPrefab != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(gameData.m_specialSandboxUnlockDialog);
			SpecialSandboxUnlockDialog dialog = gameObject.GetComponent<SpecialSandboxUnlockDialog>();
			gameObject.transform.position = new Vector3(0f, 0f, -10f);
			button.MethodToCall.SetMethod(dialog, "Open");
			dialog.Type = ((!collectable.Equals("Skulls")) ? SpecialSandboxUnlockDialog.UnlockType.Statue : SpecialSandboxUnlockDialog.UnlockType.Skull);
			dialog.Collected = collected;
			dialog.Required = required;
			dialog.Cost = cost;
			dialog.ShowConfirmEnabled = (() => true);
			dialog.RebuildTexts();
			dialog.Close();
			CompactEpisodeTarget target = base.GetComponent<CompactEpisodeTarget>();
			dialog.SetOnConfirm(delegate
			{
				if (!GameProgress.GetSandboxUnlocked(levelName) && requirements() && GameProgress.UseSnoutCoins(cost))
				{
					GameProgress.SetSandboxUnlocked(levelName, true);
					GameProgress.SetButtonUnlockState("SandboxLevelButton_" + levelName, GameProgress.ButtonUnlockState.Locked);
					target.SetAsLastTarget();
					Singleton<GameManager>.Instance.ReloadCurrentLevel(true);
					EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.DelayedPurchaseSound));
					dialog.Close();
				}
				else if (!requirements() && Singleton<IapManager>.IsInstantiated())
				{
					dialog.Close();
					Singleton<IapManager>.Instance.OpenShopPage(new Action(dialog.Open), "SnoutCoinShop");
				}
				else
				{
					dialog.Close();
				}
			});
		}
		if (this.collectSet != null)
		{
			string text = string.Format("[snout] {0}", cost);
			TextMesh[] componentsInChildren = this.collectSet.GetComponentsInChildren<TextMesh>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].text = text;
				TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren[i]);
			}
		}
	}

	private void DelayedPurchaseSound(LevelLoadedEvent data)
	{
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.DelayedPurchaseSound));
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
	}

	[SerializeField]
	private CollectableType collectableType;

	public string m_sandboxIdentifier;

	[SerializeField]
	private SandboxSelector m_sandboxSelector;

	[SerializeField]
	private TextMesh m_starsText;

	[SerializeField]
	private TextMesh m_Text;

	[SerializeField]
	private int m_Limit;

	private Transform starSet;

	private Transform collectSet;
}
