using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginViewService
{
	public static bool ThereIsAList;
	public static int FoundPlayerProfileID;

	private bool _isOnTheList;
	private PlayerProfile _playerProfile;
	private PlayerProfileController _playerProfileController = new PlayerProfileController();

	public void CheckPlayerPrefs()                                                         // ładowane po kliknieciu LOGO w menu LOGIN po podaniu username
	{
		ThereIsAList = _playerProfileController.LoadProfiles();

		FoundPlayerProfileID = -1;

		if (ThereIsAList)                                                                   // jesli istnieje lista w pamieci
		{
			for (int i = 0; i < PlayersProfiles.Instance.ListOfProfiles.Count; i++)                 // parsuje całą listę obiektów
			{
				if (PlayersProfiles.Instance.ListOfProfiles[i].PlayerName.Equals(LoginView.JustPlayerName))   // sprawdza czy podane NAME istnieje w pamięci
				{
					_playerProfile = PlayersProfiles.Instance.ListOfProfiles[i];                 // odnaleziony profil, uzywany przy listowaniu achievementow
					/* POTRZEBNE W CANVAS CONTROLLER */	PlayersProfiles.Instance.CurrentProfile = i;                                    // ID znalezionego profilu
					FoundPlayerProfileID = i;
					_isOnTheList = true;
					break;
				}
			}

			if (!_isOnTheList)                                                                                  // jesli na liscie nie wystepuje podane NAME
			{
				AddNewProfile();
			}
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			AddNewProfile();
		}
	}



	private void AddNewProfile()
	{
		_playerProfile = new PlayerProfile(LoginView.JustPlayerName, 0, false, false, false);          // tworzę nowy profil gracza z domyślnymi wartościami
		if (ThereIsAList)																				 // na liście nie ma podanego NAME
		{
			PlayersProfiles.Instance.ListOfProfiles.Add(_playerProfile);                     // a teraz dodaje do niej aktualny playerProfile
			/* POTRZEBNE W CANVAS CONTROLLER */ PlayersProfiles.Instance.CurrentProfile = PlayersProfiles.Instance.ListOfProfiles.Count - 1;         // nadanie nowemu userowi najwyzszego numeru na liscie
			FoundPlayerProfileID = PlayersProfiles.Instance.ListOfProfiles.Count - 1;
		}
		else
		{
			PlayersProfiles.Instance.ListOfProfiles = new List<PlayerProfile>			// tworzę listę, bo _isThereAList == false
			{            
				_playerProfile																// a teraz dodaje do niej aktualny playerProfile
			};
			/* POTRZEBNE W CANVAS CONTROLLER */	PlayersProfiles.Instance.CurrentProfile = 0;                                    // nadaję userowi pierwszy numer na liście
			FoundPlayerProfileID = 0;
		}
		_playerProfileController.SaveProfile(PlayersProfiles.Instance);                  // zapisuję dane w singletonie				
	}
}
