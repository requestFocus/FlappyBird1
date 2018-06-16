﻿using System.Collections;
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

	public delegate void OnStateSet(MenuScreensService.MenuScreens state);
	public OnStateSet OnStateSetDel;

	private void Awake()
	{
		Model = new MainLobbyModel()
		{
			EntireList = PlayersProfiles.Instance.ListOfProfiles,
			CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID]
		};
	}

	private void Start()
	{
		NewGameButton.onClick.AddListener(ClickNewGame);
		HowtoPlayButton.onClick.AddListener(ClickHowToPlay);
		CreditsButton.onClick.AddListener(ClickCredits);
		AchievementsButton.onClick.AddListener(ClickAchievements);
		ProfileButton.onClick.AddListener(ClickProfile);
		LogoutButton.onClick.AddListener(ClickLogout);
	}

	private void ClickNewGame()
	{
		OnStateSetDel(MenuScreensService.MenuScreens.NewGame);
		Destroy(gameObject);
	}

	private void ClickHowToPlay()
	{
		OnStateSetDel(MenuScreensService.MenuScreens.HowtoPlay);
		Destroy(gameObject);
	}

	private void ClickCredits()
	{
		OnStateSetDel(MenuScreensService.MenuScreens.Credits);
		Destroy(gameObject);
	}


	private void ClickLogout()
	{
		OnStateSetDel(MenuScreensService.MenuScreens.Login);
		Destroy(gameObject);
	}


	private void ClickProfile()
	{
		OnStateSetDel(MenuScreensService.MenuScreens.Profile);
		Destroy(gameObject);
	}


	private void ClickAchievements()
	{
		OnStateSetDel(MenuScreensService.MenuScreens.Achievements);
		Destroy(gameObject);
	}

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
