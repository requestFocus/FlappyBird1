using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class PlayerProfileController : MonoBehaviour {

	public const string PrefsStringInMemory = "ProfileSettings";

	public void SaveProfile(PlayersProfiles playersProfilesToSave)
	{
		string jsonDataToSet = JsonUtility.ToJson(playersProfilesToSave);                                         //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString(PrefsStringInMemory, jsonDataToSet);                                                //Load saved Json, czyli pobierz string z playerprefs i zapisz string do json
	}

	public PlayersProfiles LoadProfiles()
	{
		string jsonDataFromGet = PlayerPrefs.GetString(PrefsStringInMemory);                                    //Load saved Json, czyli pobierz string z playerprefs i zapisz string do json
		PlayersProfiles loadedProfilesData = JsonUtility.FromJson<PlayersProfiles>(jsonDataFromGet);               //Convert to Class, czyli skonwertuj łańcuch znaków json na obiekt

		return loadedProfilesData;
	}

	public bool CheckIfProfileExist(string playerName)															// szybkie sprawdzenie czy podane NAME istnieje w PlayerPrefs
	{
		return PlayerPrefs.GetString(PrefsStringInMemory).Contains(playerName);		
	}
}
 