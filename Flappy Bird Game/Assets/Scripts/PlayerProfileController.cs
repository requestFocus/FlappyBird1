using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfileController {

	private string playerName = "";
	private int highScore = 0;
	private int complete10 = 0;
	private int complete25 = 0;
	private int complete50 = 0;
	private int complete100 = 0;

	void Save()
	{
		PlayerProfileController saveData = new PlayerProfileController();

		//Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		string jsonData = JsonUtility.ToJson(saveData);
		//Save Json string, łańcuch znaków opisujący obiekt zostaje zapisany w playerprefs
		PlayerPrefs.SetString("MySettings", jsonData);
		PlayerPrefs.Save();
	}

	void Load()
	{
		//Load saved Json, czyli pobierz string z playerprefs i zapisz do stringa json
		string jsonData = PlayerPrefs.GetString("MySettings");
		//Convert to Class, czyli skonwertuj łańcuch znaków json na obiekt
		PlayerProfileController loadedData = JsonUtility.FromJson<PlayerProfileController>(jsonData);

		//Display saved data
		Debug.Log("playerName: " + loadedData.playerName);
		Debug.Log("highScore: " + loadedData.highScore);
		Debug.Log("complete10: " + loadedData.complete10);
		Debug.Log("complete25: " + loadedData.complete25);
		Debug.Log("complete50: " + loadedData.complete50);
		Debug.Log("complete100: " + loadedData.complete100);

	}
}
