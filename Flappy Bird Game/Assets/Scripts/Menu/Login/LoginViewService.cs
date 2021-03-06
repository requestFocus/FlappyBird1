﻿using System.Collections;
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
	private ProjectDataService _playerProfileController;

	public void CheckPlayerPrefs(string playerName)																	 // ładowane po kliknieciu LOGO w menu LOGIN po podaniu username
	{
		_playerPrefsExist = _playerProfileController.IsPlayerPrefsNotEmpty();

		if (_playerPrefsExist)
		{
			ProjectData tempProjectData = _playerProfileController.LoadProfiles();
			_projectData.EntireList.Clear();
			_projectData.EntireList.InsertRange(0, tempProjectData.EntireList);

			for (int i = 0; i < _projectData.EntireList.Count; i++)                 // parsuje całą listę obiektów
			{
				if (_projectData.EntireList[i].PlayerName.Equals(playerName))		// sprawdza czy podane NAME istnieje w pamięci
				{
					_projectData.CurrentID = i;									  // ID znalezionego profilu
					_isOnTheList = true;
					break;
				}
			}

			if (!_isOnTheList)
			{
				AddNewProfile(playerName);                          // dodaj KOLEJNY profil
			}
		}
		else														
		{
			AddNewProfile(playerName);                          // dodaj PIERWSZY profil
		}

		_isOnTheList = false;                               // zerowanie flagi wystąpienia playerName na liście
	}

	private void AddNewProfile(string playerName)
	{
		_playerProfile = new PlayerProfile(playerName, 0, false, false, false);          // tworzę nowy profil gracza z domyślnymi wartościami

		_projectData.EntireList.Add(_playerProfile);                             // a teraz dodaje do niej aktualny _playerProfile
		_projectData.CurrentID = _projectData.EntireList.Count - 1;         // nadanie nowemu userowi najwyzszego numeru na liscie
		_playerProfileController.SaveProfiles(_projectData);                               // zapisuję dane w singletonie	
	}
}
