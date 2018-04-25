using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISuccessSummaryController : Controller<GUISuccessSummaryModel>
{
	/*
	 * ten kontroler zapisuje dane Modelu w Singletonie
	 */

	private PlayerProfileController _playerProfileController = new PlayerProfileController();

	public void UpdateModel(int score)
	{
		Model.CurrentProfile.HighScore = score;

		Model.PlayersProfilesUpdated.ListOfProfiles[Model.PlayersProfilesUpdated.CurrentProfileID] = Model.CurrentProfile;

		_playerProfileController.SaveProfile(Model.PlayersProfilesUpdated);               // zapisz wyniki przed powrotem do sceny MENU
	}
}
