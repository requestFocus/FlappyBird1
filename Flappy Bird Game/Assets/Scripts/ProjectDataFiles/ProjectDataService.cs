﻿using System.Collections.Generic;
using UnityEngine;

public class ProjectDataService
{
	private const string _prefsStringInMemory = "ProfileSettings";

	private string _jsonDataToSet;
	private string _jsonDataFromGet;
	private ProjectData _loadedProfilesData;

	public void SaveProfiles(ProjectData listToSave)
	{
		_jsonDataToSet = JsonUtility.ToJson(listToSave);                                                    //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString(_prefsStringInMemory, _jsonDataToSet);                                        //zapisz json do podanego key w PlayerPrefs
	}

	public ProjectData LoadProfiles()
	{
		_jsonDataFromGet = PlayerPrefs.GetString(_prefsStringInMemory);                                     // wczytaj z PlayerPrefs do JSON
		_loadedProfilesData = JsonUtility.FromJson<ProjectData>(_jsonDataFromGet);                           // wczytaj z JSON do odpowiadającej mu struktury ProjectData
		_loadedProfilesData.CurrentID = 0;
		return _loadedProfilesData;
	}

	public bool IsPlayerPrefsNotEmpty()																		// szybkie sprawdzenie czy PlayerPrefs zawiera jakieś dane
	{
		return PlayerPrefs.GetString(_prefsStringInMemory).Length > 0;
	}
}
 