using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIGamePlayController : Controller<GUIGamePlayModel>
{
	/*
	 * nie jest to jeszcze aktualizacja Singletona, ten zostanie zaktualizowany w GUISummaryView
	 */

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
