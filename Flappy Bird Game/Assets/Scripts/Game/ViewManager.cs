using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	[SerializeField] private GUIGamePlayView GUIGamePlayView;
	[SerializeField] private GUISummaryView GUISummaryView;

	private ModelFactory _modelFactory;
	private IGamePlayModel _gamePlayModel;

	//private bool _gamePlayExists;
	//private bool _summaryExists;

	public void SwitchView()
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:

				_modelFactory = new ModelFactory();
				_gamePlayModel = _modelFactory.ConcreteGUIGamePlayModel();
				GUIGamePlayView.Model = (GUIGamePlayModel)_gamePlayModel;


				//CreateGUIGamePlayView();

				//if (!_gamePlayExists)
				//{
				//CreateGUIGamePlayView();
				//_gamePlayExists = true;
				//}
				break;

			case CurrentGameStateService.GameStates.Summary:
				CreateGUISummaryView();

				//if (!_summaryExists)
				//{
				//CreateGUISummaryView();
				//_summaryExists = true;
				//}
				break;
		}
	}


	public void CreateGUIGamePlayView()                         // ten widok powstaje zawsze jako pierwszy z dwóch
	{
		GUIGamePlayView.Model = new GUIGamePlayModel()
		{
			CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID],
			AchievementIsUnlocked = false,

			CurrentScore = 0
		};
	}



	public void CreateGUISummaryView()                          // ten widok powstaje zawsze jako drugi z dwóch
	{
		GUISummaryView.Model = new GUISummaryModel()
		{
			CurrentProfile = GUIGamePlayView.Model.CurrentProfile,
			AchievementIsUnlocked = GUIGamePlayView.Model.AchievementIsUnlocked,

			PlayersProfilesUpdated = PlayersProfiles.Instance,

			CurrentScore = GUIGamePlayView.Model.CurrentScore
		};
	}
}
