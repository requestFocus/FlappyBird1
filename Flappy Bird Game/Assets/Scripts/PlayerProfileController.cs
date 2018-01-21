using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class PlayerProfileController : MonoBehaviour {

	public string playerName = "";
	public int highScore = 0;
	public int complete10 = 0;
	public int complete25 = 0;
	public int complete50 = 0;
	public int complete100 = 0;

	public void SaveProfile(PlayerProfileController playerProfileController)
	{
		PlayerProfileController savedProfileData = playerProfileController;
		string jsonData = JsonUtility.ToJson(savedProfileData);                                         //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString("ProfileSettings", jsonData);                                            //Save Json string, łańcuch znaków opisujący obiekt zostaje zapisany w playerprefs
		PlayerPrefs.Save();
	}

	public void LoadProfile()
	{
		string jsonData = PlayerPrefs.GetString("ProfileSettings");                                          //Load saved Json, czyli pobierz string z playerprefs i zapisz string do json
		//PlayerProfileController loadedProfileData = JsonUtility.FromJson<PlayerProfileController>(jsonData);   //Convert to Class, czyli skonwertuj łańcuch znaków json na obiekt

		//Display saved data
		//Debug.Log("playerName: " + loadedProfileData.playerName);
		//Debug.Log("highScore: " + loadedProfileData.highScore);
		//Debug.Log("complete10: " + loadedProfileData.complete10);
		//Debug.Log("complete25: " + loadedProfileData.complete25);
		//Debug.Log("complete50: " + loadedProfileData.complete50);
		//Debug.Log("complete100: " + loadedProfileData.complete100);

		Debug.Log(jsonData);

	}
}
