using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbyView : View<MainLobbyModel>
{
	[SerializeField] private Texture LogoButton;                                            // umożliwia wykorzystanie modyfikatora private z dostępem do zmiennej w ramach inspectora unity
	[SerializeField] private Texture AchievementsButton;
	[SerializeField] private Texture CreditsButton;
	[SerializeField] private Texture HowtoPlayButton;
	[SerializeField] private Texture NewGameButton;
	[SerializeField] private Texture StartButton;
	[SerializeField] private Texture ProfileButton;
	[SerializeField] private Texture LogoutButton;

	[SerializeField] private ProfileView ProfileView;
	[SerializeField] private ProfileModel ProfileModel;
	[SerializeField] private AchievementsView AchievementsView;
	[SerializeField] private AchievementsModel AchievementsModel;

	private Rect _logoRect;
	private Rect _newGameRect;
	private Rect _howtoPlayRect;
	private Rect _creditsRect;
	private Rect _achievementsRect;
	private Rect _logoutRect;
	private Rect _profileRect;

	private ResizeViewService _resizeViewService;
	private DrawElementViewService _drawElementViewService;
	private LoginViewService LoginViewService;

	private void Start()
	{
		_resizeViewService = new ResizeViewService();
		_drawElementViewService = new DrawElementViewService();
	}

	public void DrawMainMenu()                             // obsluga MAIN MENU
	{
		_logoRect = _drawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.top);
		_newGameRect = _drawElementViewService.DrawElement(300, 220, 200, 60, NewGameButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_howtoPlayRect = _drawElementViewService.DrawElement(300, 300, 200, 60, HowtoPlayButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_creditsRect = _drawElementViewService.DrawElement(300, 380, 200, 60, CreditsButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_achievementsRect = _drawElementViewService.DrawElement(300, 460, 200, 60, AchievementsButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_profileRect = _drawElementViewService.DrawElement(300, 540, 100, 30, ProfileButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_logoutRect = _drawElementViewService.DrawElement(400, 540, 100, 30, LogoutButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);

		if (Input.GetMouseButtonDown(0))
		{

			// LOGO - MAIN MENU						
			if (_resizeViewService.ClickedWithin(_logoRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
			}

			// NEW GAME
			else if (_resizeViewService.ClickedWithin(_newGameRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.NewGame;
			}

			// HOW TO PLAY
			else if (_resizeViewService.ClickedWithin(_howtoPlayRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.HowtoPlay;
			}

			// CREDITS
			else if (_resizeViewService.ClickedWithin(_creditsRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Credits;
			}

			// ACHIEVEMENTS
			else if (_resizeViewService.ClickedWithin(_achievementsRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;
				AchievementsModel = new AchievementsModel()
				{
					EntireList = _Model.EntireList,             
					CurrentProfile = _Model.CurrentProfile
				};
				AchievementsView.SetModel(AchievementsModel);
			}

			// MY PROFILE
			else if (_resizeViewService.ClickedWithin(_profileRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Profile;
				ProfileModel = new ProfileModel()
				{
					CurrentProfile = _Model.CurrentProfile
				};
				ProfileView.SetModel(ProfileModel);
			}

			// LOGOUT 
			else if (_resizeViewService.ClickedWithin(_logoutRect))
			{
				LoginView.JustPlayerName = "";
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Login;
			}
		}
	}
}
