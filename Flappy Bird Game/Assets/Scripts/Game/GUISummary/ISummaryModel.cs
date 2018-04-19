using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISummaryModel
{
	PlayerProfile CurrentProfile { get; set; } 
	PlayersProfiles PlayersProfilesUpdated { get; set; }
	bool AchievementIsUnlocked { get; set; }
	int CurrentScore { get; set; }
}
