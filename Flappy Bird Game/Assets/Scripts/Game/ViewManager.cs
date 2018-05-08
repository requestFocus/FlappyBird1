using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour											
{
	private GUIGamePlayView _GUIGamePlayView;					// =============================? _gUIGamePlayView?
	private ISummaryView _SummaryView;

	private void Awake()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;		// POCZĄTEK SCENY
		SwitchView();                                                                               // ZAŁADOWANIE WIDOKU
	}

	public void SwitchView()
	{
		_SummaryView = null;

		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				_GUIGamePlayView = ViewFactory.FactoryInstance.ConcreteGUIGamePlayView();                                        
				_GUIGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				_SummaryView = ViewFactory.FactoryInstance.ConcreteGUISuccessSummaryView(_GUIGamePlayView);                     
				((GUISuccessSummaryView)_SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				_SummaryView = ViewFactory.FactoryInstance.ConcreteGUIFailureSummaryView(_GUIGamePlayView);
				((GUIFailureSummaryView)_SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;
		}
	}
}
