using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GUIGamePlayController : Controller<GUIGamePlayModel>
{
	/*
	 * nie jest to jeszcze aktualizacja Singletona, ten zostanie zaktualizowany w GUISummaryView
	 * 
	 * osobne funkcje unlockujące achievementy, bo przecież ostatecznie mogą to być achievementy o zupełnie innych kryteriach
	 */

	//[Inject]
	//public CurrentPlayerData _currentPlayerData;

	//public void SetState(CurrentGameStateService.GameStates state)
	//{
	//	CurrentGameStateService.CurrentGameState = state;
	//	ViewManager ViewManager = GameObject.FindObjectOfType<ViewManager>();
	//	ViewManager.SwitchView();
	//}

	//public void AssignAchievementComplete10()
	//{
	//	_currentPlayerData.CurrentProfile.Complete10 = true;
	//	_currentPlayerData.AchievementIsUnlocked = true;
	//}

	//public void AssignAchievementComplete25()
	//{
	//	_currentPlayerData.CurrentProfile.Complete25 = true;
	//	_currentPlayerData.AchievementIsUnlocked = true;
	//}

	//public void AssignAchievementComplete50()
	//{
	//	_currentPlayerData.CurrentProfile.Complete50 = true;
	//	_currentPlayerData.AchievementIsUnlocked = true;
	//}
}
