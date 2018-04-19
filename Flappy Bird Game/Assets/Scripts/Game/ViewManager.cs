using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	[SerializeField] private GUIGamePlayView GUIGamePlayView;
	[SerializeField] private GUISummaryView GUISummaryView;

	private ModelFactory _modelFactory;
	private IGamePlayModel _gamePlayModel;
	private ISummaryModel _summaryModel;

	public void SwitchView()
	{
		_modelFactory = new ModelFactory();

		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				_gamePlayModel = _modelFactory.ConcreteGUIGamePlayModel();
				GUIGamePlayView.Model = (GUIGamePlayModel)_gamePlayModel;
				break;

			case CurrentGameStateService.GameStates.Summary:
				_summaryModel = _modelFactory.ConcreteGUISummaryModel((GUIGamePlayModel)_gamePlayModel);
				GUISummaryView.Model = (GUISummaryModel)_summaryModel;
				break;
		}
	}
}
