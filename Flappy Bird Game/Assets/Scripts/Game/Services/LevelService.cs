using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
	[SerializeField] private GameObject ColumnPrefab;

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
	public ParticlesAndNotification ParticlesAndNotificationDelegate;

	public delegate bool VerifyAchievement(int score);
	public VerifyAchievement VerifyAchievementDelegate;

	private void Start()
	{
		_timeIntervalForCoroutine = 3.0f;                                            // 3.0f jako wartosc startowa
		StartCoroutine(CreateColumn());                                               //InvokeRepeating("CreateObstacle", 3.0f, 3.0f);
	}


	

	public void PointEarned(Collider2D collision)								
	{
		if (collision.gameObject.CompareTag("Score"))									                    // zdobyty punkt
		{
			CurrentScore += 1;
			if (VerifyAchievementDelegate(CurrentScore))
			{
				ParticlesAndNotificationDelegate();
			}
		}
	}



	public void LifeLost(Collider2D collision)                                      
	{
		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))          // stracone życie
		{
			CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.Summary;
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
