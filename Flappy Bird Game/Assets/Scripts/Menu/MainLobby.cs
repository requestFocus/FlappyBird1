using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLobby : MonoBehaviour {

	public MainLobbyView MainLobbyView;
	public LoginView LoginView;
	public HowToPlayView HowToPlayView;
	public CreditsView CreditsView;
	public ProfileView ProfileView;
	public AchievementsView AchievementsView;

	public static bool BackFromGamePlay;

	private void Start()
	{
		//PlayerPrefs.DeleteAll();

		if (!BackFromGamePlay)													// jeśli uruchomiono aplikacje, ale nie rozegrano gry
		{
			MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Login;
		}
		else                                                                    // jeśli nastąpil powrot z gry i przeładowano scene z GAME na MENU
		{
			MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
		}
	}



	private void OnGUI()
	{
		switch (MenuScreensService.MenuStates)
		{
			case MenuScreensService.MenuScreens.Login:
				LoginView.DrawLoginMenu();
				break;
			case MenuScreensService.MenuScreens.MainMenu:
				MainLobbyView.DrawMainMenu();
				break;
			case MenuScreensService.MenuScreens.HowtoPlay:
				HowToPlayView.DrawHowtoPlayMenu();
				break;
			case MenuScreensService.MenuScreens.Credits:
				CreditsView.DrawCreditsMenu();
				break;
			case MenuScreensService.MenuScreens.Achievements:
				AchievementsView.DrawAchievementsMenu();
				break;
			case MenuScreensService.MenuScreens.NewGame:
				StartNewGame();
				break;
			case MenuScreensService.MenuScreens.Profile:
				ProfileView.DrawProfileView();
				break;
		}
	}



	private void StartNewGame()               // obsluga NEW GAME
	{
		SceneManager.LoadScene("Game");
	}
}

