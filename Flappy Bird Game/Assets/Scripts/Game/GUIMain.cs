using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	[SerializeField] private ViewManager ViewManager;

	private void Awake()
	{
		SetState(CurrentGameStateService.GameStates.GamePlay);
	}


	public void SetState(CurrentGameStateService.GameStates state)
	{
		CurrentGameStateService.CurrentGameState = state;
		ViewManager.SwitchView();
	}
}
