using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	[SerializeField] private ViewFactory ViewFactory;
	private GUIGamePlayView GUIGamePlayView;
	private ISummaryView SummaryView;

	private void Awake()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		SwitchView();
	}

	public void SwitchView()
	{
		SummaryView = null;

		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				GUIGamePlayView = ViewFactory.ConcreteGUIGamePlayView();
				GUIGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				SummaryView = ViewFactory.ConcreteGUISuccessSummaryView(GUIGamePlayView);
				((GUISuccessSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
					//Debug.Log(((GUISuccessSummaryView)SummaryView).Model.GameOutcome);			// demonstracja użycia interfejsu w factory
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				SummaryView = ViewFactory.ConcreteGUIFailureSummaryView(GUIGamePlayView);
				((GUIFailureSummaryView)SummaryView).transform.SetParent(FindObjectOfType<ViewManager>().transform);
					//Debug.Log(((GUIFailureSummaryView)SummaryView).Model.GameOutcome);			// demonstracja użycia interfejsu w factory
				break;
		}
	}
}
