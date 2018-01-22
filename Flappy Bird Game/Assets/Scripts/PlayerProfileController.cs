using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class PlayerProfileController : MonoBehaviour {


	public void SaveProfile(PlayerProfile playerProfileToSave)
	{
		string jsonDataToSet = JsonUtility.ToJson(playerProfileToSave);                                         //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString("ProfileSettings", jsonDataToSet);                                                //Load saved Json, czyli pobierz string z playerprefs i zapisz string do json

		Debug.Log("jsonDataToSet: " + jsonDataToSet);
		Debug.Log("PlayerPrefs.GetString(\"ProfileSettings\"): " + PlayerPrefs.GetString("ProfileSettings"));
	}

	public void LoadProfile()
	{
		string jsonDataFromGet = PlayerPrefs.GetString("ProfileSettings");                                    //Load saved Json, czyli pobierz string z playerprefs i zapisz string do json
		PlayerProfile loadedProfileData = JsonUtility.FromJson<PlayerProfile>(jsonDataFromGet);				  //Convert to Class, czyli skonwertuj łańcuch znaków json na obiekt

		Debug.Log("playerName: " + loadedProfileData.playerName);
		Debug.Log("highScore: " + loadedProfileData.highScore);
		Debug.Log("highScore: " + loadedProfileData.complete10);
		//Debug.Log(jsonDataFromGet);
	}

	public bool CheckIfProfileExist(string playerName)
	{
		Debug.Log("CheckIfProfileExist dla " + playerName + ": " + PlayerPrefs.GetString("ProfileSettings").Contains(playerName));
		return PlayerPrefs.GetString("ProfileSettings").Contains(playerName);
	}
}
 