using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
	[SerializeField] private GameObject ColumnPrefab;

	private float _timeIntervalForCoroutine;
	private float _yPosition;

	private const float _intervalStep = 0.3f;
	private const float _startXPosition = 8.0f;
	private const float _minRange = -3.0f;
	private const float _maxRange = 3.0f;

	private int _columnsSoFar;

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

	public float CalculateTimeIntervalForObstacles()						
	{
		if (_columnsSoFar != 0 && _columnsSoFar % 10 == 0 && _timeIntervalForCoroutine > 1.0f && IntervalAvailabilityStatesService.IntervalLock == IntervalAvailabilityStatesService.IntervalLockStates.Locked)
		{
			_timeIntervalForCoroutine = _timeIntervalForCoroutine - _intervalStep;
		}
		IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Unlocked;
		return _timeIntervalForCoroutine;
	}

	public IEnumerator CreateColumn()                                       	
	{
		while (true)
		{
			yield return new WaitForSeconds(CalculateTimeIntervalForObstacles());
			Instantiate(ColumnPrefab);
			InitializeColumn(ColumnPrefab);
			_columnsSoFar++;
		}
	}

	public void InitializeColumn(GameObject column)                                
	{
		_yPosition = Random.Range(_minRange, _maxRange);
		column.transform.position = new Vector3(_startXPosition, _yPosition);
	}
}
