﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewManager : MonoBehaviour											
{
	private GUIGamePlayView _GUIGamePlayView;					
	private ISummaryView _SummaryView;

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
		_SummaryView = null;

		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				_GUIGamePlayView = _viewFactory.ConcreteGUIGamePlayView();
				_GUIGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				_SummaryView = _viewFactory.ConcreteGUISuccessSummaryView(_GUIGamePlayView);
				((GUISuccessSummaryView)_SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				_SummaryView = _viewFactory.ConcreteGUIFailureSummaryView(_GUIGamePlayView);
				((GUIFailureSummaryView)_SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;
		}
	}
}