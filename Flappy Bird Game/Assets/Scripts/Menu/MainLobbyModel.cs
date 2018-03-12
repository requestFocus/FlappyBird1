using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbyModel
{
	public static List<PlayerProfile> EntireList;										// cała lista playerów
	public static PlayerProfile CurrentProfile;										    // profil aktualnego playera dla ProfileModel, nie jest znany przed zalogowaniem

	public MainLobbyModel()
	{
		EntireList = PlayersProfiles.Instance.ListOfProfiles;                           // cała lista playerów
		CurrentProfile = EntireList[PlayersProfiles.Instance.CurrentProfile];           // profil aktualnego playera dla ProfileModel, nie jest znany przed zalogowaniem
	}
}
