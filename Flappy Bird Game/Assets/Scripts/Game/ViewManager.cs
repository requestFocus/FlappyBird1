using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewManager : MonoBehaviour											
{
	private GUIGamePlayView _GUIGamePlayView;
	private GUISuccessSummaryView _GUISuccessSummaryView;
	private GUIFailureSummaryView _guiFailureSummaryView;

	[Inject]
	private ViewFactory _viewFactory;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

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
				_GUIGamePlayView = _viewFactory.ConcreteGUIGamePlayView();
				_GUIGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				_GUISuccessSummaryView = _viewFactory.ConcreteGUISuccessSummaryView(_GUIGamePlayView);
				_GUISuccessSummaryView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				_guiFailureSummaryView = _viewFactory.ConcreteGUIFailureSummaryView(_GUIGamePlayView);
				_guiFailureSummaryView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;
		}
	}
}