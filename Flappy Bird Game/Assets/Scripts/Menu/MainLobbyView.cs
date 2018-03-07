using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbyView : MonoBehaviour
{
	private Rect _logoRect;
	private Rect _newGameRect;
	private Rect _howtoPlayRect;
	private Rect _creditsRect;
	private Rect _achievementsRect;
	private Rect _logoutRect;
	private Rect _profileRect;

	[SerializeField] private Texture LogoButton;                                            // umożliwia wykorzystanie modyfikatora private z dostępem do zmiennej w ramach inspectora unity
	public Texture AchievementsButton;
	public Texture CreditsButton;
	public Texture HowtoPlayButton;
	public Texture NewGameButton;
	public Texture StartButton;
	public Texture ProfileButton;
	public Texture LogoutButton;

	private ResizeViewService ResizeViewService;
	private DrawElementViewService DrawElementViewService;

	public MainLobbyModel MainLobbyModel;
	private MainLobbyModel _model;

	private void Start()
	{
		ResizeViewService = new ResizeViewService();
		DrawElementViewService = new DrawElementViewService();
	}



	public void SetModel(MainLobbyModel model)
	{
		_model = model;
	}

	public MainLobbyModel GetModel()
	{
		return _model;
	}



	public void DrawMainMenu()                             // obsluga MAIN MENU
	{
		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.top);
		_newGameRect = DrawElementViewService.DrawElement(300, 220, 200, 60, NewGameButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_howtoPlayRect = DrawElementViewService.DrawElement(300, 300, 200, 60, HowtoPlayButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_creditsRect = DrawElementViewService.DrawElement(300, 380, 200, 60, CreditsButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_achievementsRect = DrawElementViewService.DrawElement(300, 460, 200, 60, AchievementsButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_profileRect = DrawElementViewService.DrawElement(300, 540, 100, 30, ProfileButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_logoutRect = DrawElementViewService.DrawElement(400, 540, 100, 30, LogoutButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);

		if (Input.GetMouseButtonDown(0))
		{

			// LOGO - MAIN MENU						
			if (ResizeViewService.ClickedWithin(_logoRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
			}

			// NEW GAME
			else if (ResizeViewService.ClickedWithin(_newGameRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.NewGame;
			}

			// HOW TO PLAY
			else if (ResizeViewService.ClickedWithin(_howtoPlayRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.HowtoPlay;
			}

			// CREDITS
			else if (ResizeViewService.ClickedWithin(_creditsRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Credits;
			}

			// ACHIEVEMENTS
			else if (ResizeViewService.ClickedWithin(_achievementsRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;

			}

			// MY PROFILE
			else if (ResizeViewService.ClickedWithin(_profileRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Profile;
			}

			// LOGOUT 
			else if (ResizeViewService.ClickedWithin(_logoutRect))
			{
				LoginView.JustPlayerName = "";
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Login;
			}
		}
	}
}
