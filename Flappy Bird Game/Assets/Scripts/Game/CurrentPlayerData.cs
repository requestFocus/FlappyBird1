using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerData
{
	public PlayerProfile CurrentProfile { get; set; }
	public bool AchievementIsUnlocked { get; set; }                      // informuje czy podczas gry odblokowano nowe achievementy

	private int _currentScore;
	public int CurrentScore
	{
		get { return _currentScore; }
		set { _currentScore = value; }
	}

	public CurrentPlayerData()
	{
		CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID];
		AchievementIsUnlocked = false;
		CurrentScore = 0;
	}
}
