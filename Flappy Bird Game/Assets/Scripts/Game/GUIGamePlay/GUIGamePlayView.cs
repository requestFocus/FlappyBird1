using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIGamePlayView : View<GUIGamePlayModel, GUIGamePlayController>		// GUIGamePlayView jest głównym widokiem zawierającym widok player PLUS obstacle
{
	[SerializeField] private Text NameScoreGamePlay;
	[SerializeField] private Text ScoreGamePlay;
	[SerializeField] private Text HighScoreGamePlay;
	[SerializeField] private Text AchievementUnlockedGamePlay;

	[SerializeField] private ParticleSystem AchievementParticles;
	[SerializeField] private LevelService LevelService;
	
	public delegate void OnLifeLost();												// niszczy zarówno PlayerView, jak i GUIGamePlayView (ColumnView niszczy się samodzielnie)
	public OnLifeLost OnLifeLostDel;

	private void Start()
	{
		NotUpdatableGUIGamePlayView();

		AchievementUnlockedGamePlay.text = "";
		
		OnLifeLostDel += DeleteGUIGamePlayView;
	}

	private void DeleteGUIGamePlayView()
	{
		Destroy(gameObject);
	}


	public void ShowAchievementParticlesNotification()								// achievement odblokowany - odpal particle i on-screen notyfikacje
	{
		ParticleSystem AchievementParticlesInstance = Instantiate(AchievementParticles);
		AchievementParticlesInstance.Play();

		StartCoroutine(AchievementUnlockedNotification());
	}

	public bool VerifyAchievements(int currentScore)								// sprawdzy czy odblokowano achievement
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



	public void UpdateScoreOnPointEarned()                                
	{
		ScoreGamePlay.text = "score: " + Model.CurrentScore;
	}


	public void NotUpdatableGUIGamePlayView()                                
	{
		ScoreGamePlay.text = "score: " + Model.CurrentScore;					 // tu wyświetli zawsze score = 0, bo w UpdateScoreOnPointEarned() pierwszy update modelu ma miejsce po zdobyciu pierwszego punktu
		NameScoreGamePlay.text = Model.CurrentProfile.PlayerName;
		HighScoreGamePlay.text = "highscore: " + Model.CurrentProfile.HighScore;
	}

	public IEnumerator AchievementUnlockedNotification()						// wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
	}


	public void PointEarned(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Score"))                            // zdobyty punkt
		{
			Model.CurrentScore += 1;
			IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Locked;

			UpdateScoreOnPointEarned();

			if (VerifyAchievements(Model.CurrentScore))
			{
				ShowAchievementParticlesNotification();
			}
		}
	}


	public void LifeLost(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))          // stracone życie
		{
			OnLifeLostDel();
			LevelService.SetState(CurrentGameStateService.GameStates.Summary);
		}
	}
}
