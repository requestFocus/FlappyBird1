using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewManager : MonoBehaviour											
{
	[Inject]
	private ViewFactory _viewFactory;

	private void Awake()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;     // POCZĄTEK SCENY
		SwitchView();                                                                               // ZAŁADOWANIE WIDOKU
	}

	public void SwitchView()
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				_viewFactory.ConcreteGUIGamePlayView();
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				_viewFactory.ConcreteGUISuccessSummaryView();
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				_viewFactory.ConcreteGUIFailureSummaryView();
				break;
		}
	}
}