using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GUIGamePlayView : View<GUIGamePlayModel, GUIGamePlayController>		// GUIGamePlayView jest głównym widokiem zawierającym widok player PLUS obstacle
{
	[SerializeField] private Text NameScoreGamePlay;
	[SerializeField] private Text ScoreGamePlay;
	[SerializeField] private Text HighScoreGamePlay;
	[SerializeField] private Text AchievementUnlockedGamePlay;
	[SerializeField] private ParticleSystem AchievementParticles;

	public delegate void OnLifeLost();												// niszczy zarówno PlayerView, jak i GUIGamePlayView (ColumnView niszczy się samodzielnie)
	public OnLifeLost OnLifeLostDel;

	[Inject]
	public CurrentPlayerData _currentPlayerData;

	private void Start()
	{
		NotUpdatableGUIGamePlayView();

		AchievementUnlockedGamePlay.text = "";
		
		OnLifeLostDel += DeleteGUIGamePlayView;
	}

	public void PointEarned(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Score"))                            // zdobyty punkt
		{
			_currentPlayerData.CurrentScore += 1;
			IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Locked;

			UpdateScoreOnPointEarned();

			if (VerifyAchievements(_currentPlayerData.CurrentScore))
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
			if (_currentPlayerData.CurrentScore > _currentPlayerData.CurrentProfile.HighScore)
				//Controller.SetState(CurrentGameStateService.GameStates.SummarySuccess);
				SetState(CurrentGameStateService.GameStates.SummarySuccess);
			else
				//Controller.SetState(CurrentGameStateService.GameStates.SummaryFailure);
				SetState(CurrentGameStateService.GameStates.SummaryFailure);
		}
	}

	public void SetState(CurrentGameStateService.GameStates state)
	{
		CurrentGameStateService.CurrentGameState = state;
		ViewManager ViewManager = GameObject.FindObjectOfType<ViewManager>();
		ViewManager.SwitchView();
	}


	private void DeleteGUIGamePlayView()
	{
		Destroy(gameObject);
	}


	private void ShowAchievementParticlesNotification()								// achievement odblokowany - odpal particle i on-screen notyfikacje
	{
		ParticleSystem AchievementParticlesInstance = Instantiate(AchievementParticles);
		AchievementParticlesInstance.Play();

		StartCoroutine(AchievementUnlockedNotification());
	}

	private bool VerifyAchievements(int currentScore)								// sprawdzy czy odblokowano achievement
	{
		if (currentScore == 10 && !_currentPlayerData.CurrentProfile.Complete10)
		{
			//Controller.AssignAchievementComplete10();
			AssignAchievementComplete10();
			return true;
		}

		if (currentScore == 25 && !_currentPlayerData.CurrentProfile.Complete25)
		{
			//Controller.AssignAchievementComplete25();
			AssignAchievementComplete25();
			return true;
		}

		if (currentScore == 50 && !_currentPlayerData.CurrentProfile.Complete50)
		{
			//Controller.AssignAchievementComplete50();
			AssignAchievementComplete50();
			return true;
		}

		return false;
	}

	public void AssignAchievementComplete10()
	{
		_currentPlayerData.CurrentProfile.Complete10 = true;
		_currentPlayerData.AchievementIsUnlocked = true;
	}

	public void AssignAchievementComplete25()
	{
		_currentPlayerData.CurrentProfile.Complete25 = true;
		_currentPlayerData.AchievementIsUnlocked = true;
	}

	public void AssignAchievementComplete50()
	{
		_currentPlayerData.CurrentProfile.Complete50 = true;
		_currentPlayerData.AchievementIsUnlocked = true;
	}



	private void UpdateScoreOnPointEarned()                                
	{
		ScoreGamePlay.text = "score: " + _currentPlayerData.CurrentScore;
	}


	private void NotUpdatableGUIGamePlayView()                                
	{
		ScoreGamePlay.text = "score: " + _currentPlayerData.CurrentScore;					 // tu wyświetli zawsze score = 0, bo w UpdateScoreOnPointEarned() pierwszy update modelu ma miejsce po zdobyciu pierwszego punktu
		NameScoreGamePlay.text = _currentPlayerData.CurrentProfile.PlayerName;
		HighScoreGamePlay.text = "highscore: " + _currentPlayerData.CurrentProfile.HighScore;
	}

	private IEnumerator AchievementUnlockedNotification()						// wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
	}
}
