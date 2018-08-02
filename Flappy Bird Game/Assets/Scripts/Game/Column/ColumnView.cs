﻿using UnityEngine;
using Zenject;

public class ColumnView : MonoBehaviour
{
	private const float _startXPosition = 10.5f;
	private const float _endXPosition = -10.5f;
	private const float _acceleration = 5.0f;

	[Inject]
	private CurrentGameStateService _currentGameStateService;

	private void FixedUpdate()
	{
		MoveColumn();
	}

	private void MoveColumn()                                       // COLUMN SERVICE								
	{
		if (transform.position.x >= _endXPosition && _currentGameStateService.CurrentGameState == CurrentGameStateService.GameStates.GamePlay)
			transform.position += (Vector3.left * Time.deltaTime * _acceleration);
		else
			Destroy(gameObject);
	}
}
