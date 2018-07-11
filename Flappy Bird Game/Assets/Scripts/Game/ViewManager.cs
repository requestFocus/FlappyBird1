using UnityEngine;
using Zenject;

public class ViewManager : MonoBehaviour											
{
	private GUIGamePlayView _guiGamePlayView;
	private GUISuccessSummaryView _guiSuccessSummaryView;
	private GUIFailureSummaryView _guiFailureSummaryView;

	[Inject]
	private ViewFactory _viewFactory;

	[Inject]
	private CurrentGameStateService _currentGameStateService;

	private void Awake()
	{
		_currentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;     // POCZĄTEK SCENY
		SwitchView();                                                                               // ZAŁADOWANIE WIDOKU
	}

	public void SwitchView()
	{
		switch (_currentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				_guiGamePlayView = _viewFactory.ConcreteGUIGamePlayView();
				_guiGamePlayView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummarySuccess:
				_guiSuccessSummaryView = _viewFactory.ConcreteGUISuccessSummaryView(_guiGamePlayView);
				_guiSuccessSummaryView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;

			case CurrentGameStateService.GameStates.SummaryFailure:
				_guiFailureSummaryView = _viewFactory.ConcreteGUIFailureSummaryView(_guiGamePlayView);
				_guiFailureSummaryView.transform.SetParent(FindObjectOfType<ViewManager>().transform);
				break;
		}
	}
}