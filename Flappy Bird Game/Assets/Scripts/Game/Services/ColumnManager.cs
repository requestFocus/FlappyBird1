using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ColumnManager : MonoBehaviour
{
	private ColumnView _column;

	private float _timeIntervalForCoroutine;
	private float _yPosition;

	private const float _intervalStep = 1.3f;
	private const float _startXPosition = 8.0f;
	private const float _minRange = -3.0f;
	private const float _maxRange = 3.0f;

	private int _columnsSoFar;

	private void Start()
	{
		_timeIntervalForCoroutine = 3.0f;                                     // 3.0f jako wartosc startowa
		StartCoroutine(CreateColumn());                                       
	}

	private float CalculateTimeIntervalForObstacles()
	{
		if (_columnsSoFar != 0 && _columnsSoFar % 10 == 0 && _timeIntervalForCoroutine > 1.0f && IntervalAvailabilityStatesService.IntervalLock == IntervalAvailabilityStatesService.IntervalLockStates.Locked)
		{
			_timeIntervalForCoroutine = _timeIntervalForCoroutine - _intervalStep;
		}
		IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Unlocked;
		return _timeIntervalForCoroutine;
	}

	private IEnumerator CreateColumn()
	{
		while (true)
		{
			yield return new WaitForSeconds(CalculateTimeIntervalForObstacles());
			InitializeColumn(_column);
			_columnsSoFar++;
		}
	}

	[Inject]
	private void InitializeColumn(ColumnView column)
	{
		_column = column;
		_yPosition = Random.Range(_minRange, _maxRange);
		_column.transform.position = new Vector3(_startXPosition, _yPosition);
	}
}


// dlaczego obiekt ColumnView powstaje natychmiast, mimo Bind() Lazy()
// dlaczego obiekt ColumnView znika w momencie, kiedy tworzony jest kolejny obiekt ColumnView