using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIGamePlayController : Controller<GUIGamePlayModel>
{
	/*
	 * Kontroler musi mieć dostęp do modelu, żeby go zaktualizować w przypadku zmiany
	 * 
	 * nie jest to jeszcze aktualizacja Singletona, ten zostanie zaktualizowany w GUISummaryView
	 */


	//public bool VerifyIfAchievementUnlocked(int currentScore)
	//{
	//	if (currentScore == 2 && !Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10)
	//	{
	//		Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10 = true;
	//		Model.AchievementIsUnlocked = true;
	//		return true;
	//	}

	//	if (currentScore == 25 && !Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25)
	//	{
	//		Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25 = true;
	//		Model.AchievementIsUnlocked = true;
	//		return true;
	//	}

	//	if (currentScore == 50 && !Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50)
	//	{
	//		Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50 = true;
	//		Model.AchievementIsUnlocked = true;
	//		return true;
	//	}

	//	return false;
	//}

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
