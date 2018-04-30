using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	//[SerializeField] private ViewFactory ViewFactoryInstance;
	private GUIGamePlayView GUIGamePlayView;
	private ISummaryView SummaryView;

	private void Awake()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;		// POCZĄTEK SCENY
		SwitchView();																				// ZAŁADOWANIE WIDOKU
	}

	public void SwitchView()
	{
		SummaryView = null;

		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				GUIGamePlayView = ViewFactory.FactoryInstance.ConcreteGUIGamePlayView();
				//GUIGamePlayView = ViewFactoryInstance.ConcreteGUIGamePlayView();
				GUIGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				SummaryView = ViewFactory.FactoryInstance.ConcreteGUISuccessSummaryView(GUIGamePlayView);
				//SummaryView = ViewFactoryInstance.ConcreteGUISuccessSummaryView(GUIGamePlayView);
				((GUISuccessSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				SummaryView = ViewFactory.FactoryInstance.ConcreteGUIFailureSummaryView(GUIGamePlayView);
				//SummaryView = ViewFactoryInstance.ConcreteGUIFailureSummaryView(GUIGamePlayView);
				((GUIFailureSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;
		}
	}
}
