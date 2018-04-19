using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISummaryModel
{
	/*
	 * Model potrzebuje dostepu do:
	 * całego singletona, bo GUISummaryController będzie zapisywał wszystkie zmiany z GUIGamePlayView do PlayerPrefs i struktura jsona musi się zgadzać
	 */

	public PlayerProfile CurrentProfile;
	public PlayersProfiles PlayersProfilesUpdated;
	public bool AchievementIsUnlocked;

	private int _currentScore;
	public int CurrentScore
	{
		get { return _currentScore; }
		set { _currentScore = value; }
	}
}
