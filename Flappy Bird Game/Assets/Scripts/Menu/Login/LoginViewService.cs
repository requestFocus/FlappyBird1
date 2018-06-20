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
	public ProjectData _projectData;

	[Inject]
	private PlayerProfileController _playerProfileController;

	public void CheckPlayerPrefs(string playerName)																	 // ładowane po kliknieciu LOGO w menu LOGIN po podaniu username
	{
		_playerPrefsExist = _playerProfileController.IsPlayerPrefsNotEmpty();

		if (_playerPrefsExist)
		{
			ProjectData tmp = _playerProfileController.LoadProfiles();
			_projectData.EntireList.Clear();
			_projectData.EntireList.InsertRange(0, tmp.EntireList);
			_projectData.CurrentID = tmp.CurrentID;

			for (int i = 0; i < _projectData.EntireList.Count; i++)                 // parsuje całą listę obiektów
			{
				if (_projectData.EntireList[i].PlayerName.Equals(playerName))		// sprawdza czy podane NAME istnieje w pamięci
				{
					_projectData.CurrentID = i;									  // ID znalezionego profilu
					_isOnTheList = true;

					Debug.Log("name: " + playerName + " istnieje pod _projectData.CurrentID: " + _projectData.CurrentID);
					break;
				}
			}

			if (!_isOnTheList)
			{
				Debug.Log("playerprefs istnieje, dodaje kolejny profil");
				AddNewProfile(playerName);                          // dodaj KOLEJNY profil
			}
		}
		else																	// czyli playerprefs nie istnieje, czyli nie ma takiego name, ALE lista istnieje, jest tworzona zawsze w konstruktorze ProjectData
		{
			Debug.Log("playerprefs nie istnieje, dodaje pierwszy profil");
			AddNewProfile(playerName);                          // dodaj PIERWSZY profil
		}

		_isOnTheList = false;                               // zerowanie flagi
	}

	private void AddNewProfile(string playerName)
	{
		_playerProfile = new PlayerProfile(playerName, 0, false, false, false);          // tworzę nowy profil gracza z domyślnymi wartościami

		_projectData.EntireList.Add(_playerProfile);                             // a teraz dodaje do niej aktualny _playerProfile
		_projectData.CurrentID = _projectData.EntireList.Count - 1;         // nadanie nowemu userowi najwyzszego numeru na liscie
		Debug.Log("name: " + playerName + " dodane pod _projectData.CurrentID: " + _projectData.CurrentID);

		_playerProfileController.SaveProfile(_projectData);                               // zapisuję dane w singletonie	
	}
}
