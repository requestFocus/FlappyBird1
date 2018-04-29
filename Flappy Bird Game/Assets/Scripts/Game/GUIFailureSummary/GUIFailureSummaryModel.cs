using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIFailureSummaryModel
{
	/*
	 * Model potrzebuje dostepu do:
	 * całego singletona, bo GUISummaryController będzie zapisywał wszystkie zmiany z GUIGamePlayView do PlayerPrefs i struktura jsona musi się zgadzać
	 */

	public PlayerProfile CurrentProfile { get; set; }
	//public PlayersProfiles PlayersProfilesUpdated { get; set; }
	public bool AchievementIsUnlocked { get; set; }
	public string GameOutcome { get; set; }

	private int _currentScore;
	public int CurrentScore
	{
		get { return _currentScore; }
		set { _currentScore = value; }
	}

	public GUIFailureSummaryModel(GUIGamePlayModel gamePlayModel)
	{
		CurrentProfile = gamePlayModel.CurrentProfile;
		AchievementIsUnlocked = gamePlayModel.AchievementIsUnlocked;
		//PlayersProfilesUpdated = PlayersProfiles.Instance;
		CurrentScore = gamePlayModel.CurrentScore;
		GameOutcome = "Failure";
	}
}
