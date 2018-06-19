using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainLobbyView : View<MainLobbyModel, Controller<MainLobbyModel>>
{
	[SerializeField] private Image _logoButton;                                            // umożliwia wykorzystanie modyfikatora private z dostępem do zmiennej w ramach inspectora unity
	[SerializeField] private Button _achievementsButton;
	[SerializeField] private Button _creditsButton;
	[SerializeField] private Button _howToPlayButton;
	[SerializeField] private Button _newGameButton;
	[SerializeField] private Button _profileButton;
	[SerializeField] private Button _logoutButton;

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private DelegateService _delegateService;

	private void Start()
	{
		_newGameButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.NewGame);
		});

		_howToPlayButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.HowtoPlay);
		});

		_creditsButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.Credits);
		});

		_achievementsButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.Achievements);
		});

		_profileButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.Profile);
		});

		_logoutButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.Login);
		});
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
