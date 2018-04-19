using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGamePlayModel
{
	PlayerProfile CurrentProfile { get; set; }
	bool AchievementIsUnlocked { get; set; }  
	int CurrentScore { get; set; }
}