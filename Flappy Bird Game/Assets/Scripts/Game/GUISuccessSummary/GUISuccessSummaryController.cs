using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GUISuccessSummaryController : Controller<GUISuccessSummaryModel>
{
	/*
	 * ten kontroler zapisuje dane Modelu w Singletonie
	 */

	private PlayerProfileController _playerProfileController = new PlayerProfileController();

	[Inject]
	public CurrentPlayerData _currentPlayerData;

	public void UpdateModel(int score)
	{
		_currentPlayerData.CurrentProfile.HighScore = score;

		PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID] = _currentPlayerData.CurrentProfile;

		_playerProfileController.SaveProfile(PlayersProfiles.Instance);               // zapisz wyniki przed powrotem do sceny MENU
	}
}
