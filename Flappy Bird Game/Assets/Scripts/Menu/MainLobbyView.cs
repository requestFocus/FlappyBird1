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

	private ResizeControllerViewService ResizeControllerViewService;
	private DrawElementViewService DrawElementViewService;
	private SetGUIStyleViewService SetGUIStyleViewService;

	private void Start()
	{
		ResizeControllerViewService = new ResizeControllerViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
	}


	public void DrawMainMenu()                             // obsluga MAIN MENU
	{
		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
		_newGameRect = DrawElementViewService.DrawElement(300, 220, 200, 60, NewGameButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_howtoPlayRect = DrawElementViewService.DrawElement(300, 300, 200, 60, HowtoPlayButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_creditsRect = DrawElementViewService.DrawElement(300, 380, 200, 60, CreditsButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_achievementsRect = DrawElementViewService.DrawElement(300, 460, 200, 60, AchievementsButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_profileRect = DrawElementViewService.DrawElement(300, 540, 100, 30, ProfileButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_logoutRect = DrawElementViewService.DrawElement(400, 540, 100, 30, LogoutButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		//MyMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{

			// LOGO - MAIN MENU						
			if (ResizeControllerViewService.ClickedWithin(_logoRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
			}

			// NEW GAME
			else if (ResizeControllerViewService.ClickedWithin(_newGameRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.NewGame;
			}

			// HOW TO PLAY
			else if (ResizeControllerViewService.ClickedWithin(_howtoPlayRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.HowtoPlay;
			}

			// CREDITS
			else if (ResizeControllerViewService.ClickedWithin(_creditsRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Credits;
			}

			// ACHIEVEMENTS
			else if (ResizeControllerViewService.ClickedWithin(_achievementsRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;

			}

			// MY PROFILE
			else if (ResizeControllerViewService.ClickedWithin(_profileRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Profile;
			}

			// LOGOUT 
			else if (ResizeControllerViewService.ClickedWithin(_logoutRect))
			{
				LoginView.JustPlayerName = "";
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Login;
			}
		}
	}
}
