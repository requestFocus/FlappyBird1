using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LoginViewService
{
	private bool _thereIsAList;
	private bool _isOnTheList;
	private PlayerProfile _playerProfile;

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private PlayerProfileController _playerProfileController;

	public void CheckPlayerPrefs(string playerName)																	 // ładowane po kliknieciu LOGO w menu LOGIN po podaniu username
	{
		_thereIsAList = _playerProfileController.LoadProfiles();
		_isOnTheList = false;

		if (_thereIsAList)																			 // jesli istnieje lista w pamieci
		{
			for (int i = 0; i < _projectData.EntireList.Count; i++)                 // parsuje całą listę obiektów
			{
				if (_projectData.EntireList[i].PlayerName.Equals(playerName))   // sprawdza czy podane NAME istnieje w pamięci
				{
					_playerProfile = _projectData.EntireList[i];				   // odnaleziony profil, uzywany przy listowaniu achievementow
					_projectData.CurrentID = i;									// ID znalezionego profilu
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
		_projectData.EntireList.Add(_playerProfile);									// a teraz dodaje do listy aktualny _playerProfile
		if (_thereIsAList)																				 // na liście nie ma podanego NAME
		{
			_projectData.CurrentID = _projectData.EntireList.Count - 1;         // nadanie nowemu userowi najwyzszego numeru na liscie
		}
		else
		{
			_projectData.CurrentID = 0;											 // nadaję userowi pierwszy numer na liście
		}
		_playerProfileController.SaveProfile(_projectData);                               // zapisuję dane w singletonie	
	}
}
