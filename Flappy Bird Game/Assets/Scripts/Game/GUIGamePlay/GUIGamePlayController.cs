using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIGamePlayController : Controller<GUIGamePlayModel>
{
	/*
	 * nie jest to jeszcze aktualizacja Singletona, ten zostanie zaktualizowany w GUISummaryView
	 * 
	 * osobne funkcje unlockujące achievementy, bo przecież ostatecznie mogą to być achievementy o zupełnie innych kryteriach
	 */

	public void SetState(CurrentGameStateService.GameStates state)
	{
		CurrentGameStateService.CurrentGameState = state;
		ViewManager ViewManager = GameObject.FindObjectOfType<ViewManager>();
		ViewManager.SwitchView();
	}

	public void AssignAchievementComplete10()
	{
		Model.CurrentProfile.Complete10 = true;
		Model.AchievementIsUnlocked = true;
	}

	public void AssignAchievementComplete25()
	{
		Model.CurrentProfile.Complete25 = true;
		Model.AchievementIsUnlocked = true;
	}

	public void AssignAchievementComplete50()
	{
		Model.CurrentProfile.Complete50 = true;
		Model.AchievementIsUnlocked = true;
	}
}
