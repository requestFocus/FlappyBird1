using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	public LevelService LevelService;

	public GUIGamePlayView GUIGamePlayView;
	public GUISummaryView GUISummaryView;

	private void Start ()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
	}

	private void Update()
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				GUIGamePlayView.DisplayGUIGamePlayView();
				break;
			case CurrentGameStateService.GameStates.Summary:
				GUISummaryView.DisplayGUISummaryView();
				break;
		}
	}
}
