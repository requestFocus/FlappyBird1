using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfileController {

	private const string _prefsStringInMemory = "ProfileSettings";

	private string _jsonDataToSet;
	private string _jsonDataFromGet;
	private PlayersProfiles _loadedProfilesData;

	public void SaveProfile(PlayersProfiles playersProfilesToSave)
	{
		_jsonDataToSet = JsonUtility.ToJson(playersProfilesToSave);                                               //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString(_prefsStringInMemory, _jsonDataToSet);                                                //zapisz json do podanego key w PlayerPrefs
	}



	public bool LoadProfiles()
	{
		if (PlayerPrefs.GetString(_prefsStringInMemory).Length > 0)												// jeśli w pamięci istnieje jakaś lista
		{
			_jsonDataFromGet = PlayerPrefs.GetString(_prefsStringInMemory);										// wczytaj z PlayerPrefs do JSON
			_loadedProfilesData = JsonUtility.FromJson<PlayersProfiles>(_jsonDataFromGet);					  // wczytaj z JSON do odpowiadającej mu struktury PlayersProfiles
			PlayersProfiles.Instance.ListOfProfiles = _loadedProfilesData.ListOfProfiles;                       // wpisanie zawartości struktury do SINGLETONA
			return true;
		}

		return false;
	}



	public bool CheckIfProfileExist(string playerName)                                                          // szybkie sprawdzenie czy podane NAME istnieje w PlayerPrefs
	{
		return PlayerPrefs.GetString(_prefsStringInMemory).Contains(playerName);
	}
}
 