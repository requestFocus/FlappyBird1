using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginViewService
{
	private bool _thereIsAList;
	private bool _isOnTheList;
	private PlayerProfile _playerProfile;
	private PlayerProfileController _playerProfileController = new PlayerProfileController();

	public void CheckPlayerPrefs(string playerName)																	 // ładowane po kliknieciu LOGO w menu LOGIN po podaniu username
	{
		_thereIsAList = _playerProfileController.LoadProfiles();
		_isOnTheList = false;

		if (_thereIsAList)																			 // jesli istnieje lista w pamieci
		{
			for (int i = 0; i < PlayersProfiles.Instance.ListOfProfiles.Count; i++)                 // parsuje całą listę obiektów
			{
				if (PlayersProfiles.Instance.ListOfProfiles[i].PlayerName.Equals(playerName))   // sprawdza czy podane NAME istnieje w pamięci
				{
					_playerProfile = PlayersProfiles.Instance.ListOfProfiles[i];				   // odnaleziony profil, uzywany przy listowaniu achievementow
					PlayersProfiles.Instance.CurrentProfile = i;									// ID znalezionego profilu, POTRZEBNE TEŻ W CANVAS CONTROLLER
					_isOnTheList = true;
					break;
				}
			}

			if (!_isOnTheList)                                                                       // jesli na liscie nie wystepuje podane NAME
			{
				AddNewProfile(playerName);
			}
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			AddNewProfile(playerName);
		}

		_isOnTheList = false;
	}



	private void AddNewProfile(string playerName)
	{
		_playerProfile = new PlayerProfile(playerName, 0, false, false, false);          // tworzę nowy profil gracza z domyślnymi wartościami
		if (_thereIsAList)																				 // na liście nie ma podanego NAME
		{
			PlayersProfiles.Instance.ListOfProfiles.Add(_playerProfile);                             // a teraz dodaje do niej aktualny _playerProfile
			PlayersProfiles.Instance.CurrentProfile = PlayersProfiles.Instance.ListOfProfiles.Count - 1;         // nadanie nowemu userowi najwyzszego numeru na liscie
		}
		else
		{
			PlayersProfiles.Instance.ListOfProfiles = new List<PlayerProfile> { _playerProfile };           // tworzę listę, bo _isThereAList == false i dodaje aktualny _playerProfile
			PlayersProfiles.Instance.CurrentProfile = 0;											 // nadaję userowi pierwszy numer na liście
		}
		_playerProfileController.SaveProfile(PlayersProfiles.Instance);							      // zapisuję dane w singletonie	
	}
}
