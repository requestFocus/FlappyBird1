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

	public Texture Complete10Active;
	public Texture Complete10Inactive;
	public Texture Complete25Active;
	public Texture Complete25Inactive;
	public Texture Complete50Active;
	public Texture Complete50Inactive;

	public Texture AchievementsButtonInactive;
	public Texture CreditsButtonInactive;
	public Texture HowtoPlayButtonInactive;
	public Texture NewGameButtonInactive;
	public Texture ProfileButtonInactive;

	public Texture NextAchievementPage;
	public Texture PreviousAchievementPage;

	public Font font;

	public PlayerProfileController PlayerProfileController;				
	public ResizeController ResizeController;

	public static PlayerProfile PlayerProfile;
	public static bool BackFromGamePlay;

	private GUIStyle _labelStyle;
	private GUIContent _labelContent;
	private string _darkGreyFont;
	private string _lightGreyFont;
	
	private Rect _logoRect;
	private Rect _newGameRect;
	private Rect _howtoPlayRect;
	private Rect _creditsRect;
	private Rect _achievementsRect;
	private Rect _startRect;
	private Rect _gamePlayRect;
	private Rect _logoutRect;
	private Rect _profileRect;

	private Rect _nextAchievementPage;
	private Rect _previousAchievementPage;
	private float _listAchievementsFrom;
	private float _listAchievementsTo;
	private float _scope;

	private Vector2 _myMousePosition;
	private string _justPlayerName;
	private string _badName;
	private bool _isThereAList;
	private bool _isOnTheList;
	
	private enum MenuScreens
	{
		Login,
		MainMenu,
		HowtoPlay,
		Credits,
		Achievements,
		NewGame,
		GamePlay,
		Profile
	};
	MenuScreens MenuStates;



	private void Start()
	{
		//PlayerPrefs.DeleteAll();
		
		if (!BackFromGamePlay)													// jeśli uruchomiono aplikacje, ale nie rozegrano gry
		{
			MenuStates = MenuScreens.Login;
		}
		else																	// jeśli nastąpil powrot z gry i przeładowano scene z GAME na MENU
		{
			MenuStates = MenuScreens.MainMenu;
		}

		SetGUIStyle();

		_justPlayerName = "";
		_isThereAList = PlayerProfileController.LoadProfiles();                             // jeśli lista istnieje, jej zawartość od razu wchodzi do singletona

		// do przemieszczania achievementow stronami
		_scope = 5;
		_listAchievementsFrom = 0;
		_listAchievementsTo = _scope;
	}



	private void Update()
	{
		if (MenuStates.Equals(MenuScreens.Achievements))
		{
			CalculateStartAndEndPositionsForAchievementsForUpdate();                        // poza OnGUI, bo OnGUI wywoluje sie 2x na klatke, co zaburza zliczanie kliknięć
		}
	}



	private void OnGUI()
	{
		switch (MenuStates)
		{
			case MenuScreens.Login:
				DrawLoginMenu();
				break;
			case MenuScreens.MainMenu:
				DrawMainMenu();
				break;
			case MenuScreens.HowtoPlay:
				DrawHowtoPlayMenu(HowtoPlayButtonInactive);
				break;
			case MenuScreens.Credits:
				DrawCreditsMenu(CreditsButtonInactive);
				break;
			case MenuScreens.Achievements:
				DrawAchievementsMenu(AchievementsButtonInactive);
				break;
			case MenuScreens.NewGame:
				DrawNewGameMenu(NewGameButtonInactive);
				break;
			case MenuScreens.GamePlay:
				DrawGamePlay();
				break;
			case MenuScreens.Profile:
				DrawProfileMenu(ProfileButtonInactive);
				break;
		}
	}	



	private void SetGUIStyle()
	{
		_labelStyle = new GUIStyle
		{
			font = font,
			fontSize = 14,
			alignment = TextAnchor.MiddleCenter
		};

		_labelContent = new GUIContent
		{
			text = ""
		};

		_darkGreyFont = "686868";                                     // dark grey
		_lightGreyFont = "3f6a84";                                     // dark grey
	}



	private Rect DrawElement(int x, int y, int width, int height, Texture menuElement, ResizeController.Horizontal horizontalAlignment, ResizeController.Vertical verticalAlignment)
	{
		Rect RectScalableDimensions = ResizeController.ResizeGUI(new Rect(x, y, width, height), horizontalAlignment, verticalAlignment);
		GUI.DrawTexture(RectScalableDimensions, menuElement);

		return RectScalableDimensions;
	}



	private void DrawLoginMenu()
	{
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		_justPlayerName = GUI.TextField(ResizeController.ResizeGUI(new Rect(350, 270, 100, 25), ResizeController.Horizontal.center, ResizeController.Vertical.center), _justPlayerName, 10);

		GUI.Label(ResizeController.ResizeGUI(new Rect(350, 310, 100, 25), ResizeController.Horizontal.center, ResizeController.Vertical.center), _labelContent, _labelStyle); // ENTER YOUR NAME label
		_labelContent.text = "<color=#" + _darkGreyFont + ">Enter your name\nand click on the logo</color>";

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
														 //_myMousePosition = Input.mousePosition;  

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				if (_justPlayerName.Length > 0)
				{
					CheckPlayerPrefs();                         // jesli istnieje podany name w playerprefs, odpal LoadProfile i przypisz dane do pol obiektu
					MenuStates = MenuScreens.MainMenu;
					_labelContent.text = "";
				}
			}
		}
	}



	private void DrawMainMenu()								// obsluga MAIN MENU
	{
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		_newGameRect = DrawElement(300, 220, 200, 60, NewGameButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_howtoPlayRect = DrawElement(300, 300, 200, 60, HowtoPlayButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_creditsRect = DrawElement(300, 380, 200, 60, CreditsButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_achievementsRect = DrawElement(300, 460, 200, 60, AchievementsButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_profileRect = DrawElement(300, 540, 100, 30, ProfileButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_logoutRect = DrawElement(400, 540, 100, 30, LogoutButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{

			// LOGO - MAIN MENU						
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}

			// NEW GAME
			else if (ClickedWithin(_newGameRect))
			{
				MenuStates = MenuScreens.NewGame;
			}

			// HOW TO PLAY
			else if (ClickedWithin(_howtoPlayRect))
			{
				MenuStates = MenuScreens.HowtoPlay;
			}

			// CREDITS
			else if (ClickedWithin(_creditsRect))
			{
				MenuStates = MenuScreens.Credits;
			}

			// ACHIEVEMENTS
			else if (ClickedWithin(_achievementsRect))
			{
				MenuStates = MenuScreens.Achievements;

			}

			// MY PROFILE
			else if (ClickedWithin(_profileRect))
			{
				MenuStates = MenuScreens.Profile;
			}

			// LOGOUT 
			else if (ClickedWithin(_logoutRect))
			{
				_justPlayerName = "";
				MenuStates = MenuScreens.Login;
			}
		}
	}



	private void DrawProfileMenu(Texture menuElement)               // obsluga NEW GAME
	{
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		DrawElement(350, 550, 100, 30, menuElement, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		_labelContent.text = "<color=#" + _darkGreyFont + ">NAME\n<color=#" + _lightGreyFont + ">" + PlayerProfile.PlayerName + "</color>\n\n" +
								"HIGHSCORE\n<color=#" + _lightGreyFont + ">" + PlayerProfile.HighScore + "</color>\n\n" +
								"ACHIEVEMENTS\n</color>";
		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 300, 200, 30), ResizeController.Horizontal.center, ResizeController.Vertical.center), _labelContent, _labelStyle);

		int yPosition = 370;
		int xPosition = 358;

		ListAchievements(PlayersProfiles.Instance.CurrentProfile, PlayerProfile, xPosition, yPosition);						// wypisuje achievementy dla zalogowanego playera
		
		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
														 //_myMousePosition = Input.mousePosition; operuje w przestrzeni bottom left top right

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
				_labelContent.text = "";
			}
		}
	}


	
	private void DrawNewGameMenu(Texture menuElement)               // obsluga NEW GAME
	{
		MenuStates = MenuScreens.GamePlay;
	}



	private void DrawGamePlay()										// GRA
	{
		SceneManager.LoadScene("Game");
	}



	private void DrawCreditsMenu(Texture menuElement)               // obsluga CREDITS
	{ 
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		DrawElement(350, 550, 100, 30, menuElement, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		_labelContent.text = "<color=#" + _darkGreyFont + ">PROGRAMMING / DESIGN\n<color=#" + _lightGreyFont + ">MACIEJ NIEŚCIORUK</color>\n\n" +
								"GRAPHICS\n<color=#" + _lightGreyFont + ">INTERNET</color>\n\n" +
								"SPECIAL THANKS TO\n<color=#" + _lightGreyFont + ">MICHAŁ PODYMA</color></color>";
		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 300, 200, 30), ResizeController.Horizontal.center, ResizeController.Vertical.center), _labelContent, _labelStyle);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
		 //_myMousePosition = Input.mousePosition;

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
				_labelContent.text = "";
			}
		}
	}



	private void DrawAchievementsMenu(Texture menuElement)
	{
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		DrawElement(350, 550, 100, 30, menuElement, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		if (_isThereAList)                                                                            // jesli istnieje lista w pamieci
		{
			ListNameScoreAchievements(_listAchievementsFrom, _listAchievementsTo);
			//ListAchievementsWithMasking();
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			GUI.Label(ResizeController.ResizeGUI(new Rect(300, 300, 200, 30), ResizeController.Horizontal.center, ResizeController.Vertical.center), "<color=#" + _darkGreyFont + ">No results yet.</color>", _labelStyle);
		}

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
				_labelContent.text = "";

				_listAchievementsFrom = 0;
				_listAchievementsTo = _scope;
			}
		}
	}



	private void DrawHowtoPlayMenu(Texture menuElement) 
	{
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		DrawElement(350, 550, 100, 30, menuElement, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		_labelContent.text = "<color=#" + _darkGreyFont + ">USE ARROWS ( <color=#" + _lightGreyFont + ">↑</color> / <color=#" + _lightGreyFont + ">↓</color> ) TO CONTROL THE BEE\n\n" +
						"BEAT HIGHSCORES, UNLOCK ACHIEVEMENTS \nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!</color>";
		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 300, 200, 30), ResizeController.Horizontal.center, ResizeController.Vertical.center), _labelContent, _labelStyle);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
		 //_myMousePosition = Input.mousePosition;

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
				_labelContent.text = "";
			}
		}
	}



	private void CheckPlayerPrefs()															// ładowane po kliknieciu LOGO w menu LOGIN po podaniu username
	{
		_isOnTheList = false;

		if (_isThereAList)																	 // jesli istnieje lista w pamieci
		{
			for (int i = 0; i < PlayersProfiles.Instance.ListOfProfiles.Count; i++)					// parsuje całą listę obiektów
			{
				if (PlayersProfiles.Instance.ListOfProfiles[i].PlayerName.Equals(_justPlayerName))   // sprawdza czy podane NAME istnieje w pamięci
				{
					PlayerProfile = PlayersProfiles.Instance.ListOfProfiles[i];                 // odnaleziony profil, uzywany przy listowaniu achievementow
					PlayersProfiles.Instance.CurrentProfile = i;                                    // ID znalezionego profilu
					_isOnTheList = true;
					break;
				}
			}

			if (!_isOnTheList)																					// jesli na liscie nie wystepuje podane NAME
			{
				AddNewProfile();
			}
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			AddNewProfile();
		}
	}



	private void AddNewProfile()
	{
		PlayerProfile = new PlayerProfile(_justPlayerName, 0, false, false, false);          // tworzę nowy profil gracza z domyślnymi wartościami
		if (_isThereAList)                                                                  // na liście nie ma podanego NAME
		{
			PlayersProfiles.Instance.ListOfProfiles.Add(PlayerProfile);                     // a teraz dodaje do niej aktualny playerProfile
			PlayersProfiles.Instance.CurrentProfile = PlayersProfiles.Instance.ListOfProfiles.Count - 1;         // nadanie nowemu userowi najwyzszego numeru na liscie
		}
		else
		{
			PlayersProfiles.Instance.ListOfProfiles = new List<PlayerProfile> {            // tworzę listę, bo _isThereAList == false
				PlayerProfile																// a teraz dodaje do niej aktualny playerProfile
			};
			PlayersProfiles.Instance.CurrentProfile = 0;                                    // nadaję userowi pierwszy numer na liście
		}
		PlayerProfileController.SaveProfile(PlayersProfiles.Instance);                  // zapisuję dane w singletonie				
	}



	private void ListNameScoreAchievements(float listFrom, float listTo)                                                         // ładowane po kliknieciu buttona START w menu NEW GAME
	{
		// LABELS
		GUI.Label(ResizeController.ResizeGUI(new Rect(200, 240, 150, 30), ResizeController.Horizontal.left, ResizeController.Vertical.center), "<color=#" + _darkGreyFont + ">NAME</color>", _labelStyle);
		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 240, 150, 30), ResizeController.Horizontal.center, ResizeController.Vertical.center), "<color=#" + _darkGreyFont + ">HIGHSCORE</color>", _labelStyle);
		GUI.Label(ResizeController.ResizeGUI(new Rect(430, 240, 150, 30), ResizeController.Horizontal.right, ResizeController.Vertical.center), "<color=#" + _darkGreyFont + ">ACHIEVEMENTS</color>", _labelStyle);

		// BUTTONS
		_previousAchievementPage = DrawElement(376, 430, 16, 18, PreviousAchievementPage, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_nextAchievementPage = DrawElement(410, 430, 16, 18, NextAchievementPage, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		int yPosition = 270;
		int xPosition = 465;

		for (int i = (int)listFrom; i < PlayersProfiles.Instance.ListOfProfiles.Count && i < (int)listTo; i++)								// wypisze liste userów od A do B
			{
				// PLAYERNAME
				GUI.Label(ResizeController.ResizeGUI(new Rect(200, yPosition, 150, 30), ResizeController.Horizontal.left, ResizeController.Vertical.center),
							"<color=#" + _lightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].PlayerName + "</color>", _labelStyle);

				// HIGHSCORE
				GUI.Label(ResizeController.ResizeGUI(new Rect(300, yPosition, 150, 30), ResizeController.Horizontal.center, ResizeController.Vertical.center),
							"<color=#" + _lightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].HighScore + "</color>", _labelStyle);

				// ACHIEVEMENTS
				ListAchievements(i, PlayersProfiles.Instance.ListOfProfiles[i], xPosition, yPosition);						// wypisuje achievementy dla aktualnie parsowanego w pętli obiektu

				yPosition += 30;
				xPosition = 465;
			}

		//CalculateStartAndEndPositionsForAchievementsForOnGUI();
		MenuStates = MenuScreens.Achievements;
	}



	private void ListAchievements(int currentProfile, PlayerProfile playerProfile, int xPosition, int yPosition)
	{
		if (playerProfile.Complete10)
		{
			DrawElement(xPosition, yPosition, 23, 28, Complete10Active, ResizeController.Horizontal.right, ResizeController.Vertical.center);         // IKONY ACHIEVEMENTOW MAJA WYMIARY 96x110
		}
		else
		{
			DrawElement(xPosition, yPosition, 23, 28, Complete10Inactive, ResizeController.Horizontal.right, ResizeController.Vertical.center);
		}

		xPosition += 30;
		if (playerProfile.Complete25)
		{
			DrawElement(xPosition, yPosition, 23, 28, Complete25Active, ResizeController.Horizontal.right, ResizeController.Vertical.center);
		}
		else
		{
			DrawElement(xPosition, yPosition, 23, 28, Complete25Inactive, ResizeController.Horizontal.right, ResizeController.Vertical.center);
		}

		xPosition += 30;
		if (playerProfile.Complete50)
		{
			DrawElement(xPosition, yPosition, 23, 28, Complete50Active, ResizeController.Horizontal.right, ResizeController.Vertical.center);
		}
		else
		{
			DrawElement(xPosition, yPosition, 23, 28, Complete50Inactive, ResizeController.Horizontal.right, ResizeController.Vertical.center);
		}
	}



	private void CalculateStartAndEndPositionsForAchievementsForUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_previousAchievementPage) && _listAchievementsFrom > 0)
			{
				_listAchievementsFrom -= _scope;
				_listAchievementsTo -= _scope;
			}

			if (ClickedWithin(_nextAchievementPage) && _listAchievementsTo < PlayersProfiles.Instance.ListOfProfiles.Count)
			{
				_listAchievementsFrom += _scope;
				_listAchievementsTo += _scope;
			}
		}
	}



	private void CalculateStartAndEndPositionsForAchievementsForOnGUI()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_nextAchievementPage) && _listAchievementsTo < PlayersProfiles.Instance.ListOfProfiles.Count)
			{
				_listAchievementsFrom += (_scope / 2);
				_listAchievementsTo += (_scope / 2);
			}
			else if (ClickedWithin(_nextAchievementPage) && _listAchievementsTo % 2 != 0 && (_listAchievementsFrom + (_scope / 2)) < PlayersProfiles.Instance.ListOfProfiles.Count)
			{
				_listAchievementsFrom += (_scope / 2);
				_listAchievementsTo += (_scope / 2);
			}

			if (ClickedWithin(_previousAchievementPage) && _listAchievementsFrom > 0)
			{
				_listAchievementsFrom -= (_scope / 2);
				_listAchievementsTo -= (_scope / 2);
			}
		}
	}



	private bool ClickedWithin(Rect rect)
	{
		return ((_myMousePosition.x >= rect.x) && (_myMousePosition.x <= (rect.x + rect.width)) && (_myMousePosition.y >= rect.y) && (_myMousePosition.y <= (rect.y + rect.height)));
	}
}

