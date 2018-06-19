using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerData
{
	public bool AchievementIsUnlocked { get; set; }                      // informuje czy podczas gry odblokowano nowe achievementy

	public int CurrentScore { get; set; }

	public CurrentPlayerData()
	{
		AchievementIsUnlocked = false;
		CurrentScore = 0;
	}
}
