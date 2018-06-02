﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ColumnManager : MonoBehaviour
{
	[Inject]
	private ColumnView _column;					// powstało jako FromInstance, jest to tylko prefab, a nie INSTANCJA, dopiero w CreateColumn() następuje instantiate'owanie tego prefaba

	private float _timeIntervalForCoroutine;
	private float _yPosition;

	private const float _intervalStep = 0.3f;
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
			ColumnView column = Instantiate<ColumnView>(_column);
			InitializeColumn(column);					
			_columnsSoFar++;
		}
	}

	private void InitializeColumn(ColumnView column)
	{
		column.gameObject.SetActive(true);
		_yPosition = Random.Range(_minRange, _maxRange);
		column.transform.position = new Vector3(_startXPosition, _yPosition);
	}
}

// dlaczego obiekt ColumnView znika w momencie, kiedy tworzony jest kolejny obiekt ColumnView? nastepuje nadpisanie zmiennej Injectowanej?