using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIGamePlayController
{
	/*
	 * Kontroler musi mieć dostęp do modelu, żeby go zaktualizować w przypadku zmiany
	 * 
	 * nie jest to jeszcze aktualizacja Singletona, ten zostanie zaktualizowany w GUISummaryView
	 */

	//public bool UnlockAchievement(GUIGamePlayModel model, int currentScore)
	//{
	//	if (currentScore == 10 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10)
	//	{
	//		model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10 = true;
	//		return true;
	//	}

	//	if (currentScore == 25 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25)
	//	{
	//		model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25 = true;
	//		return true;
	//	}

	//	if (currentScore == 50 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50)
	//	{
	//		model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50 = true;
	//		return true;
	//	}

	//	return false;
	//}

	public bool VerifyIfAchievementUnlocked(GUIGamePlayModel model, int currentScore)
	{
		if (currentScore == 10 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10)
		{
			model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10 = true;
			model.AchievementIsUnlocked = true;
			return true;
		}

		if (currentScore == 25 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25)
		{
			model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25 = true;
			model.AchievementIsUnlocked = true;
			return true;
		}

		if (currentScore == 50 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50)
		{
			model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50 = true;
			model.AchievementIsUnlocked = true;
			return true;
		}

		return false;
	}
}
