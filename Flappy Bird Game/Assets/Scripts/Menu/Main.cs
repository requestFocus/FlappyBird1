using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	public static bool BackFromGamePlay;

	[SerializeField] private MainLobbyView MainLobbyView;
	[SerializeField] private LoginView LoginView;
	[SerializeField] private HowToPlayView HowToPlayView;
	[SerializeField] private CreditsView CreditsView;
	[SerializeField] private ProfileView ProfileView;
	[SerializeField] private AchievementsView AchievementsView;

	[SerializeField] private MainLobbyModel MainLobbyModel;

	private LoginViewService _loginViewService;

	private void Start()
	{
		//PlayerPrefs.DeleteAll();                                                // CZYSZCZENIE PLAYERPREFS

		Time.timeScale = 1;
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
				MainLobbyView.Model = new MainLobbyModel()
				{
					EntireList = PlayersProfiles.Instance.ListOfProfiles,
					CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID]
				};

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
				SceneManager.LoadScene("Game");
				break;

			case MenuScreensService.MenuScreens.Profile:
				ProfileView.DrawProfileView();
				break;
		}
	}
}

