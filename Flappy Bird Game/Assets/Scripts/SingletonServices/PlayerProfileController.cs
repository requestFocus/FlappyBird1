using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerProfileController
{
	private const string _prefsStringInMemory = "ProfileSettings";

	private string _jsonDataToSet;
	private string _jsonDataFromGet;
	private ProjectData _loadedProfilesData;

	public void SaveProfile(ProjectData listToSave)
	{
		_jsonDataToSet = JsonUtility.ToJson(listToSave);                                               //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString(_prefsStringInMemory, _jsonDataToSet);                                                //zapisz json do podanego key w PlayerPrefs
	}

	public ProjectData LoadProfiles()
	{
		_jsonDataFromGet = PlayerPrefs.GetString(_prefsStringInMemory);                                     // wczytaj z PlayerPrefs do JSON
		_loadedProfilesData = JsonUtility.FromJson<ProjectData>(_jsonDataFromGet);                               // wczytaj z JSON do odpowiadającej mu struktury ProjectData
		Debug.Log("przed zerowaniem _loadedProfilesData.CurrentID: " + _loadedProfilesData.CurrentID);
		_loadedProfilesData.CurrentID = 0;
		Debug.Log("po zerowaniu _loadedProfilesData.CurrentID: " + _loadedProfilesData.CurrentID);
		return _loadedProfilesData;
	}

	public bool IsPlayerPrefsNotEmpty()                                                          // szybkie sprawdzenie czy podane NAME istnieje w PlayerPrefs
	{
		return PlayerPrefs.GetString(_prefsStringInMemory).Length > 0;
	}
}
 