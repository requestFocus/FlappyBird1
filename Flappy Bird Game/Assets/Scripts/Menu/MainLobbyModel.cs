using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbyModel
{
	public static List<PlayerProfile> EntireList;                // cała lista playerów
	public static PlayerProfile CurrentProfile;                      // profil aktualnego playera dla ProfileModel, nie jest znany przed zalogowaniem
	private static int _foundPlayerProfileID;

	public MainLobbyModel()
	{
		EntireList = PlayersProfiles.Instance.ListOfProfiles;                       // cała lista playerów

		if (LoginViewService.FoundPlayerProfileID == -1)                                    // jeśli lista playerów istnieje, ale nie ma na niej podanego NAME
		{
			_foundPlayerProfileID = EntireList.Count - 1;                                       // ID aktualnego gracza to ostatni element listy
		}
		else
		{
			_foundPlayerProfileID = LoginViewService.FoundPlayerProfileID;
		}
		CurrentProfile = EntireList[_foundPlayerProfileID];                      // profil aktualnego playera dla ProfileModel, nie jest znany przed zalogowaniem
	}
}
