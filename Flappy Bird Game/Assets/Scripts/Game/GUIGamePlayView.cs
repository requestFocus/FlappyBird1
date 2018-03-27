using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIGamePlayView : View<GUIGamePlayModel, GUIGamePlayController>								// GUIGamePlayView jest głównym widokiem zawierającym widok player PLUS obstacle
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


	private void Update()
	{
		DisplayGUIGamePlayView();

		if (LevelService.AchievementToUnlock())
		{
			StartCoroutine(AchievementUnlockedNotification());
		}
	}

	public void DisplayGUIGamePlayView()                                // WIDOK GAMEPLAY
	{
		NameScoreGamePlay.text = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName;
		ScoreGamePlay.text = "score: " + LevelService.CurrentScore;
		HighScoreGamePlay.text = "highscore: " + PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore;
	}

	public IEnumerator AchievementUnlockedNotification()                // WIDOK GAMEPLAY, wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
	}
}
