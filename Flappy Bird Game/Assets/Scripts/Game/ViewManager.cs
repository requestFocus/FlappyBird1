using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : Singleton<ViewFactory>
{
	private GUIGamePlayView GUIGamePlayView;
	private ISummaryView SummaryView;

	private void Awake()
	{
		//Debug.Log("tekst? : " + FactoryInstance.GetComponent<ViewFactory>().Tekst);

		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;		// POCZĄTEK SCENY
		SwitchView();                                                                               // ZAŁADOWANIE WIDOKU
	}

	public void SwitchView()
	{
		SummaryView = null;

		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				//GUIGamePlayView = FactoryInstance.GetComponent<ViewFactory>().ConcreteGUIGamePlayView();
				GUIGamePlayView = ViewFactory.FactoryInstance.ConcreteGUIGamePlayView();
				GUIGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				//SummaryView = FactoryInstance.GetComponent<ViewFactory>().ConcreteGUISuccessSummaryView(GUIGamePlayView);
				SummaryView = ViewFactory.FactoryInstance.ConcreteGUISuccessSummaryView(GUIGamePlayView);
				((GUISuccessSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				//SummaryView = FactoryInstance.GetComponent<ViewFactory>().ConcreteGUIFailureSummaryView(GUIGamePlayView);
				SummaryView = ViewFactory.FactoryInstance.ConcreteGUIFailureSummaryView(GUIGamePlayView);
				((GUIFailureSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;
		}
	}
}
