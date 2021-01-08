using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsUtility : WPFMonoBehaviour
{
	private void Start()
	{
		float dpi = Screen.dpi;
		if (dpi < 1f)
		{
			this.m_buttonHeight = (float)Screen.height * 0.166666672f;
			this.m_buttonWidth = (float)Screen.width * 0.3125f;
		}
		else
		{
			float num = (float)Screen.width / dpi * 0.5f;
			this.rowItems = Mathf.Clamp((int)num, 3, 10);
			this.m_buttonWidth = (float)Screen.width * (1f / (1.1f * (float)this.rowItems));
			float value = (float)Screen.height / dpi;
			this.m_buttonHeight = (float)Screen.height * (1f / Mathf.Clamp(value, 3f, 10f));
		}
		string text = "sir";
		if (!string.IsNullOrEmpty(SystemInfo.deviceName))
		{
			text = SystemInfo.deviceName;
		}
		if (text.Length > 10)
		{
			text = "\n" + text;
		}
		this.textMesh.text = "Jolly good day, " + text;
	}

	private void DrawButton(string label, Action onClick)
	{
		if (this.currentButtonIndex == 0 || this.currentButtonIndex % this.rowItems == 0)
		{
			if (this.currentButtonIndex != 0)
			{
				GUILayout.EndHorizontal();
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		}
		if (GUILayout.Button(label, new GUILayoutOption[]
		{
			GUILayout.Width(this.m_buttonWidth),
			GUILayout.Height(this.m_buttonHeight)
		}) && onClick != null)
		{
			onClick();
		}
		this.currentButtonIndex++;
	}

	private void BeginGrid()
	{
		this.currentButtonIndex = 0;
	}

	private void EndGrid()
	{
		GUILayout.EndHorizontal();
	}

	private void OnGUI()
	{
		if (!this.skinInitialized)
		{
			this.cheatSkin = GUI.skin;
			float dpi = Screen.dpi;
			if (dpi > 1f)
			{
				this.cheatSkin.label.fontSize = Mathf.FloorToInt(0.1f * dpi + 2f);
				this.cheatSkin.button.fontSize = Mathf.FloorToInt(0.1f * dpi + 2f);
			}
			else
			{
				this.cheatSkin.label.fontSize = Mathf.FloorToInt(15f);
				this.cheatSkin.button.fontSize = Mathf.FloorToInt(15f);
			}
			this.cheatSkin.button.wordWrap = true;
			GUI.skin.verticalScrollbar.fixedWidth = (float)Screen.width * 0.05f;
			GUI.skin.verticalScrollbarThumb.fixedWidth = (float)Screen.width * 0.05f;
			this.skinInitialized = true;
		}
		this.scrollbarPosition = GUILayout.BeginScrollView(this.scrollbarPosition, new GUILayoutOption[]
		{
			GUILayout.Width((float)Screen.width),
			GUILayout.Height((float)Screen.height - (float)Screen.height * 0.1f)
		});
		this.BeginGrid();
		int gameModeIndex = UserSettings.GetInt("game_mode", 0);
		if (gameModeIndex >= 0 && gameModeIndex < CheatsUtility.gameModeNames.Count)
		{
			this.DrawButton("Toggle game mode:\n" + CheatsUtility.gameModeNames[gameModeIndex], delegate
			{
				gameModeIndex++;
				if (gameModeIndex >= CheatsUtility.gameModeNames.Count)
				{
					gameModeIndex = 0;
				}
				if (gameModeIndex == 0)
				{
					UserSettings.DeleteKey("game_mode");
				}
				else
				{
					UserSettings.SetInt("game_mode", gameModeIndex);
				}
			});
		}
		this.DrawButton("Reset progress", delegate
		{
			GameProgress.DeleteAll();
			GameProgress.InitializeGameProgressData();
			GameProgress.Save();
			UserSettings.DeleteAll();
			UserSettings.Save();
			if (Singleton<DailyChallenge>.IsInstantiated() && Singleton<DailyChallenge>.Instance.Initialized)
			{
				Singleton<DailyChallenge>.Instance.ForceNewChallenge();
			}
		});
		this.DrawButton("1-star all levels", delegate
		{
			foreach (Episode episode in WPFMonoBehaviour.gameData.m_episodeLevels)
			{
				for (int i = 0; i < episode.LevelInfos.Count; i++)
				{
					this.SetStarsCompletion(episode.LevelInfos[i], 1);
				}
			}
		});
		this.DrawButton("3-stars all but one", delegate
		{
			foreach (Episode episode in WPFMonoBehaviour.gameData.m_episodeLevels)
			{
				int num = UnityEngine.Random.Range(0, episode.LevelInfos.Count - 3);
				for (int i = 0; i < episode.LevelInfos.Count - 2; i++)
				{
					if (i != num)
					{
						this.SetStarsCompletion(episode.LevelInfos[i], 3);
					}
				}
			}
		});
		this.DrawButton("3-stars all", delegate
		{
			foreach (Episode episode in WPFMonoBehaviour.gameData.m_episodeLevels)
			{
				for (int i = 0; i < episode.LevelInfos.Count; i++)
				{
					this.SetStarsCompletion(episode.LevelInfos[i], 3);
				}
			}
		});
		this.DrawButton("Sandbox all starboxes", delegate
		{
			foreach (SandboxLevels.LevelData levelData in WPFMonoBehaviour.gameData.m_sandboxLevels.Levels)
			{
				for (int i = 0; i < levelData.m_starBoxCount; i++)
				{
					if (i < 10)
					{
						GameProgress.AddSandboxStar(levelData.SceneName, "StarBox0" + i, false);
					}
					else
					{
						GameProgress.AddSandboxStar(levelData.SceneName, "StarBox" + i, false);
					}
				}
			}
		});
		this.DrawButton("Unlimited Sandbox Parts", delegate
		{
			IEnumerator enumerator = Enum.GetValues(typeof(BasePart.PartType)).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					BasePart.PartType partType = (BasePart.PartType)obj;
					if (partType != BasePart.PartType.Unknown && partType != BasePart.PartType.ObsoleteWheel && partType != BasePart.PartType.JetEngine)
					{
						int sandboxPartCount = GameProgress.GetSandboxPartCount(partType);
						GameProgress.AddSandboxParts(partType, 99 - sandboxPartCount, false);
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		});
		if (Application.targetFrameRate == 60)
		{
			this.DrawButton("Set low target FPS", delegate
			{
				Application.targetFrameRate = 25;
			});
		}
		else
		{
			this.DrawButton("Set default target FPS", delegate
			{
				Application.targetFrameRate = 60;
			});
		}
		this.DrawButton("Unlock all levels", delegate
		{
			GameProgress.SetBool("UnlockAllLevels", true, GameProgress.Location.Local);
		});
		this.DrawButton("Restore IAPs", delegate
		{
			Singleton<IapManager>.Instance.RestorePurchasedItems();
		});
		this.DrawButton("Reset IAPs", delegate
		{
			GameProgress.SetBool("ResetIAPs", true, GameProgress.Location.Local);
		});
		this.DrawButton("Add 10 Autobuilds", delegate
		{
			GameProgress.AddBluePrints(10);
		});
		this.DrawButton("Add Wooden crate", delegate
		{
			GameProgress.AddLootcrate(LootCrateType.Wood, 1);
		});
		this.DrawButton("Add Metal crate", delegate
		{
			GameProgress.AddLootcrate(LootCrateType.Metal, 1);
		});
		this.DrawButton("Add Golden crate", delegate
		{
			GameProgress.AddLootcrate(LootCrateType.Gold, 1);
		});
		this.DrawButton("Add 10 Glue, Magnet, Turbo and NightVision", delegate
		{
			GameProgress.AddSuperGlue(10);
			GameProgress.AddSuperMagnet(10);
			GameProgress.AddTurboCharge(10);
			GameProgress.AddNightVision(10);
		});
		this.DrawButton("Unlock all sandboxes", delegate
		{
			GameProgress.UnlockButton("EpisodeButtonSandbox");
			foreach (SandboxLevels.LevelData levelData in WPFMonoBehaviour.gameData.m_sandboxLevels.Levels)
			{
				if (!(levelData.m_identifier == "S-F") && !(levelData.m_identifier == "S-M"))
				{
					GameProgress.SetSandboxUnlocked(levelData.m_identifier, true);
				}
			}
		});
		this.DrawButton("Unlock Field of Dreams", delegate
		{
			GameProgress.SetSandboxUnlocked("S-F", true);
		});
		this.DrawButton("Unlock Little Pig Adventure", delegate
		{
			GameProgress.SetSandboxUnlocked("S-M", true);
		});
		this.DrawButton("Unlock iOS Full version", delegate
		{
			GameProgress.SetFullVersionUnlocked(true);
		});
		this.DrawButton("Mimic 1.8.0 install version. Game needs to be restarted.", delegate
		{
			GameProgress.SetString("InstallVersion", "1.8.0", GameProgress.Location.Local);
			GameProgress.DeleteKey("LastKnownVersion", GameProgress.Location.Local);
		});
		this.DrawButton("Unlock & 3-star Race Levels except for last", delegate
		{
			List<RaceLevels.LevelData> levels = WPFMonoBehaviour.gameData.m_raceLevels.Levels;
			for (int i = 0; i < levels.Count - 1; i++)
			{
				GameProgress.SetInt(levels[i].m_identifier + "_stars", 3, GameProgress.Location.Local);
				GameProgress.SetBestTime(levels[i].SceneName, 10f);
				GameProgress.SetRaceLevelUnlocked(levels[i].m_identifier, true);
			}
		});
		this.DrawButton("Add some desserts", delegate
		{
			int count = WPFMonoBehaviour.gameData.m_desserts.Count;
			int num = UnityEngine.Random.Range(1, count);
			for (int i = 0; i < num; i++)
			{
				string name = WPFMonoBehaviour.gameData.m_desserts[UnityEngine.Random.Range(0, count)].name;
				GameProgress.AddDesserts(name, UnityEngine.Random.Range(1, 6));
			}
		});
		this.DrawButton("Enable basic mechanic", delegate
		{
			GameProgress.SetBool("PermanentBlueprint", true, GameProgress.Location.Local);
		});
		this.DrawButton("Test Force Update. You must relaunch the app manually", delegate
		{
			GameProgress.SetInt(CheatsUtility.versionStatusCheat, 3, GameProgress.Location.Local);
		});
		this.DrawButton("Test Optional Update. You must relaunch the app manually", delegate
		{
			GameProgress.SetInt(CheatsUtility.versionStatusCheat, 1, GameProgress.Location.Local);
		});
		this.DrawButton("Unlock All Free Levels", delegate
		{
			GameProgress.SetBool("UnlockAllFreeLevels", true, GameProgress.Location.Local);
		});
		if (Singleton<RewardSystem>.IsInstantiated())
		{
			string text = "Reward Timer Toggle\nReward time / Reset time\n";
			switch (Singleton<RewardSystem>.Instance.GetTimerMode())
			{
				case 0:
					text += "24h / 48h";
					break;
				case 1:
					text += "15m / 30m";
					break;
				case 2:
					text += "5m / 15m";
					break;
				case 3:
					text += "1m / 1m 15s";
					break;
				case 4:
					text += "5s / 10s";
					break;
			}
			this.DrawButton(text, delegate
			{
				Singleton<RewardSystem>.Instance.ChangeTimerMode();
			});
		}
		this.DrawButton("Reset snout intro", delegate
		{
			GameProgress.SetInt("show_count_snout_intro", 0, GameProgress.Location.Local);
		});
		this.DrawButton("Add 1000 snout coins", delegate
		{
			GameProgress.AddSnoutCoins(1000);
		});
		this.DrawButton("Add 100 scrap", delegate
		{
			GameProgress.AddScrap(100);
		});
		this.DrawButton("Unlock all custom parts", delegate
		{
			this.UnlockParts(BasePart.PartTier.Common);
			this.UnlockParts(BasePart.PartTier.Rare);
			this.UnlockParts(BasePart.PartTier.Epic);
			this.UnlockParts(BasePart.PartTier.Legendary);
		});
		this.DrawButton("Unlock all Common parts", delegate
		{
			this.UnlockParts(BasePart.PartTier.Common);
		});
		this.DrawButton("Unlock all Rare parts", delegate
		{
			this.UnlockParts(BasePart.PartTier.Rare);
		});
		this.DrawButton("Unlock all Epic parts", delegate
		{
			this.UnlockParts(BasePart.PartTier.Epic);
		});
		this.DrawButton("Unlock all Legendary parts", delegate
		{
			this.UnlockParts(BasePart.PartTier.Legendary);
		});
		this.DrawButton("Unlock all craftable items", delegate
		{
			this.UnlockParts(BasePart.PartTier.Common, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable);
			this.UnlockParts(BasePart.PartTier.Rare, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable);
			this.UnlockParts(BasePart.PartTier.Epic, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable);
			this.UnlockParts(BasePart.PartTier.Legendary, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable);
		});
		this.DrawButton("Reset Workshop Tutorial", delegate
		{
			GameProgress.DeleteKey("Workshop_Tutorial", GameProgress.Location.Local);
		});
		this.DrawButton("Reset Crate Craze popup", delegate
		{
			GameProgress.SetBool("CrateCrazeSale_shown", false, GameProgress.Location.Local);
		});
		bool processPurchases = GameProgress.GetBool("Process_purchases", true, GameProgress.Location.Local, null);
		this.DrawButton((!processPurchases) ? "Don't process purchases" : "Do process purchases", delegate
		{
			GameProgress.SetBool("Process_purchases", !processPurchases, GameProgress.Location.Local);
		});
		this.DrawButton("CRASH CLIENT", delegate
		{
			string text2 = null;
			text2 = text2.ToString();
		});
		this.DrawButton("Force Garbage Collection", delegate
		{
			GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
		});
		bool fastNotifications = GameProgress.GetBool("fast_notifications", false, GameProgress.Location.Local, null);
		this.DrawButton((!fastNotifications) ? "Use faster notification schedule" : "Use realtime notification schedule", delegate
		{
			GameProgress.SetBool("fast_notifications", !fastNotifications, GameProgress.Location.Local);
		});
		if (GameProgress.HasKey("notification_clicked", GameProgress.Location.Local, null))
		{
			this.DrawButton("Clicked notification:\n" + GameProgress.GetString("notification_clicked", "null", GameProgress.Location.Local, null), null);
		}
		this.DrawButton("Clear PlayerPrefs", delegate
		{
			PlayerPrefs.DeleteAll();
		});
		this.DrawButton("Get all but one customizations", delegate
		{
			for (int i = 1; i < 4; i++)
			{
				List<BasePart> allTierParts = CustomizationManager.GetAllTierParts((BasePart.PartTier)i, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable | CustomizationManager.PartFlags.Rewardable);
				for (int j = 0; j < allTierParts.Count - 1; j++)
				{
					CustomizationManager.UnlockPart(allTierParts[j], "Cheat");
				}
			}
		});
		this.DrawButton("Reset level to 1", delegate
		{
			GameProgress.SetInt("player_level", 1, GameProgress.Location.Local);
			GameProgress.SetInt("player_experience", 0, GameProgress.Location.Local);
			GameProgress.SetInt("player_pending_experience", -1, GameProgress.Location.Local);
		});
		this.DrawButton("Set level to 5", delegate
		{
			GameProgress.SetInt("player_level", 5, GameProgress.Location.Local);
			GameProgress.SetInt("player_experience", 0, GameProgress.Location.Local);
			GameProgress.SetInt("player_pending_experience", -1, GameProgress.Location.Local);
		});
		this.DrawButton("Force local game configuration '" + GameProgress.GetBool("ForceLocalGameConfiguration", false, GameProgress.Location.Local, null) + "' (requires restart)", delegate
		{
		});
		if (GameProgress.HasKey("cup_advance_cheat", GameProgress.Location.Local, null))
		{
			this.DrawButton(string.Concat(new object[]
			{
				"Current cup:\n",
				CakeRaceMenu.GetCurrentLeaderboardCup().ToString(),
				"\nNext cup:\n",
				(PlayFabLeaderboard.Leaderboard)GameProgress.GetInt("cup_advance_cheat", 1, GameProgress.Location.Local, null)
			}), delegate
			{
			});
			int rankCheat = GameProgress.GetInt("cup_rank_cheat", 0, GameProgress.Location.Local, null);
			this.DrawButton((!GameProgress.HasKey("cup_rank_cheat", GameProgress.Location.Local, null)) ? "Enable rank cheat" : ("Current Rank:\n" + rankCheat.ToString() + "\nLower rank?"), delegate
			{
				switch (rankCheat)
				{
					case 1:
					case 2:
						break;
					case 3:
						rankCheat = 5;
						goto IL_E6;
					default:
						if (rankCheat == 50)
						{
							rankCheat = 100;
							goto IL_E6;
						}
						if (rankCheat == 100)
						{
							rankCheat = 250;
							goto IL_E6;
						}
						if (rankCheat == 250)
						{
							rankCheat = 500;
							goto IL_E6;
						}
						if (rankCheat != 500)
						{
							rankCheat = 1;
							goto IL_E6;
						}
						break;
					case 5:
						rankCheat = 10;
						goto IL_E6;
					case 10:
						rankCheat = 50;
						goto IL_E6;
				}
				rankCheat++;
				IL_E6:
				GameProgress.SetInt("cup_rank_cheat", rankCheat, GameProgress.Location.Local);
			});
		}
		else
		{
			this.DrawButton("Current cup:\n" + CakeRaceMenu.GetCurrentLeaderboardCup().ToString() + "\nAdvance to next Cup", delegate
			{
				int value = (int)(1 + CakeRaceMenu.GetCurrentLeaderboardCup());
				value = Mathf.Clamp(value, (int)PlayFabLeaderboard.LowestCup(), (int)PlayFabLeaderboard.HighestCup());
				GameProgress.SetInt("cup_advance_cheat", value, GameProgress.Location.Local);
				if (GameProgress.HasKey("cup_rank_cheat", GameProgress.Location.Local, null))
				{
					GameProgress.DeleteKey("cup_rank_cheat", GameProgress.Location.Local);
				}
			});
		}
		this.DrawButton("Reset cup cheats", delegate
		{
			if (GameProgress.HasKey("cup_advance_cheat", GameProgress.Location.Local, null))
			{
				GameProgress.DeleteKey("cup_advance_cheat", GameProgress.Location.Local);
			}
			if (GameProgress.HasKey("cup_rank_cheat", GameProgress.Location.Local, null))
			{
				GameProgress.DeleteKey("cup_rank_cheat", GameProgress.Location.Local);
			}
			GameProgress.SetInt("cake_race_current_cup", CakeRaceMenu.GetCupIndexFromPlayerLevel(), GameProgress.Location.Local);
		});
		int leaderboardTestAmount = GameProgress.GetInt("cheat_leaderboard_test", -1, GameProgress.Location.Local, null);
		if (leaderboardTestAmount < 0)
		{
			this.DrawButton("Generate test leaderboard", delegate
			{
				GameProgress.SetInt("cheat_leaderboard_test", 0, GameProgress.Location.Local);
			});
		}
		else
		{
			this.DrawButton("Test leaderboard amount:\n" + leaderboardTestAmount.ToString(), delegate
			{
				switch (leaderboardTestAmount)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
						break;
					case 5:
						leaderboardTestAmount = 8;
						goto IL_1D7;
					default:
						switch (leaderboardTestAmount)
						{
							case 500:
							case 501:
							case 502:
								break;
							default:
								if (leaderboardTestAmount == 25)
								{
									leaderboardTestAmount = 50;
									goto IL_1D7;
								}
								if (leaderboardTestAmount == 50)
								{
									leaderboardTestAmount = 75;
									goto IL_1D7;
								}
								if (leaderboardTestAmount == 75)
								{
									leaderboardTestAmount = 100;
									goto IL_1D7;
								}
								if (leaderboardTestAmount == 100)
								{
									leaderboardTestAmount = 175;
									goto IL_1D7;
								}
								if (leaderboardTestAmount == 175)
								{
									leaderboardTestAmount = 250;
									goto IL_1D7;
								}
								if (leaderboardTestAmount == 250)
								{
									leaderboardTestAmount = 425;
									goto IL_1D7;
								}
								if (leaderboardTestAmount != 425)
								{
									leaderboardTestAmount = 0;
									goto IL_1D7;
								}
								leaderboardTestAmount = 500;
								goto IL_1D7;
						}
						break;
					case 8:
						leaderboardTestAmount = 10;
						goto IL_1D7;
					case 10:
						leaderboardTestAmount = 25;
						goto IL_1D7;
				}
				leaderboardTestAmount++;
				IL_1D7:
				GameProgress.SetInt("cheat_leaderboard_test", leaderboardTestAmount, GameProgress.Location.Local);
			});
			int leaderboardRankCheat = GameProgress.GetInt("cheat_leaderboard_test_local_rank", -1, GameProgress.Location.Local, null);
			this.DrawButton("Cheat player rank: " + (leaderboardRankCheat + 1), delegate
			{
				switch (leaderboardRankCheat + 1)
				{
					case 0:
						leaderboardRankCheat = 0;
						break;
					case 1:
						leaderboardRankCheat = 1;
						break;
					case 2:
						leaderboardRankCheat = 2;
						break;
					case 3:
						leaderboardRankCheat = 3;
						break;
					case 4:
						leaderboardRankCheat = 4;
						break;
					case 5:
						leaderboardRankCheat = 9;
						break;
					default:
						if (leaderboardRankCheat != 24)
						{
							if (leaderboardRankCheat != 49)
							{
								if (leaderboardRankCheat != 149)
								{
									if (leaderboardRankCheat != 499)
									{
										if (leaderboardRankCheat != 999)
										{
											if (leaderboardRankCheat != 9999)
											{
												if (leaderboardRankCheat == 99999)
												{
													leaderboardRankCheat = -1;
												}
											}
											else
											{
												leaderboardRankCheat = 99999;
											}
										}
										else
										{
											leaderboardRankCheat = 9999;
										}
									}
									else
									{
										leaderboardRankCheat = 999;
									}
								}
								else
								{
									leaderboardRankCheat = 499;
								}
							}
							else
							{
								leaderboardRankCheat = 149;
							}
						}
						else
						{
							leaderboardRankCheat = 49;
						}
						break;
					case 10:
						leaderboardRankCheat = 24;
						break;
				}
				GameProgress.SetInt("cheat_leaderboard_test_local_rank", leaderboardRankCheat, GameProgress.Location.Local);
			});
			this.DrawButton("Clear test leaderboard", delegate
			{
				GameProgress.DeleteKey("cheat_leaderboard_test", GameProgress.Location.Local);
				GameProgress.DeleteKey("cheat_leaderboard_test_local_rank", GameProgress.Location.Local);
			});
		}
		this.DrawButton("Reset alien machine", delegate
		{
			if (GameProgress.HasKey("AlienCraftingMachineShown", GameProgress.Location.Local, null))
			{
				GameProgress.DeleteKey("AlienCraftingMachineShown", GameProgress.Location.Local);
			}
		});
		this.DrawButton("Reset Cake Race unlock", delegate
		{
			if (GameProgress.HasKey("CakeRaceUnlockShown", GameProgress.Location.Local, null))
			{
				GameProgress.SetBool("CakeRaceUnlockShown", false, GameProgress.Location.Local);
			}
			if (GameProgress.HasKey("UnlockShown_CakeRaceButton", GameProgress.Location.Local, null))
			{
				GameProgress.SetBool("UnlockShown_CakeRaceButton", false, GameProgress.Location.Local);
			}
		});
		this.DrawButton("Skip cake race tutorial", delegate
		{
			int @int = GameProgress.GetInt("cake_race_total_wins", 0, GameProgress.Location.Local, null);
			if (@int < 7)
			{
				GameProgress.SetInt("cake_race_total_wins", 7, GameProgress.Location.Local);
			}
		});
		this.EndGrid();
		GUILayout.EndScrollView();
		GUI.Label(new Rect((float)Screen.width * 0.9f, (float)Screen.height * 0.93f, (float)Screen.width * 0.1f, (float)Screen.height * 0.1f), string.Concat(new string[]
		{
			"Debug \n(v",
			Singleton<BuildCustomizationLoader>.Instance.ApplicationVersion,
			" - ",
			Singleton<BuildCustomizationLoader>.Instance.SVNRevisionNumber,
			")"
		}));
		if (GUI.Button(new Rect((float)Screen.width * 0.2f, (float)Screen.height * 0.92f, (float)Screen.width * 0.6f, (float)Screen.height * 0.08f), "Back to Main Menu"))
		{
			Singleton<GameManager>.Instance.LoadMainMenu(false);
		}
		GUI.skin = null;
	}

	private void UnlockParts(BasePart.PartTier tier)
	{
		List<BasePart> allTierParts = CustomizationManager.GetAllTierParts(tier, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable | CustomizationManager.PartFlags.Rewardable);
		if (allTierParts == null || allTierParts.Count == 0)
		{
			return;
		}
		for (int i = 0; i < allTierParts.Count; i++)
		{
			CustomizationManager.UnlockPart(allTierParts[i], "Cheat");
		}
	}

	private void UnlockParts(BasePart.PartTier tier, CustomizationManager.PartFlags flags)
	{
		List<BasePart> allTierParts = CustomizationManager.GetAllTierParts(tier, flags);
		if (allTierParts == null || allTierParts.Count == 0)
		{
			return;
		}
		for (int i = 0; i < allTierParts.Count; i++)
		{
			CustomizationManager.UnlockPart(allTierParts[i], "Cheat");
		}
	}

	private void SetStarsCompletion(EpisodeLevelInfo level, int starCount)
	{
		int num = Mathf.Clamp(starCount, 0, 3);
		GameProgress.SetInt(level.sceneName + "_stars", num, GameProgress.Location.Local);
		GameProgress.SetLevelCompleted(level.sceneName);
		if (num > 0)
		{
			GameProgress.SetChallengeCompleted(level.sceneName, 0, true, true);
		}
		if (num > 1)
		{
			GameProgress.SetChallengeCompleted(level.sceneName, 1, true, true);
		}
		if (num > 2)
		{
			GameProgress.SetChallengeCompleted(level.sceneName, 2, true, true);
		}
	}

	private void OnDeviceRegistered(bool result)
	{
		if (result)
		{
			GameProgress.SetBool("TestDeviceRegistered", true, GameProgress.Location.Local);
		}
		this.m_isRegisteringDevice = false;
	}

	private void OnDeviceUnregistered(bool result)
	{
		if (result)
		{
			GameProgress.SetBool("TestDeviceRegistered", false, GameProgress.Location.Local);
		}
		this.m_isRegisteringDevice = false;
	}

	[SerializeField]
	private TextMesh textMesh;

	private float m_buttonHeight;

	private float m_buttonWidth;

	private bool m_isRegisteringDevice;

	private GUISkin cheatSkin;

	private bool skinInitialized;

	private Vector2 scrollbarPosition = Vector2.zero;

	private int rowItems = 3;

	public static string versionStatusCheat = "cheatMimicOlderVersion";

	private static List<string> gameModeNames = new List<string>
	{
		"None",
		"Cake Race\nPreview Mode"
	};

	private int currentButtonIndex;
}
