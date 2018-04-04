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


	public bool VerifyIfAchievementUnlocked(GUIGamePlayModel model, int currentScore)
	{
		if (currentScore == 2 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10)
		{
			Model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10 = true;
			Model.AchievementIsUnlocked = true;
			return true;
		}

		if (currentScore == 25 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25)
		{
			Model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25 = true;
			Model.AchievementIsUnlocked = true;
			return true;
		}

		if (currentScore == 50 && !model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50)
		{
			Model.PlayersProfilesLoadedToModel.ListOfProfiles[model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50 = true;
			Model.AchievementIsUnlocked = true;
			return true;
		}

		return false;
	}
}
