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

	[SerializeField] private LevelService LevelService;                 // do wyswietlania aktualnego score'a

	private void Start()
	{
		Time.timeScale = 1;
		AchievementUnlockedGamePlay.text = "";
	}


	private void Update()
	{
		DisplayGUIGamePlayView();

		if (LevelService.TimeForAchievementNotificationCoroutine)
		{
			StartCoroutine(AchievementUnlockedNotification());
		}
	}

	public void DisplayGUIGamePlayView()                                // WIDOK GAMEPLAY
	{
		NameScoreGamePlay.text = Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].PlayerName;
		ScoreGamePlay.text = "score: " + LevelService.CurrentScore;
		HighScoreGamePlay.text = "highscore: " + Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].HighScore;
	}

	public IEnumerator AchievementUnlockedNotification()                // WIDOK GAMEPLAY, wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
		LevelService.TimeForAchievementNotificationCoroutine = false;		// zwolnienie flagi na potrzeby kolejnego ew. achievementu
	}
}
