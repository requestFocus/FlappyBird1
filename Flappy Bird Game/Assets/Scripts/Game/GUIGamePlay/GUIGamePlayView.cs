using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GUIGamePlayView : MonoBehaviour 
{
	[SerializeField] private Text _nameScoreGamePlay;
	[SerializeField] private Text _scoreGamePlay;
	[SerializeField] private Text _highScoreGamePlay;
	[SerializeField] private Text _achievementUnlockedGamePlay;
	[SerializeField] private ParticleSystem _achievementParticles;

	public delegate void OnLifeLost();												// niszczy zarówno PlayerView, jak i GUIGamePlayView ORAZ ColumnView
	public OnLifeLost OnLifeLostDel;                                // tworzenie delagata

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

	[Inject]
	private CurrentGameStateService _currentGameStateService;

	[Inject]
	private IntervalAvailabilityStatesService _intervalAvailabilityStatesService;

	private void Start()
	{
		NotUpdatableGUIGamePlayView();

		_achievementUnlockedGamePlay.text = "";
		
		OnLifeLostDel += DeleteGUIGamePlayView;                    
	}

	public void PointEarned(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Score"))                            // zdobyty punkt
		{
			_currentPlayerData.CurrentScore = _currentPlayerData.CurrentScore+ 1;
			_intervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Locked;

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
			OnLifeLostDel();                                             // wywołanie delegata
            if (_currentPlayerData.CurrentScore > _projectData.EntireList[_projectData.CurrentID].HighScore)
            {
                SetState(CurrentGameStateService.GameStates.SummarySuccess);
            }
            else
            {
                SetState(CurrentGameStateService.GameStates.SummaryFailure);
            }
		}
	}


	private void DeleteGUIGamePlayView()
	{
		Destroy(gameObject);
	}


	private void ShowAchievementParticlesNotification()								// achievement odblokowany - odpal particle i on-screen notyfikacje
	{
		ParticleSystem AchievementParticlesInstance = Instantiate(_achievementParticles);
		AchievementParticlesInstance.Play();

		StartCoroutine(AchievementUnlockedNotification());
	}

	private bool VerifyAchievements(int currentScore)								// sprawdzy czy odblokowano achievement
	{
		if (currentScore == 10 && !_projectData.EntireList[_projectData.CurrentID].Complete10)
		{
			AssignAchievementComplete10();
			return true;
		}

		if (currentScore == 25 && !_projectData.EntireList[_projectData.CurrentID].Complete25)
		{
			AssignAchievementComplete25();
			return true;
		}

		if (currentScore == 50 && !_projectData.EntireList[_projectData.CurrentID].Complete50)
		{
			AssignAchievementComplete50();
			return true;
		}

		return false;
	}



	private void UpdateScoreOnPointEarned()                                
	{
		_scoreGamePlay.text = "score: " + _currentPlayerData.CurrentScore;
	}


	private void NotUpdatableGUIGamePlayView()                                
	{
		_scoreGamePlay.text = "score: " + _currentPlayerData.CurrentScore;					 // tu wyświetli zawsze score = 0, bo w UpdateScoreOnPointEarned() pierwszy update modelu ma miejsce po zdobyciu pierwszego punktu
		_nameScoreGamePlay.text = _projectData.EntireList[_projectData.CurrentID].PlayerName;
		_highScoreGamePlay.text = "highscore: " + _projectData.EntireList[_projectData.CurrentID].HighScore;
	}

	private IEnumerator AchievementUnlockedNotification()						// wyswietla info o odblokowaniu achievementu
	{
		_achievementUnlockedGamePlay.text = "New achievement!";
        Color color = _achievementUnlockedGamePlay.color;
        yield return new WaitForSeconds(2);

        for (float i = 1.0f; i >= 0.0f; i -= 0.01f)
        {   
            color.a = i;
            _achievementUnlockedGamePlay.color = color;
            yield return null;
        }

        color.a = 1.0f;
        _achievementUnlockedGamePlay.text = "";
        _achievementUnlockedGamePlay.color = color;
    }


	public void SetState(CurrentGameStateService.GameStates state)
	{
		_currentGameStateService.CurrentGameState = state;
		ViewManager ViewManager = GameObject.FindObjectOfType<ViewManager>();
		ViewManager.SwitchView();
	}

	public void AssignAchievementComplete10()
	{
		_projectData.EntireList[_projectData.CurrentID].Complete10 = true;
		_currentPlayerData.AchievementIsUnlocked = true;
	}

	public void AssignAchievementComplete25()
	{
		_projectData.EntireList[_projectData.CurrentID].Complete25 = true;
		_currentPlayerData.AchievementIsUnlocked = true;
	}

	public void AssignAchievementComplete50()
	{
		_projectData.EntireList[_projectData.CurrentID].Complete50 = true;
		_currentPlayerData.AchievementIsUnlocked = true;
	}
}
