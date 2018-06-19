using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LoginViewService
{
	private bool _playerPrefsExist;
	private bool _isOnTheList;
	private PlayerProfile _playerProfile;

	private const string _prefsStringInMemory = "ProfileSettings";

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private PlayerProfileController _playerProfileController;

	public void CheckPlayerPrefs(string playerName)																	 // ładowane po kliknieciu LOGO w menu LOGIN po podaniu username
	{
		_playerPrefsExist = _playerProfileController.IsPlayerPrefsNotEmpty();

		if (_playerPrefsExist)
		{
			_projectData = _playerProfileController.LoadProfiles();

			for (int i = 0; i < _projectData.EntireList.Count; i++)                 // parsuje całą listę obiektów
			{
				if (_projectData.EntireList[i].PlayerName.Equals(playerName))   // sprawdza czy podane NAME istnieje w pamięci
				{
					_projectData.CurrentID = i;                                 // ID znalezionego profilu
					_isOnTheList = true;

					Debug.Log("name istnieje pod ID: " + _projectData.CurrentID);
					break;
				}
			}
		}
		else
		{
			_projectData.EntireList = new List<PlayerProfile>();
		}

		if (!_isOnTheList)                                                                       // jesli na liscie nie wystepuje podane NAME
		{
			Debug.Log("name nie istnieje");
			AddNewProfile(playerName);
		}

		_isOnTheList = false;																			// zerowanie flagi
	}

	private void AddNewProfile(string playerName)
	{
		_playerProfile = new PlayerProfile(playerName, 0, false, false, false);          // tworzę nowy profil gracza z domyślnymi wartościami

		_projectData.EntireList.Add(_playerProfile);                             // a teraz dodaje do niej aktualny _playerProfile
		_projectData.CurrentID = _projectData.EntireList.Count - 1;         // nadanie nowemu userowi najwyzszego numeru na liscie

		Debug.Log("name dodane na końcu pod ID: " + _projectData.CurrentID);

		_playerProfileController.SaveProfile(_projectData);                               // zapisuję dane w singletonie	
	}
}
