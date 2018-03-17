using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsModel : Model
{
	public List<PlayerProfile> EntireList;                // cała lista playerów
	public PlayerProfile CurrentProfile;                  // profil aktualnego playera dla ProfileModel, nie jest znany przed zalogowaniem
}
