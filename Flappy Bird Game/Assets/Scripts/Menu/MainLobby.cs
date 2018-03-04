using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLobby : MonoBehaviour {

	[SerializeField] private Texture LogoButton;											// umożliwia wykorzystanie modyfikatora private z dostępem do zmiennej w ramach inspectora unity

	public Texture AchievementsButton;
	public Texture CreditsButton;
	public Texture HowtoPlayButton;
	public Texture NewGameButton;
	public Texture StartButton;
	public Texture ProfileButton;
	public Texture LogoutButton;

	//====== ACHIEVEMENTS
	public Texture Complete10Active;
	public Texture Complete10Inactive;
	public Texture Complete25Active;
	public Texture Complete25Inactive;
	public Texture Complete50Active;
	public Texture Complete50Inactive;

	public Texture AchievementsButtonInactive;
	public Texture NextAchievementPage;
	public Texture PreviousAchievementPage;

	private Rect _nextAchievementPage;
	private Rect _previousAchievementPage;
	private float _listAchievementsFrom;
	private float _listAchievementsTo;
	private float _scope;
	//=====================

	public LoginView LoginView;
	public HowToPlayView HowToPlayView;
	public CreditsView CreditsView;
	public ProfileView ProfileView;

	private PlayerProfileController PlayerProfileControllerMainMenu = new PlayerProfileController(); //=================================================================
	private ResizeControllerViewService ResizeControllerViewService = new ResizeControllerViewService();
	private DrawElementViewService DrawElementViewService = new DrawElementViewService();
	private SetGUIStyleViewService SetGUIStyleViewService = new SetGUIStyleViewService();

	//public static PlayerProfile PlayerProfile;
	public static bool BackFromGamePlay;

	private Rect _logoRect;
	private Rect _newGameRect;
	private Rect _howtoPlayRect;
	private Rect _creditsRect;
	private Rect _achievementsRect;
	private Rect _logoutRect;
	private Rect _profileRect;

	public Vector2 MyMousePosition;
	private bool _isThereAList;
	private bool _isOnTheList;

	//public enum MenuScreens
	//{
	//	Login,
	//	MainMenu,
	//	HowtoPlay,
	//	Credits,
	//	Achievements,
	//	NewGame,
	//	GamePlay,
	//	Profile
	//};
	//public static MenuScreens MenuStates;



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

		SetGUIStyleViewService.SetGUIStyle();

		//_justPlayerName = "";
		_isThereAList = PlayerProfileControllerMainMenu.LoadProfiles();                             // jeśli lista istnieje, jej zawartość od razu wchodzi do singletona

		// do przemieszczania achievementow stronami
		_scope = 5;
		_listAchievementsFrom = 0;
		_listAchievementsTo = _scope;
	}



	private void Update()
	{

		//MyMousePosition = Event.current.mousePosition;
		//if (MenuScreensService.MenuStates.Equals(MenuScreensService.MenuScreens.Achievements))		//==========================ZBEDNE DO CZASU WYDZIELENIA ACHIEVEMENTOW
		//{
		//	CalculateStartAndEndPositionsForAchievementsForUpdate();                        // poza OnGUI, bo OnGUI wywoluje sie 2x na klatke, co zaburza zliczanie kliknięć
		//}
	}



	private void OnGUI()
	{
		switch (MenuScreensService.MenuStates)
		{
			case MenuScreensService.MenuScreens.Login:
				LoginView.DrawLoginMenu();
				break;
			case MenuScreensService.MenuScreens.MainMenu:
				DrawMainMenu();
				break;
			case MenuScreensService.MenuScreens.HowtoPlay:
				HowToPlayView.DrawHowtoPlayMenu();
				break;
			case MenuScreensService.MenuScreens.Credits:
				CreditsView.DrawCreditsMenu();
				break;
			case MenuScreensService.MenuScreens.Achievements:
				DrawAchievementsMenu(AchievementsButtonInactive);
				break;
			case MenuScreensService.MenuScreens.NewGame:
				StartNewGame();
				break;
			//case MenuScreensService.MenuScreens.GamePlay:
			//	StartNewGame();
			//	break;
			case MenuScreensService.MenuScreens.Profile:
				ProfileView.DrawProfileMenu();
				break;
		}
	}	



	//private void SetGUIStyle()
	//{
	//	_labelStyle = new GUIStyle
	//	{
	//		font = Font,
	//		fontSize = 14,
	//		alignment = TextAnchor.MiddleCenter
	//	};

	//	_labelContent = new GUIContent
	//	{
	//		text = ""
	//	};

	//	_darkGreyFont = "686868";                                     // dark grey
	//	_lightGreyFont = "3f6a84";                                     // dark grey
	//}



	//private Rect DrawElement(int x, int y, int width, int height, Texture menuElement, ResizeControllerViewService.Horizontal horizontalAlignment, ResizeControllerViewService.Vertical verticalAlignment)
	//{
	//	Rect RectScalableDimensions = ResizeControllerViewService.ResizeGUI(new Rect(x, y, width, height), horizontalAlignment, verticalAlignment);
	//	GUI.DrawTexture(RectScalableDimensions, menuElement);

	//	return RectScalableDimensions;
	//}



	//private void DrawLoginMenu()
	//{
	//	_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
	//	_justPlayerName = GUI.TextField(ResizeControllerViewService.ResizeGUI(new Rect(350, 270, 100, 25), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), _justPlayerName, 10);

	//	GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(350, 310, 100, 25), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle); // ENTER YOUR NAME label
	//	SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">Enter your name\nand click on the logo</color>";

	//	//_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
	//													 //_myMousePosition = Input.mousePosition;  

	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		if (ResizeControllerViewService.ClickedWithin(_logoRect))
	//		{
	//			if (_justPlayerName.Length > 0)
	//			{
	//				CheckPlayerPrefs();                         // jesli istnieje podany name w playerprefs, odpal LoadProfile i przypisz dane do pol obiektu
	//				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
	//				SetGUIStyleViewService.LabelContent.text = "";
	//			}
	//		}
	//	}
	//}



	private void DrawMainMenu()								// obsluga MAIN MENU
	{
		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
		_newGameRect = DrawElementViewService.DrawElement(300, 220, 200, 60, NewGameButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_howtoPlayRect = DrawElementViewService.DrawElement(300, 300, 200, 60, HowtoPlayButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_creditsRect = DrawElementViewService.DrawElement(300, 380, 200, 60, CreditsButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_achievementsRect = DrawElementViewService.DrawElement(300, 460, 200, 60, AchievementsButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_profileRect = DrawElementViewService.DrawElement(300, 540, 100, 30, ProfileButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_logoutRect = DrawElementViewService.DrawElement(400, 540, 100, 30, LogoutButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		MyMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

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



	//private void DrawProfileMenu(Texture menuElement)               // obsluga NEW GAME
	//{
	//	_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
	//	DrawElementViewService.DrawElement(350, 550, 100, 30, menuElement, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

	//	SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">NAME\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + PlayerProfile.PlayerName + "</color>\n\n" +
	//							"HIGHSCORE\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + PlayerProfile.HighScore + "</color>\n\n" +
	//							"ACHIEVEMENTS\n</color>";
	//	GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

	//	ListAchievements(PlayersProfiles.Instance.CurrentProfile, PlayerProfile, xPosition, yPosition);						// wypisuje achievementy dla zalogowanego playera
		
	//	//_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
	//													 //_myMousePosition = Input.mousePosition; operuje w przestrzeni bottom left top right

	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		if (ResizeControllerViewService.ClickedWithin(_logoRect))
	//		{
	//			MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
	//			SetGUIStyleViewService.LabelContent.text = "";
	//		}
	//	}
	//}


	
	private void StartNewGame()               // obsluga NEW GAME
	{
		//MenuScreensService.MenuStates = MenuScreensService.MenuScreens.GamePlay;
		SceneManager.LoadScene("Game");
	}



	//private void DrawCreditsMenu(Texture menuElement)               // obsluga CREDITS
	//{ 
	//	_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
	//	DrawElementViewService.DrawElement(350, 550, 100, 30, menuElement, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

	//	SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">PROGRAMMING / DESIGN\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">MACIEJ NIEŚCIORUK</color>\n\n" +
	//							"GRAPHICS\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">INTERNET</color>\n\n" +
	//							"SPECIAL THANKS TO\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">MICHAŁ PODYMA</color></color>";
	//	GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

	//	//_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
	//	 //_myMousePosition = Input.mousePosition;

	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		if (ResizeControllerViewService.ClickedWithin(_logoRect))
	//		{
	//			MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
	//			SetGUIStyleViewService.LabelContent.text = "";
	//		}
	//	}
	//}



	private void DrawAchievementsMenu(Texture menuElement)
	{
		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
		DrawElementViewService.DrawElement(350, 550, 100, 30, menuElement, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		if (_isThereAList)                                                                            // jesli istnieje lista w pamieci
		{
			ListNameScoreAchievements(_listAchievementsFrom, _listAchievementsTo);
			//ListAchievementsWithMasking();
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">No results yet.</color>", SetGUIStyleViewService.LabelStyle);
		}

		//_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeControllerViewService.ClickedWithin(_logoRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
				SetGUIStyleViewService.LabelContent.text = "";

				_listAchievementsFrom = 0;
				_listAchievementsTo = _scope;
			}
		}
	}



	//private void DrawHowtoPlayMenu(Texture menuElement) 
	//{
	//	_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
	//	DrawElementViewService.DrawElement(350, 550, 100, 30, menuElement, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

	//	SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">USE ARROWS ( <color=#" + SetGUIStyleViewService.LightGreyFont + ">↑</color> / <color=#" + SetGUIStyleViewService.LightGreyFont + ">↓</color> ) TO CONTROL THE BEE\n\n" +
	//					"BEAT HIGHSCORES, UNLOCK ACHIEVEMENTS \nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!</color>";
	//	GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

	//	//_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
	//	 //_myMousePosition = Input.mousePosition;

	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		if (ResizeControllerViewService.ClickedWithin(_logoRect))
	//		{
	//			MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
	//			SetGUIStyleViewService.LabelContent.text = "";
	//		}
	//	}
	//}



	//private void CheckPlayerPrefs()															// ładowane po kliknieciu LOGO w menu LOGIN po podaniu username
	//{
	//	_isOnTheList = false;

	//	if (_isThereAList)																	 // jesli istnieje lista w pamieci
	//	{
	//		for (int i = 0; i < PlayersProfiles.Instance.ListOfProfiles.Count; i++)					// parsuje całą listę obiektów
	//		{
	//			if (PlayersProfiles.Instance.ListOfProfiles[i].PlayerName.Equals(LoginView.JustPlayerName))   // sprawdza czy podane NAME istnieje w pamięci
	//			{
	//				PlayerProfile = PlayersProfiles.Instance.ListOfProfiles[i];                 // odnaleziony profil, uzywany przy listowaniu achievementow
	//				PlayersProfiles.Instance.CurrentProfile = i;                                    // ID znalezionego profilu
	//				_isOnTheList = true;
	//				break;
	//			}
	//		}

	//		if (!_isOnTheList)																					// jesli na liscie nie wystepuje podane NAME
	//		{
	//			AddNewProfile();
	//		}
	//	}
	//	else                                                                                            // jesli w pamieci nie istnieje lista userów
	//	{
	//		AddNewProfile();
	//	}
	//}



	//private void AddNewProfile()
	//{
	//	PlayerProfile = new PlayerProfile(LoginView.JustPlayerName, 0, false, false, false);          // tworzę nowy profil gracza z domyślnymi wartościami
	//	if (_isThereAList)                                                                  // na liście nie ma podanego NAME
	//	{
	//		PlayersProfiles.Instance.ListOfProfiles.Add(PlayerProfile);                     // a teraz dodaje do niej aktualny playerProfile
	//		PlayersProfiles.Instance.CurrentProfile = PlayersProfiles.Instance.ListOfProfiles.Count - 1;         // nadanie nowemu userowi najwyzszego numeru na liscie
	//	}
	//	else
	//	{
	//		PlayersProfiles.Instance.ListOfProfiles = new List<PlayerProfile> {            // tworzę listę, bo _isThereAList == false
	//			PlayerProfile																// a teraz dodaje do niej aktualny playerProfile
	//		};
	//		PlayersProfiles.Instance.CurrentProfile = 0;                                    // nadaję userowi pierwszy numer na liście
	//	}
	//	PlayerProfileController.SaveProfile(PlayersProfiles.Instance);                  // zapisuję dane w singletonie				
	//}



	private void ListNameScoreAchievements(float listFrom, float listTo)                                                         
	{
		// LABELS
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(200, 240, 150, 30), ResizeControllerViewService.Horizontal.left, ResizeControllerViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">NAME</color>", SetGUIStyleViewService.LabelStyle);
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 240, 150, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">HIGHSCORE</color>", SetGUIStyleViewService.LabelStyle);
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(430, 240, 150, 30), ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">ACHIEVEMENTS</color>", SetGUIStyleViewService.LabelStyle);

		// BUTTONS
		_previousAchievementPage = DrawElementViewService.DrawElement(376, 430, 16, 18, PreviousAchievementPage, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_nextAchievementPage = DrawElementViewService.DrawElement(410, 430, 16, 18, NextAchievementPage, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		int yPosition = 270;
		int xPosition = 465;

		for (int i = (int)listFrom; i < PlayersProfiles.Instance.ListOfProfiles.Count && i < (int)listTo; i++)								// wypisze liste userów od A do B
			{
				// PLAYERNAME
				GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(200, yPosition, 150, 30), ResizeControllerViewService.Horizontal.left, ResizeControllerViewService.Vertical.center),
							"<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].PlayerName + "</color>", SetGUIStyleViewService.LabelStyle);

				// HIGHSCORE
				GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, yPosition, 150, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center),
							"<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].HighScore + "</color>", SetGUIStyleViewService.LabelStyle);

				// ACHIEVEMENTS
				ListAchievements(i, PlayersProfiles.Instance.ListOfProfiles[i], xPosition, yPosition);						// wypisuje achievementy dla aktualnie parsowanego w pętli obiektu

				yPosition += 30;
				xPosition = 465;
			}

		//CalculateStartAndEndPositionsForAchievementsForOnGUI();
		MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;
	}



	private void ListAchievements(int currentProfile, PlayerProfile playerProfile, int xPosition, int yPosition)
	{
		if (playerProfile.Complete10)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);         // IKONY ACHIEVEMENTOW MAJA WYMIARY 96x110
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}

		xPosition += 30;
		if (playerProfile.Complete25)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}

		xPosition += 30;
		if (playerProfile.Complete50)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}
	}



	private void CalculateStartAndEndPositionsForAchievementsForUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeControllerViewService.ClickedWithin(_previousAchievementPage) && _listAchievementsFrom > 0)
			{
				_listAchievementsFrom -= _scope;
				_listAchievementsTo -= _scope;
			}

			if (ResizeControllerViewService.ClickedWithin(_nextAchievementPage) && _listAchievementsTo < PlayersProfiles.Instance.ListOfProfiles.Count)
			{
				_listAchievementsFrom += _scope;
				_listAchievementsTo += _scope;
			}
		}
	}



	//private void CalculateStartAndEndPositionsForAchievementsForOnGUI()
	//{
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		if (ClickedWithin(_nextAchievementPage) && _listAchievementsTo < PlayersProfiles.Instance.ListOfProfiles.Count)
	//		{
	//			_listAchievementsFrom += (_scope / 2);
	//			_listAchievementsTo += (_scope / 2);
	//		}
	//		else if (ClickedWithin(_nextAchievementPage) && _listAchievementsTo % 2 != 0 && (_listAchievementsFrom + (_scope / 2)) < PlayersProfiles.Instance.ListOfProfiles.Count)
	//		{
	//			_listAchievementsFrom += (_scope / 2);
	//			_listAchievementsTo += (_scope / 2);
	//		}

	//		if (ClickedWithin(_previousAchievementPage) && _listAchievementsFrom > 0)
	//		{
	//			_listAchievementsFrom -= (_scope / 2);
	//			_listAchievementsTo -= (_scope / 2);
	//		}
	//	}
	//}



	//private bool ClickedWithin(Rect rect)
	//{
	//	return ((_myMousePosition.x >= rect.x) && (_myMousePosition.x <= (rect.x + rect.width)) && (_myMousePosition.y >= rect.y) && (_myMousePosition.y <= (rect.y + rect.height)));
	//}
}

