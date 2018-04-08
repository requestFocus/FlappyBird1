﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISummaryController : Controller<GUISummaryModel>
{
	/*
	 * Kontroler uaktywnia sie w momencie zakończenia gry i potrzeby zapisania wyniku
	 * - jeśli CurrentScore nie jest wiekszy od Highscore nie trzeba robić nic
	 * - jeśli CurrentScore jest większy od HighScore należy poinformować model, że zmieniły się dane
	 * 
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
