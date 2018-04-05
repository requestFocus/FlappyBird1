using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
	[SerializeField] private GUIGamePlayView GUIGamePlayViewPrefab;
	[SerializeField] private GUIGamePlayView GUIGamePlayViewInstance;
	[SerializeField] private GUISummaryView GUISummaryViewPrefab;
	[SerializeField] private GUISummaryView GUISummaryViewInstance;

	private bool _gamePlayExists;
	private bool _summaryExists;

	public void SwitchView(CurrentGameStateService.GameStates state)
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				if (!_gamePlayExists)
				{
					CreateGUIGamePlayView();
					_gamePlayExists = true;
				}
				break;

			case CurrentGameStateService.GameStates.Summary:
				if (!_summaryExists)
				{
					CreateGUISummaryView();
					_summaryExists = true;
				}
				break;
		}
	}


	public void CreateGUIGamePlayView()                         // ten widok powstaje zawsze jako pierwszy z dwóch
	{
		GUIGamePlayViewInstance = Instantiate(GUIGamePlayViewPrefab, gameObject.transform);
		GUIGamePlayViewInstance.Model = new GUIGamePlayModel()
		{
			PlayersProfilesLoadedToModel = PlayersProfiles.Instance,
			AchievementIsUnlocked = false
		};
	}



	public void CreateGUISummaryView()                          // ten widok powstaje zawsze jako drugi z dwóch
	{
		GUISummaryViewInstance = Instantiate(GUISummaryViewPrefab, gameObject.transform);
		GUISummaryViewInstance.Model = new GUISummaryModel()
		{
			PlayersProfilesSentFromGamePlay = GUIGamePlayViewInstance.Model.PlayersProfilesLoadedToModel,
			AchievementIsUnlocked = GUIGamePlayViewInstance.Model.AchievementIsUnlocked
		};
	}
}
