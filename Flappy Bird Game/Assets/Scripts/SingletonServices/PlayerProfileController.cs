using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerProfileController
{
	[Inject]
	private ProjectData _projectData;

	private const string _prefsStringInMemory = "ProfileSettings";

	private string _jsonDataToSet;
	private string _jsonDataFromGet;

	private ProjectData _loadedProjectData;

	public void SaveProfile(ProjectData projectDataToSave)
	{
		_jsonDataToSet = JsonUtility.ToJson(projectDataToSave);                                               //Convert to Json, czyli do stringa, tj. cały obiekt zostaje rozpisany na łańcuch znakow
		PlayerPrefs.SetString(_prefsStringInMemory, _jsonDataToSet);                                                //zapisz json do podanego key w PlayerPrefs
	}

	public bool LoadProfiles()
	{
		if (PlayerPrefs.GetString(_prefsStringInMemory).Length > 0)												// jeśli w pamięci istnieje jakaś lista
		{
			_jsonDataFromGet = PlayerPrefs.GetString(_prefsStringInMemory);                                     // wczytaj z PlayerPrefs do JSON
			_projectData = JsonUtility.FromJson<ProjectData>(_jsonDataFromGet);                                 // wczytaj z JSON do odpowiadającej mu struktury PlayersProfiles
			Debug.Log(_projectData.EntireList.Count);
			return true;
		}

		return false;
	}
}
