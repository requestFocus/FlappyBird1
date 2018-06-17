using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuManager : MonoBehaviour {

	public static bool BackFromGamePlay;

	[Inject]
	private MenuFactory _menuFactory;

	[Inject]
	private MenuScreensService _menuScreensService;

	private void Awake()
	{
		//PlayerPrefs.DeleteAll();                                                // CZYSZCZENIE PLAYERPREFS

		if (!BackFromGamePlay)                                                  // jeśli uruchomiono aplikacje, ale nie rozegrano gry
		{
			SetState(MenuScreensService.MenuScreens.Login);
		}
		else                                                                    // jeśli nastąpil powrot z gry i przeładowano scene z GAME na MENU
		{
			SetState(MenuScreensService.MenuScreens.MainMenu);
		}
	}

	public void SwitchView()
	{ 
		switch (_menuScreensService.MenuStates)
		{
			case MenuScreensService.MenuScreens.Login:
				LoginView loginView = _menuFactory.CreateConcreteLoginView();
				loginView.OnLoginViewSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.MainMenu:
				MainLobbyView mainLobbyView = _menuFactory.CreateConcreteMainLobbyView();
				mainLobbyView.OnStateSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.HowtoPlay:
				HowToPlayView howToPlay = _menuFactory.CreateConcreteHowToPlayView();
				howToPlay.OnHowToPlayViewSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.Credits:
				CreditsView creditsView = _menuFactory.CreateConcreteCreditsView();
				creditsView.OnCreditsViewSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.Achievements:
				AchievementsView achievementsView = _menuFactory.CreateConcreteAchievementsView();
				achievementsView.OnAchievementsViewSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.Profile:
				ProfileView profileView = _menuFactory.CreateConcreteProfileView();
				profileView.OnProfileViewSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.NewGame:
				SceneManager.LoadScene("Game");
				break;
		}
	}

	public void SetState(MenuScreensService.MenuScreens state)
	{
		_menuScreensService.MenuStates = state;
		SwitchView();
	}
}

