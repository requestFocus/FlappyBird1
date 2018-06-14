using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLobbyView : View<MainLobbyModel, Controller<MainLobbyModel>>
{
	[SerializeField] private Image LogoButton;                                            // umożliwia wykorzystanie modyfikatora private z dostępem do zmiennej w ramach inspectora unity
	[SerializeField] private Button AchievementsButton;
	[SerializeField] private Button CreditsButton;
	[SerializeField] private Button HowtoPlayButton;
	[SerializeField] private Button NewGameButton;
	[SerializeField] private Button ProfileButton;
	[SerializeField] private Button LogoutButton;

	private LoginViewService LoginViewService;

	private void Start()
	{
		NewGameButton.onClick.AddListener(ClickNewGame);
		Debug.Log("main");

			//// LOGO - MAIN MENU						
			//if (_resizeViewService.ClickedWithin(_logoRect))
			//{
			//	MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
			//}

			//// NEW GAME
			//else if (_resizeViewService.ClickedWithin(_newGameRect))
			//{
			//	MenuScreensService.MenuStates = MenuScreensService.MenuScreens.NewGame;
			//}

			//// HOW TO PLAY
			//else if (_resizeViewService.ClickedWithin(_howtoPlayRect))
			//{
			//	MenuScreensService.MenuStates = MenuScreensService.MenuScreens.HowtoPlay;
			//}

			//// CREDITS
			//else if (_resizeViewService.ClickedWithin(_creditsRect))
			//{
			//	MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Credits;
			//}

			//// ACHIEVEMENTS
			//else if (_resizeViewService.ClickedWithin(_achievementsRect))
			//{
			//	MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;
			//	AchievementsView.Model = new AchievementsModel()
			//	{
			//		EntireList = Model.EntireList,             
			//		CurrentProfile = Model.CurrentProfile
			//	};
			//}

			//// MY PROFILE
			//else if (_resizeViewService.ClickedWithin(_profileRect))
			//{
			//	MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Profile;
			//	ProfileView.Model = new ProfileModel()
			//	{
			//		CurrentProfile = Model.CurrentProfile
			//	};
			//}

			//// LOGOUT 
			//else if (_resizeViewService.ClickedWithin(_logoutRect))
			//{
			//	MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Login;
			//}
	}

	private void ClickNewGame()
	{
		Debug.Log("start new game");
	}


}
