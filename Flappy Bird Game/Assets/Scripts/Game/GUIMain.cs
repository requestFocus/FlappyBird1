using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	public GUIGamePlayView GUIGamePlayView;
	//public GUISummaryView GUISummaryView;

	void Start ()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
	}
	
	void Update ()
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				GUIGamePlayView.DisplayGUIGamePlayView();
				break;
			case CurrentGameStateService.GameStates.Summary:
				Debug.Log("summary jeszcze nie ma");
				break;
		}
	}
}
