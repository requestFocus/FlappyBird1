using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : SingletonViewFactory                                                                   // działa, jeśli ViewManager dziedziczy z SingletonViewFactory
{
	private GUIGamePlayView GUIGamePlayView;
	private ISummaryView SummaryView;

	private void Awake()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;		// POCZĄTEK SCENY
		SwitchView();                                                                               // ZAŁADOWANIE WIDOKU
	}

	public void SwitchView()
	{
		SummaryView = null;

		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				GUIGamePlayView = SingletonViewFactoryInstance.ConcreteGUIGamePlayView();                           // działa, jeśli ViewManager dziedziczy z SingletonViewFactory
				GUIGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				SummaryView = SingletonViewFactoryInstance.ConcreteGUISuccessSummaryView(GUIGamePlayView);        // działa, jeśli ViewManager dziedziczy z SingletonViewFactory
				((GUISuccessSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				SummaryView = SingletonViewFactoryInstance.ConcreteGUIFailureSummaryView(GUIGamePlayView);        // działa, jeśli ViewManager dziedziczy z SingletonViewFactory
				((GUIFailureSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;
		}
	}
}
