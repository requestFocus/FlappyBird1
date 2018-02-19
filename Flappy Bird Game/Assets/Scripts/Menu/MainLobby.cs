using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLobby : MonoBehaviour {

	[SerializeField]
	private Texture LogoButton;											// umożliwia wykorzystanie modyfikatora private z dostępem do zmiennej w ramach inspectora unity

	public Texture AchievementsButton;
	public Texture CreditsButton;
	public Texture HowtoPlayButton;
	public Texture NewGameButton;
	public Texture StartButton;

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

	public Texture NextAchievementPage;
	public Texture PreviousAchievementPage;

	public PlayerProfile PlayerProfile;
	public PlayerProfileController PlayerProfileController;				
	public ResizeController ResizeController;

	public Font font;
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
		MainMenu,
		HowtoPlay,
		Credits,
		Achievements,
		NewGame,
		GamePlay
	};
	MenuScreens MenuStates;



	private void Start()
	{
		//PlayerPrefs.DeleteAll();

		SetGUIStyle();
	
		MenuStates = MenuScreens.MainMenu;

		_justPlayerName = "";
		_isThereAList = PlayerProfileController.LoadProfiles();                             // jeśli lista istnieje, jej zawartość od razu wchodzi do singletona

		_scope = 5;
		_listAchievementsFrom = 0;
		_listAchievementsTo = _scope;
	}



	private void Update()
	{
		if (MenuStates.Equals(MenuScreens.Achievements))
		{
			CalculateStartAndEndPositionsForAchievementsForUpdate();						// poza OnGUI, bo OnGUI wywoluje sie 2x na klatke, co zaburza zliczanie kliknięć
		}
	}



	private void OnGUI()
	{
		switch (MenuStates)
		{
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



	private void DrawMainMenu()								// obsluga MAIN MENU
	{
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		_newGameRect = DrawElement(300, 250, 200, 60, NewGameButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_howtoPlayRect = DrawElement(300, 330, 200, 60, HowtoPlayButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_creditsRect = DrawElement(300, 410, 200, 60, CreditsButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_achievementsRect = DrawElement(300, 490, 200, 60, AchievementsButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		//if (Time.frameCount % 100 == 0)
		//	Debug.Log("X: " + _achievementsRect.x + " // Y: " + _achievementsRect.y + " // szer button: " + _achievementsRect.width + " // wys button: " + _achievementsRect.height + " // szer ekran: " + Screen.width + " // wys ekran: " + Screen.height);

		//====================================================================================================================================
		//DrawElement(350, 275, 100, 50, NewGameButton, ResizeController.Horizontal.left, ResizeController.Vertical.top);
		//DrawElement(350, 275, 100, 50, HowtoPlayButton, ResizeController.Horizontal.left, ResizeController.Vertical.center);
		//DrawElement(350, 275, 100, 50, CreditsButton, ResizeController.Horizontal.left, ResizeController.Vertical.bottom);

		//DrawElement(375, 250, 50, 100, NewGameButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		//DrawElement(375, 250, 50, 100, HowtoPlayButton, ResizeController.Horizontal.center, ResizeController.Vertical.center);
		//DrawElement(375, 250, 50, 100, CreditsButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		//DrawElement(350, 275, 100, 50, NewGameButton, ResizeController.Horizontal.right, ResizeController.Vertical.top);
		//DrawElement(350, 275, 100, 50, HowtoPlayButton, ResizeController.Horizontal.right, ResizeController.Vertical.center);
		//DrawElement(350, 275, 100, 50, CreditsButton, ResizeController.Horizontal.right, ResizeController.Vertical.bottom);
		//====================================================================================================================================

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
		 //_myMousePosition = Input.mousePosition;

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
		}
	}



	private void DrawNewGameMenu(Texture menuElement)               // obsluga NEW GAME
	{
		_justPlayerName = GUI.TextField(ResizeController.ResizeGUI(new Rect(350, 270, 100, 25), ResizeController.Horizontal.center, ResizeController.Vertical.center), _justPlayerName, 10);

		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		_startRect = DrawElement(300, 300, 200, 60, StartButton, ResizeController.Horizontal.center, ResizeController.Vertical.center);
		DrawElement(350, 550, 100, 30, menuElement, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		GUI.Label(ResizeController.ResizeGUI(new Rect(350, 360, 100, 25), ResizeController.Horizontal.center, ResizeController.Vertical.center), _labelContent, _labelStyle);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
		 //_myMousePosition = Input.mousePosition;  

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}
			else if (ClickedWithin(_startRect))
			{
				if (_justPlayerName.Length > 0)
				{
					CheckPlayerPrefs();							// jesli istnieje podany name w playerprefs, odpal LoadProfile i przypisz dane do pol obiektu
					MenuStates = MenuScreens.GamePlay;
					_labelContent.text = "";
				}
				else                                                // NIE WPISANO USERNAME
				{
					_labelContent.text = "<color=#" + _darkGreyFont + ">Enter your name</color>";
				}
			}
		}
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
			ListAchievements(_listAchievementsFrom, _listAchievementsTo);
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



	private void CheckPlayerPrefs()															// ładowane po kliknieciu buttona START w menu NEW GAME
	{
		_isOnTheList = false;

		if (_isThereAList)																	 // jesli istnieje lista w pamieci
		{
			for (int i = 0; i < PlayersProfiles.Instance.ListOfProfiles.Count; i++)					// parsuje całą listę obiektów
			{
				if (PlayersProfiles.Instance.ListOfProfiles[i].PlayerName.Equals(_justPlayerName))   // sprawdza czy podane NAME istnieje w pamięci
				{
					//PlayerProfile = PlayersProfiles.Instance.ListOfProfiles[i];					// to może się przydać, jeśli będzie jakiś screen przed grą, ale można też czytać bezpośrednio z singletona
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
		PlayerProfile = new PlayerProfile(_justPlayerName, 0, false, false, false);                   // tworzę nowy profil gracza z domyślnymi wartościami
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
		PlayerProfileController.SaveProfile(PlayersProfiles.Instance);                  // zapisuję dane w singletonie				czy częsty zapis do PlayerPrefs wpływa na wydajność?==================
	}



	private void ListAchievements(float listFrom, float listTo)                                                         // ładowane po kliknieciu buttona START w menu NEW GAME
	{

		GUI.Label(ResizeController.ResizeGUI(new Rect(200, 240, 150, 30), ResizeController.Horizontal.left, ResizeController.Vertical.center), "<color=#" + _darkGreyFont + ">NAME</color>", _labelStyle);
		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 240, 150, 30), ResizeController.Horizontal.center, ResizeController.Vertical.center), "<color=#" + _darkGreyFont + ">HIGHSCORE</color>", _labelStyle);
		GUI.Label(ResizeController.ResizeGUI(new Rect(430, 240, 150, 30), ResizeController.Horizontal.right, ResizeController.Vertical.center), "<color=#" + _darkGreyFont + ">ACHIEVEMENTS</color>", _labelStyle);

		_previousAchievementPage = DrawElement(376, 430, 16, 18, PreviousAchievementPage, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_nextAchievementPage = DrawElement(410, 430, 16, 18, NextAchievementPage, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		int yPosition = 270;
		int xPosition = 465;

			for (int i = (int)listFrom; i < PlayersProfiles.Instance.ListOfProfiles.Count && i < (int)listTo; i++)								// wypisze liste userów od A do B
			{
				GUI.Label(ResizeController.ResizeGUI(new Rect(200, yPosition, 150, 30), ResizeController.Horizontal.left, ResizeController.Vertical.center),
							"<color=#" + _lightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].PlayerName + "</color>", _labelStyle);

				GUI.Label(ResizeController.ResizeGUI(new Rect(300, yPosition, 150, 30), ResizeController.Horizontal.center, ResizeController.Vertical.center),
							"<color=#" + _lightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].HighScore + "</color>", _labelStyle);

				if (PlayersProfiles.Instance.ListOfProfiles[i].Complete10)
				{
					DrawElement(xPosition, yPosition, 23, 28, Complete10Active, ResizeController.Horizontal.right, ResizeController.Vertical.center);         // IKONY ACHIEVEMENTOW MAJA WYMIARY 96x110
				}
				else
				{
					DrawElement(xPosition, yPosition, 23, 28, Complete10Inactive, ResizeController.Horizontal.right, ResizeController.Vertical.center);
				}

				xPosition += 30;
				if (PlayersProfiles.Instance.ListOfProfiles[i].Complete25)
				{
					DrawElement(xPosition, yPosition, 23, 28, Complete25Active, ResizeController.Horizontal.right, ResizeController.Vertical.center);
				}
				else
				{
					DrawElement(xPosition, yPosition, 23, 28, Complete25Inactive, ResizeController.Horizontal.right, ResizeController.Vertical.center);
				}

				xPosition += 30;
				if (PlayersProfiles.Instance.ListOfProfiles[i].Complete50)
				{
					DrawElement(xPosition, yPosition, 23, 28, Complete50Active, ResizeController.Horizontal.right, ResizeController.Vertical.center);
				}
				else
				{
					DrawElement(xPosition, yPosition, 23, 28, Complete50Inactive, ResizeController.Horizontal.right, ResizeController.Vertical.center);
				}

				yPosition += 30;
				xPosition = 465;
			}

		//CalculateStartAndEndPositionsForAchievementsForOnGUI();
		MenuStates = MenuScreens.Achievements;
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



	private void DisplayAchievementsWithMasking()
	{

	}



	private bool ClickedWithin(Rect rect)
	{
		return ((_myMousePosition.x >= rect.x) && (_myMousePosition.x <= (rect.x + rect.width)) && (_myMousePosition.y >= rect.y) && (_myMousePosition.y <= (rect.y + rect.height)));
	}
}

