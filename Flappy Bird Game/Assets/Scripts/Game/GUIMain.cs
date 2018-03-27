using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	public GUIGamePlayView GUIGamePlayViewPrefab;
	public GUIGamePlayView GUIGamePlayViewInstance;
	public GUISummaryView GUISummaryViewPrefab;
	public GUISummaryView GUISummaryViewInstance;

	private bool _gamePlayExists;
	private bool _summaryExists;

	private void Start ()
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
	}

	private void Update()
	{
		switch (CurrentGameStateService.CurrentGameState)
		{
			case CurrentGameStateService.GameStates.GamePlay:
				if (!_gamePlayExists)
				{
					GUIGamePlayViewInstance = Instantiate(GUIGamePlayViewPrefab, gameObject.transform);
					GUIGamePlayViewInstance.Model = new GUIGamePlayModel()
					{
						CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile]
					};
					_gamePlayExists = true;
				}
				break;

			case CurrentGameStateService.GameStates.Summary:
				if (!_summaryExists)
				{
					GUISummaryViewInstance = Instantiate(GUISummaryViewPrefab, gameObject.transform);
					GUISummaryViewInstance.Model = new GUISummaryModel()
					{
						CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile]
					};
					_summaryExists = true;
				}
				break;
		}
	}
}
