using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	[SerializeField] private ViewManager ViewManagerPrefab;
	[SerializeField] private ViewManager ViewManagerInstance;

	private bool _gamePlayExists;
	private bool _summaryExists;

	private void Start()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		ViewManagerInstance = Instantiate(ViewManagerPrefab);
	}

	private void Update()
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				if (!_gamePlayExists)
				{
					ViewManagerInstance.CreateGUIGamePlayView();
					_gamePlayExists = true;
				}
				break;

			case CurrentGameStateService.GameStates.Summary:
				if (!_summaryExists)
				{
					ViewManagerInstance.CreateGUISummaryView();
					_summaryExists = true;
				}
				break;
		}
	}
}
