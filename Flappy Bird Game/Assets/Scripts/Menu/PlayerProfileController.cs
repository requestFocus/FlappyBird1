using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfileController {

	public const string PrefsStringInMemory = "ProfileSettings";

	private string _jsonDataToSet;
	private string _jsonDataFromGet;
	private PlayersProfiles _loadedProfilesData;

	public void SaveProfile(PlayersProfiles playersProfilesToSave)
	{
		_jsonDataToSet = JsonUtility.ToJson(playersProfilesToSave);                                         //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString(PrefsStringInMemory, _jsonDataToSet);                                                //Load saved Json, czyli pobierz string z playerprefs i zapisz string do json
	}



	public bool LoadProfiles()
	{
		if (PlayerPrefs.GetString(PrefsStringInMemory).Length > 0)												// jeśli w pamięci istnieje jakaś lista
		{
			_jsonDataFromGet = PlayerPrefs.GetString(PrefsStringInMemory);										// wczytaj z PlayerPrefs do JSON
			_loadedProfilesData = JsonUtility.FromJson<PlayersProfiles>(_jsonDataFromGet);					  // wczytaj z JSON do odpowiadającej mu struktury PlayersProfiles
			PlayersProfiles.Instance.ListOfProfiles = _loadedProfilesData.ListOfProfiles;						// wpisanie zawartości strktury do SINGLETONA
			return true;
		}

		return false;
	}



	public bool CheckIfProfileExist(string playerName)															// szybkie sprawdzenie czy podane NAME istnieje w PlayerPrefs
	{
		return PlayerPrefs.GetString(PrefsStringInMemory).Contains(playerName);		
	}
}
 