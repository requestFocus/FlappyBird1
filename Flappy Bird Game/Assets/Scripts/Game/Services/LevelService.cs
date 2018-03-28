using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
	public GameObject ColumnPrefab;
	public GUIGamePlayView GUIGamePlayViewInstance;

	private int _currentScore;
	public int CurrentScore
	{
		get { return _currentScore; }
		set
		{
			_currentScore = value;
			IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Locked;
		}
	}

	private bool _timeForAchievementNotificationCoroutine;
	public bool TimeForAchievementNotificationCoroutine                                                     // czy to czas na coroutine GUIGamePlayView "New achievement"?
	{
		get { return _timeForAchievementNotificationCoroutine; }
		set { _timeForAchievementNotificationCoroutine = value; }
	}

	private float _timeIntervalForCoroutine;
	private float _yPosition;

	private const float _intervalStep = 0.3f;
	private const float _startXPosition = 8.0f;
	private const float _minRange = -3.0f;
	private const float _maxRange = 3.0f;

	private void Start()
	{
		_timeIntervalForCoroutine = 3.0f;                                            // 3.0f jako wartosc startowa
		StartCoroutine(CreateColumn());                                               //InvokeRepeating("CreateObstacle", 3.0f, 3.0f);

		GUIGamePlayViewInstance.Model = new GUIGamePlayModel()
		{
			PlayersProfilesLoadedToModel = PlayersProfiles.Instance
		};
	}


	

	public void PointEarned(Collider2D collision)								
	{
		if (collision.gameObject.CompareTag("Score"))									                    // zdobyty punkt
		{
			CurrentScore += 1;
		}
	}



	public void LifeLost(Collider2D collision)                                      
	{
		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))          // stracone życie
		{
			CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.Summary;
		}
	}



	public bool AchievementToUnlock()                                     		// weryfikuje i przyznaje achievementy, musi miec dane z modelu
	{
		if (CurrentScore == 10)
		{
			if (!GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.ListOfProfiles[GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10)										// nie ma jeszcze achievementu
			{
				GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.ListOfProfiles[GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10 = true;
				TimeForAchievementNotificationCoroutine = true;											// uruchom coroutine GUIGamePlayView
				return true;
			}
		}
		if (CurrentScore == 25)
		{
			if (!GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.ListOfProfiles[GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25)										 // nie ma jeszcze achievementu
			{
				GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.ListOfProfiles[GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25 = true;	
				TimeForAchievementNotificationCoroutine = true;								             // uruchom coroutine GUIGamePlayView
				return true;
			}
		}
		if (CurrentScore == 50)
		{
			if (!GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.ListOfProfiles[GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50)										 // nie ma jeszcze achievementu
			{
				GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.ListOfProfiles[GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50 = true;
				TimeForAchievementNotificationCoroutine = true;								             // uruchom coroutine GUIGamePlayView
				return true;
			}
		}
		return false;                                                                                    // brak achievementu do odblokowania, już posiada wszystko, co się należy
	}



	public float CalculateTimeIntervalForObstacles()                    // COLUMN SERVICE	
	{
		if (CurrentScore != 0 && CurrentScore % 10 == 0 && _timeIntervalForCoroutine > 1.0f && IntervalAvailabilityStatesService.IntervalLock == IntervalAvailabilityStatesService.IntervalLockStates.Locked)
		{
			_timeIntervalForCoroutine = _timeIntervalForCoroutine - _intervalStep;
		}
		IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Unlocked;
		return _timeIntervalForCoroutine;
	}



	public IEnumerator CreateColumn()                                       // COLUMN SERVICE	
	{
		while (true)
		{
			yield return new WaitForSeconds(CalculateTimeIntervalForObstacles());
			Instantiate(ColumnPrefab);
			InitializeColumn(ColumnPrefab);
		}
	}



	public void InitializeColumn(GameObject column)                                 // COLUMN SERVICE	
	{
		_yPosition = Random.Range(_minRange, _maxRange);
		column.transform.position = new Vector3(_startXPosition, _yPosition);
	}
}
