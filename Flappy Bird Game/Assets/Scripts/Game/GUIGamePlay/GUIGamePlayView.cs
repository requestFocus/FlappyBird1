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
	//[SerializeField] private LevelService LevelService;                 // do wyswietlania aktualnego score'a

	private void Start()
	{
		LevelService.Instance.CurrentScore = 0;
		Time.timeScale = 1;
		AchievementUnlockedGamePlay.text = "";

		LevelService.Instance.VerifyAchievementDel = OnPointEarned;
		LevelService.Instance.ParticlesAndNotificationDel = OnAchievementEarned;
	}

	private void Update()
	{
		DisplayGUIGamePlayView();
	}


	public void OnAchievementEarned()						// achievement odblokowany - odpal particle i on-screen notyfikacje
	{
		ParticleSystem AchievementParticlesInstance = Instantiate(AchievementParticles);
		AchievementParticlesInstance.Play();

		StartCoroutine(AchievementUnlockedNotification());
	}

	public bool OnPointEarned(int currentScore)				// sprawdzy czy odblokowano achievement
	{
		if (currentScore == 10 && !Model.CurrentProfile.Complete10)
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
		ScoreGamePlay.text = "score: " + LevelService.Instance.CurrentScore;
		HighScoreGamePlay.text = "highscore: " + Model.CurrentProfile.HighScore;
	}



	public IEnumerator AchievementUnlockedNotification()                // WIDOK GAMEPLAY, wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
	}
}
