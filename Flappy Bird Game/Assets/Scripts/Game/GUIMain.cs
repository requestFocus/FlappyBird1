using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	public GUIGamePlayView GUIGamePlayView;
	public GUISummaryView GUISummaryView;

	private bool _gamePlayExists;
	private bool _summaryExists;

	private void Start ()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
	}

	private void Update()
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				if (!_gamePlayExists)
				{
					Instantiate(GUIGamePlayView, gameObject.transform);
					_gamePlayExists = true;
				}
				//GUIGamePlayView.DisplayGUIGamePlayView();
				break;
			case CurrentGameStateService.GameStates.Summary:
				if (!_summaryExists)
				{
					Instantiate(GUISummaryView, gameObject.transform);
					_summaryExists = true;
				}
				//GUISummaryView.DisplayGUISummaryView();
				break;
		}
	}
}
