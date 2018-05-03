using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : Singleton<ViewFactory>
//public class ViewManager : SingletonViewFactory																	// działa, jeśli ViewManager dziedziczy z SingletonViewFactory
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
				//GUIGamePlayView = SingletonViewFactoryInstance.ConcreteGUIGamePlayView();							// działa, jeśli ViewManager dziedziczy z SingletonViewFactory
				GUIGamePlayView = FactoryInstance.ConcreteGUIGamePlayView();
				GUIGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				//SummaryView = SingletonViewFactoryInstance.ConcreteGUISuccessSummaryView(GUIGamePlayView);		// działa, jeśli ViewManager dziedziczy z SingletonViewFactory
				SummaryView = FactoryInstance.ConcreteGUISuccessSummaryView(GUIGamePlayView);
				((GUISuccessSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				//SummaryView = SingletonViewFactoryInstance.ConcreteGUIFailureSummaryView(GUIGamePlayView);		// działa, jeśli ViewManager dziedziczy z SingletonViewFactory
				SummaryView = FactoryInstance.ConcreteGUIFailureSummaryView(GUIGamePlayView);
				((GUIFailureSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;
		}
	}
}
