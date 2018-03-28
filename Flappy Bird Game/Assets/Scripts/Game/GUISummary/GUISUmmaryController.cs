using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISummaryController
{
	/*
	 * Kontroler potrzebuje dostępu do modelu GUISummaryView w momencie zakończenia gry i potrzeby zapisania wyniku
	 * - jeśli CurrentScore nie jest wiekszy od Highscore nie trzeba robić nic
	 * - jeśli CurrentScore jest większy od HighScore należy poinformować model, że zmieniły się dane
	 */

	private PlayerProfileController _playerProfileController = new PlayerProfileController();

	public void UpdateModel(PlayersProfiles model)
	{
		_playerProfileController.SaveProfile(model);               // zapisz wyniki przed powrotem do sceny MENU
	}
}
