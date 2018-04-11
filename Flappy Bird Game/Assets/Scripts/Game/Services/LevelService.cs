using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
	[SerializeField] private GameObject ColumnPrefab;
	[SerializeField] private GUIMain GUIMain;

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

	private float _timeIntervalForCoroutine;
	private float _yPosition;

	private const float _intervalStep = 0.3f;
	private const float _startXPosition = 8.0f;
	private const float _minRange = -3.0f;
	private const float _maxRange = 3.0f;

	public delegate void ParticlesAndNotification();
	public ParticlesAndNotification ParticlesAndNotificationDel;

	public delegate bool VerifyAchievement(int score);
	public VerifyAchievement VerifyAchievementDel;

	public delegate void SetState();
	public SetState OnCurrentStateChange;

	private void Start()
	{
		SetGamePlayState();

		_timeIntervalForCoroutine = 3.0f;                                            // 3.0f jako wartosc startowa
		StartCoroutine(CreateColumn());                                               //InvokeRepeating("CreateObstacle", 3.0f, 3.0f);
	}


	public void SetGamePlayState()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		OnCurrentStateChange();
	}

	public void SetSummaryState()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.Summary;
		OnCurrentStateChange();
	}

	public void OnStateChange(SetState callback)
	{
		OnCurrentStateChange = callback;
	}

	//public void SetState(CurrentGameStateService.GameStates state)
	//{
	//	CurrentGameStateService.CurrentGameState = state;
	//}
	

	public void PointEarned(Collider2D collision)								
	{
		if (collision.gameObject.CompareTag("Score"))									                    // zdobyty punkt
		{
			CurrentScore += 1;
			if (VerifyAchievementDel(CurrentScore))
			{
				ParticlesAndNotificationDel();
			}
		}
	}



	public void LifeLost(Collider2D collision)                                      
	{
		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))          // stracone życie
		{
			SetSummaryState();
		}
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
