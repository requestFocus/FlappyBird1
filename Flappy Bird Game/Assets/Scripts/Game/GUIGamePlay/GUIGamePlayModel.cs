using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIGamePlayModel
{
	/*
	 * Model potrzebuje dostepu do:
	 * aktualnie zalogowanego profilu
	 */

	public PlayerProfile CurrentProfile;
	public bool AchievementIsUnlocked;                      // informuje czy podczas gry odblokowano nowe achievementy

	private int _currentScore;
	public int CurrentScore
	{
		get { return _currentScore; }
		set
		{
			_currentScore = value;
			//IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Locked;
		}
	}
}
