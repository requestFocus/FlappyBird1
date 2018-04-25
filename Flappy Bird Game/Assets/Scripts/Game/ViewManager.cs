using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	[SerializeField] private ViewFactory ViewFactory;
	private ISummaryView SummaryView;

	public void SwitchView()
	{
		SummaryView = null;

		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				ViewFactory.ConcreteGUIGamePlayView();
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				SummaryView = ViewFactory.ConcreteGUISummaryView();
				Debug.Log(((GUISuccessSummaryView)SummaryView).Model.GameOutcome);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				SummaryView = ViewFactory.ConcreteGUIFailureSummaryView();
				Debug.Log(((GUIFailureSummaryView)SummaryView).Model.GameOutcome);
				break;
		}
	}
}
