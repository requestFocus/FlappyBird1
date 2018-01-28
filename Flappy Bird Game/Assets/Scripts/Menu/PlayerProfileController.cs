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
		Debug.Log("jsonDataToSet: " + jsonDataToSet);
	}

	public bool LoadProfiles()
	{
		if (PlayerPrefs.GetString(PrefsStringInMemory).Length > 0)
		{
			string jsonDataFromGet = PlayerPrefs.GetString(PrefsStringInMemory);
			PlayersProfiles loadedProfilesData = JsonUtility.FromJson<PlayersProfiles>(jsonDataFromGet);            // czy to ma czytać bezpośrednio do listy w singletonie?
			PlayersProfiles.Instance.ListOfProfiles = new List<PlayerProfile>();								// jeśli lista nie jest statyczna to trzeba ją w tym miejscu stworzyć
			PlayersProfiles.Instance.ListOfProfiles = loadedProfilesData.ListOfProfiles;
			Debug.Log("jsonDataFromGet: " + jsonDataFromGet);
			return true;
		}

		return false;
	}

	public bool CheckIfProfileExist(string playerName)															// szybkie sprawdzenie czy podane NAME istnieje w PlayerPrefs
	{
		return PlayerPrefs.GetString(PrefsStringInMemory).Contains(playerName);		
	}
}
 