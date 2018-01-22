using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class PlayerProfileController : MonoBehaviour {





	public void SaveProfile(PlayersProfiles playersProfilesToSave)
	{
		string jsonDataToSet = JsonUtility.ToJson(playersProfilesToSave);                                         //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString("ProfileSettings", jsonDataToSet);                                                //Load saved Json, czyli pobierz string z playerprefs i zapisz string do json

		//Debug.Log("jsonDataToSet: " + jsonDataToSet);
		Debug.Log("saved PlayerPrefs.GetString(\"ProfileSettings\"): " + PlayerPrefs.GetString("ProfileSettings"));
	}







	public PlayersProfiles LoadProfiles()
	{
		string jsonDataFromGet = PlayerPrefs.GetString("ProfileSettings");                                    //Load saved Json, czyli pobierz string z playerprefs i zapisz string do json
		PlayersProfiles loadedProfilesData = JsonUtility.FromJson<PlayersProfiles>(jsonDataFromGet);               //Convert to Class, czyli skonwertuj łańcuch znaków json na obiekt

		Debug.Log("jsonDataFromGet: " + jsonDataFromGet);

		return loadedProfilesData;
	}






	public bool CheckIfProfileExist(string playerName)									// szybkie sprawdzenie czy podane NAME istnieje w PlayerPrefs
	{
		Debug.Log("CheckIfProfileExist dla " + playerName + ": " + PlayerPrefs.GetString("ProfileSettings").Contains(playerName));
		return PlayerPrefs.GetString("ProfileSettings").Contains(playerName);
	}

	/* czy bedzie potrzebna funkcja do wczytania wszystkich danych z pamieci na potrzeby achievementów? 
	 * czy powinienem raczej odpowiednio zmodyfikować LoadProfile()?
	 */
}
 