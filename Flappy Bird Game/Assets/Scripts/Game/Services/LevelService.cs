using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
	[SerializeField] private GameObject ColumnPrefab;

	// Singleton
	//private static LevelService _instance;
	//public static LevelService Instance
	//{
	//	get
	//	{
	//		if (_instance == null)
	//		{
	//			_instance = FindObjectOfType<LevelService>();				// szuka instancji LevelService na scenie - w obecnej postaci znajdzie, bo LevelService istnieje zawsze
	//			if (_instance == null)
	//				_instance = new LevelService();
	//		}
	//		return _instance;
	//	}
	//}
	//private LevelService() { }
	// ===========

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

	public delegate bool OnPointEarned(int score);
	public OnPointEarned OnPointEarnedDel;

	public delegate void OnAchievementEarned();
	public OnAchievementEarned OnAchievementEarnedDel;

	public delegate void OnLifeLost();
	public OnLifeLost OnLifeLostDel;

	public delegate void OnCurrentStateChange();
	public OnCurrentStateChange OnCurrentStateChangeDel;                      // jeśli OnStateChange(SwitchViewInViewManager); to obiekt delegata powinien być prywatny, nie jest używany poza tą klasą

	private void Awake()
	{
		SetState(CurrentGameStateService.GameStates.GamePlay);
	}

	private void Start()
	{
		_timeIntervalForCoroutine = 3.0f;                                     // 3.0f jako wartosc startowa
		StartCoroutine(CreateColumn());                                       //InvokeRepeating("CreateObstacle", 3.0f, 3.0f);
	}


	public void SetState(CurrentGameStateService.GameStates state)
	{
		CurrentGameStateService.CurrentGameState = state;
		OnCurrentStateChangeDel();
	}

	public void PointEarned(Collider2D collision)								
	{
		if (collision.gameObject.CompareTag("Score"))									                    // zdobyty punkt
		{
			CurrentScore += 1;
			if (OnPointEarnedDel(CurrentScore))
			{
				OnAchievementEarnedDel(); 
			}
		}
	}

	public void LifeLost(Collider2D collision)                                      
	{
		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))          // stracone życie
		{
			OnLifeLostDel();
			SetState(CurrentGameStateService.GameStates.Summary);
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
