using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	[SerializeField] private ViewManager ViewManagerPrefab;
	[SerializeField] private ViewManager ViewManagerInstance;


	private void Start()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		ViewManagerInstance = Instantiate(ViewManagerPrefab);
	}

	private void Update()
	{
		if (CurrentGameStateService.CurrentGameState == CurrentGameStateService.GameStates.GamePlay)
		{
			ViewManagerInstance.SwitchView(CurrentGameStateService.GameStates.GamePlay);
		}
		else if (CurrentGameStateService.CurrentGameState == CurrentGameStateService.GameStates.Summary)
		{
			ViewManagerInstance.SwitchView(CurrentGameStateService.GameStates.Summary);
		}
	}
}
