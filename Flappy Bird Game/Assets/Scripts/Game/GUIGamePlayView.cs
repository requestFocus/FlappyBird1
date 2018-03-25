﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIGamePlayView : MonoBehaviour								// GUIGamePlayView jest głównym widokiem zawierającym widok player PLUS obstacle
{
	[SerializeField] private Text NameScoreGamePlay;
	[SerializeField] private Text ScoreGamePlay;
	[SerializeField] private Text HighScoreGamePlay;
	[SerializeField] private Text AchievementUnlockedGamePlay;

	[SerializeField] private LevelService LevelService;					// do wyswietlania aktualnego score'a

	private void Start()
	{
		AchievementUnlockedGamePlay.text = "";
		Time.timeScale = 1;
	}


	public void DisplayGUIGamePlayView()                                // WIDOK GAMEPLAY
	{
		if (Time.timeScale == 1)                                        // jeśli gra trwa
		{
			NameScoreGamePlay.text = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName;
			ScoreGamePlay.text = "score: " + LevelService.CurrentScore;
			HighScoreGamePlay.text = "highscore: " + PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore;
		}
		else if (Time.timeScale == 0)                                   // jeśli gra się zakończyła schowaj elementy UI gameplayu
		{
			NameScoreGamePlay.text = "";
			ScoreGamePlay.text = "";
			HighScoreGamePlay.text = "";
		}
	}

	public IEnumerator AchievementUnlockedNotification()                // WIDOK GAMEPLAY, wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
	}
}
