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

	[SerializeField] private ParticleSystem AchievementParticles;
	[SerializeField] private LevelService LevelService;

	private void Start()
	{
		LevelService.CurrentScore = 0;
		Time.timeScale = 1;
		AchievementUnlockedGamePlay.text = "";

		LevelService.OnAchievementEarnedDel = ShowAchievementParticlesNotification;
		LevelService.OnPointEarnedDel = VerifyAchievements;

		LevelService.OnLifeLostDel += DeleteGUIGamePlayView;
	}

	private void Update()
	{
		DisplayGUIGamePlayView();
	}

	private void DeleteGUIGamePlayView()
	{
		Destroy(gameObject);
	}


	public void ShowAchievementParticlesNotification()						// achievement odblokowany - odpal particle i on-screen notyfikacje
	{
		ParticleSystem AchievementParticlesInstance = Instantiate(AchievementParticles);
		AchievementParticlesInstance.Play();

		StartCoroutine(AchievementUnlockedNotification());
	}

	public bool VerifyAchievements(int currentScore)						// sprawdzy czy odblokowano achievement
	{
		if (currentScore == 2 && !Model.CurrentProfile.Complete10)
		{
			Controller.AssignAchievementComplete10();
			return true;
		}

		if (currentScore == 25 && !Model.CurrentProfile.Complete25)
		{
			Controller.AssignAchievementComplete25();
			return true;
		}

		if (currentScore == 50 && !Model.CurrentProfile.Complete50)
		{
			Controller.AssignAchievementComplete50();
			return true;
		}

		return false;
	}



	public void DisplayGUIGamePlayView()                                // WIDOK GAMEPLAY
	{
		NameScoreGamePlay.text = Model.CurrentProfile.PlayerName;
		ScoreGamePlay.text = "score: " + LevelService.CurrentScore;
		HighScoreGamePlay.text = "highscore: " + Model.CurrentProfile.HighScore;
	}



	public IEnumerator AchievementUnlockedNotification()                // WIDOK GAMEPLAY, wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
	}
}
