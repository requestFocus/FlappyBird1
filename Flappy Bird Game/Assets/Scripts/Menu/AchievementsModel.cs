using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsModel
{
	public static List<PlayerProfile> EntireList;                // cała lista playerów

	public AchievementsModel()
	{
		EntireList = MainLobbyModel.EntireList;                // cała lista playerów
	}
}
