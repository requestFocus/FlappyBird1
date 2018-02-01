using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLobby : MonoBehaviour {

	[SerializeField]
	private Texture LogoButton;											// umożliwia wykorzystanie modyfikatora private z dostępem do zmiennej w ramach inspectora unity

	public Texture AchievementsButton;
	public Texture CreditsButton;
	public Texture HowtoPlayButton;
	public Texture NewGameButton;
	public Texture StartButton;
	public Texture HighscoreBoost;

	public Texture AchievementsButtonInactive;
	public Texture CreditsButtonInactive;
	public Texture HowtoPlayButtonInactive;
	public Texture NewGameButtonInactive;

	public PlayerProfile PlayerProfile;
	//public PlayersProfiles PlayersProfiles;                             // lista profili tworzona podczas gry
	public PlayerProfileController PlayerProfileController;				
	public ResizeController ResizeController;

	private Rect _logoRect;
	private Rect _newGameRect;
	private Rect _howtoPlayRect;
	private Rect _creditsRect;
	private Rect _achievementsRect;
	private Rect _startRect;
	private Rect _gamePlayRect;

	private Vector3 _myMousePosition;
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
	MenuScreens MenuStates; // = MenuScreens.MainMenu;		

	private void Start()
	{
		//PlayerPrefs.DeleteAll();

		MenuStates = MenuScreens.MainMenu;

		_justPlayerName = "";
		_badName = "";
		_isThereAList = PlayerProfileController.LoadProfiles();								// jeśli lista istnieje, jej zawartość od razu wchodzi do singletona
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

	private Rect DrawElement(int x, int y, int width, int height, Texture menuElement)
	{
		Rect RectScalableDimensions = ResizeController.ResizeGUI(new Rect(x, y, width, height));
		GUI.DrawTexture(RectScalableDimensions, menuElement);

		return RectScalableDimensions;
	}

	private Rect DrawElement(int x, int y, int width, int height, Texture menuElement, ResizeController.Horizontal horizontalAlignment, ResizeController.Vertical verticalAlignment)
	{
		Rect RectScalableDimensions = ResizeController.ResizeGUI(new Rect(x, y, width, height), horizontalAlignment, verticalAlignment);
		GUI.DrawTexture(RectScalableDimensions, menuElement);

		return RectScalableDimensions;
	}

	private void DrawMainMenu()								// obsluga MAIN MENU
	{
		//_logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		//_newGameRect = DrawElement(300, 250, 200, 60, NewGameButton);            // x y w h img
		//_howtoPlayRect = DrawElement(300, 330, 200, 60, HowtoPlayButton);
		//_creditsRect = DrawElement(300, 410, 200, 60, CreditsButton);
		//_achievementsRect = DrawElement(300, 490, 200, 60, AchievementsButton);

		_logoRect = DrawElement(315, 20, 170, 170, LogoButton, ResizeController.Horizontal.center, ResizeController.Vertical.top);
		_newGameRect = DrawElement(300, 250, 200, 60, NewGameButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_howtoPlayRect = DrawElement(300, 330, 200, 60, HowtoPlayButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_creditsRect = DrawElement(300, 410, 200, 60, CreditsButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);
		_achievementsRect = DrawElement(300, 490, 200, 60, AchievementsButton, ResizeController.Horizontal.center, ResizeController.Vertical.bottom);

		//====================================================================================================================================
		//DrawElement(375, 275, 50, 50, NewGameButton, "left", "top");
		//DrawElement(375, 275, 50, 50, HowtoPlayButton, "left", "center");
		//DrawElement(375, 275, 50, 50, CreditsButton, "left", "bottom");

		//DrawElement(375, 275, 50, 50, NewGameButton, "center", "top");
		//DrawElement(375, 275, 50, 50, HowtoPlayButton, "center", "center");
		//DrawElement(375, 275, 50, 50, CreditsButton, "center", "bottom");

		//DrawElement(375, 275, 50, 50, NewGameButton, "right", "top");
		//DrawElement(375, 275, 50, 50, HowtoPlayButton, "right", "center");
		//DrawElement(375, 275, 50, 50, CreditsButton, "right", "bottom");
		//====================================================================================================================================

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
		}
	}

	private void DrawNewGameMenu(Texture menuElement)               // obsluga NEW GAME
	{
		
		_justPlayerName = GUI.TextField(ResizeController.ResizeGUI(new Rect(350, 270, 100, 25)), _justPlayerName, 10);
		GUI.Label(ResizeController.ResizeGUI(new Rect(355, 245, 100, 25)), _badName);

		_logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		_startRect = DrawElement(300, 300, 200, 60, StartButton);
		DrawElement(350, 550, 100, 30, menuElement);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

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
				}
				else                                                // NIE WPISANO USERNAME
				{
					_badName = "<color=#000000ff><Enter your name</color>";																			 
				}
			}
		}
	}

	private void DrawGamePlay()               // TUTAJ BEDZIE SCENA Z WŁAŚCIWĄ GRĄ, POKI CO ZAŚLEPKA
	{
		SceneManager.LoadScene("Game");

		//LogoRect = DrawElement(315, 20, 170, 170, LogoButton);
		//GUI.Label(ResizeController.ResizeGUI(new Rect(10, 10, 300, 50)), "Name: " + PlayerProfile.PlayerName + " // Highscore: " + PlayerProfile.HighScore);
		//GamePlayRect = DrawElement(315, 400, 170, 170, HighscoreBoost);

		//_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		//if (Input.GetMouseButtonDown(0))
		//{
		//	if (ClickedWithin(LogoRect))
		//	{
		//		MenuStates = MenuScreens.MainMenu;
		//		//PlayerProfileController.SaveProfile(PlayersProfiles.Instance.listOfProfiles);                                           // TEGO BĘDZIE MOŻNA SIĘ POZBYC JAK JUŻ zacznie działać gra
		//	}

		//	if (ClickedWithin(GamePlayRect))
		//	{
		//		PlayerProfile.HighScore = PlayerProfile.HighScore + 1;                                          // DEMONSTRACJA DZIAŁANIA PLAYERPREFS/JSON
		//		PlayerProfileController.SaveProfile(PlayersProfiles.Instance);
		//	}
		//}
	}

	private void DrawCreditsMenu(Texture menuElement)               // obsluga CREDITS
	{ 
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "Credits section to come...");

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}
		}
	}

	private void DrawAchievementsMenu(Texture menuElement)
	{
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		ListPlayersAchievements();

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}
		}
	}

	private void DrawHowtoPlayMenu(Texture menuElement) 
	{
		_logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "How to Play section to come...");

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(_logoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}
		}
	}

	private void CheckPlayerPrefs()															// ładowane po kliknieciu buttona START w menu NEW GAME
	{
		_isOnTheList = false;

		if (_isThereAList)																	 // jesli istnieje lista w pamieci
		{
			//Debug.Log("lista istnieje");

			for (int i = 0; i < PlayersProfiles.Instance.ListOfProfiles.Count; i++)					// parsuje całą listę obiektów
			{
				if (PlayersProfiles.Instance.ListOfProfiles[i].PlayerName.Equals(_justPlayerName))   // sprawdza czy podane NAME istnieje w pamięci
				{
					//PlayerProfile = PlayersProfiles.Instance.ListOfProfiles[i];					// to może się przydać, jeśli będzie jakiś screen przed grą, ale można też czytać bezpośrednio z singletona
					PlayersProfiles.Instance.CurrentProfile = i;                                    // ID znalezionego profilu
					_isOnTheList = true;
					//Debug.Log("podane NAME istnieje w pamięci");
					break;
				}
			}

			if (!_isOnTheList)																					// jesli na liscie nie wystepuje podane NAME
			{
				AddNewProfile();
				//PlayerProfile = new PlayerProfile(_justPlayerName, 0, false);                                       // tworzę nowy profil gracza z domyślnymi wartościami
				//PlayersProfiles.Instance.ListOfProfiles.Add(PlayerProfile);                                     // dodaję ten profil do listy profili
				//PlayersProfiles.Instance.CurrentProfile = PlayersProfiles.Instance.ListOfProfiles.Count - 1;        // nadaję nowemu userowi najwyzszego numeru na liscie
				//PlayerProfileController.SaveProfile(PlayersProfiles.Instance);                                  // zapisuję dane w singletonie
				//Debug.Log("podane NAME nie istnieje w pamięci");
			}
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			AddNewProfile();
			//Debug.Log("lista nie istnieje");
			//PlayerProfile = new PlayerProfile(_justPlayerName, 0, false);                   // tworzę nowy profil gracza z domyślnymi wartościami
			//PlayersProfiles.Instance.ListOfProfiles = new List<PlayerProfile>();            // tworzę listę, bo _isThereAList == false
			//PlayersProfiles.Instance.ListOfProfiles.Add(PlayerProfile);                     // a teraz dodać do niej aktualny playerProfile
			//PlayersProfiles.Instance.CurrentProfile = 0;                                    // nadaję userowi pierwszy numeru na liście
			//PlayerProfileController.SaveProfile(PlayersProfiles.Instance);                  // zapisuję dane w singletonie				czy częsty zapis do PlayerPrefs wpływa na wydajność?==================
			//Debug.Log("dodano: " + PlayersProfiles.Instance.ListOfProfiles[0].PlayerName);
		}
	}

	private void AddNewProfile()
	{
		PlayerProfile = new PlayerProfile(_justPlayerName, 0, false);                   // tworzę nowy profil gracza z domyślnymi wartościami
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

	private void ListPlayersAchievements()                                                         // ładowane po kliknieciu buttona START w menu NEW GAME
	{
		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 250, 30)), "<color=BLACK>Name // Highscore // Achievement</color>");

		if (_isThereAList)													// jesli istnieje lista w pamieci
		{
			float YPosition = 300;																	// czemu jesli dam tu private to są błędy? =================================================
			for (int i = 0; i < PlayersProfiles.Instance.ListOfProfiles.Count; i++)
			{
				// wypisz wyniki
				GUI.Label(ResizeController.ResizeGUI(new Rect(300, YPosition, 200, 30)), "<color=RED>" + PlayersProfiles.Instance.ListOfProfiles[i].PlayerName + " // "
							+ PlayersProfiles.Instance.ListOfProfiles[i].HighScore + " // " + PlayersProfiles.Instance.ListOfProfiles[i].Complete10 + "</color>: ");
				YPosition += 30;
			}
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			// nie ma listy, nie ma wyników
			GUI.Label(ResizeController.ResizeGUI(new Rect(300, 300, 200, 30)), "<color=BLACK>No results yet.</color>: ");
		}
	}

	private bool ClickedWithin(Rect rect)
	{
		return ((_myMousePosition.x >= rect.x) && (_myMousePosition.x <= (rect.x + rect.width)) && (_myMousePosition.y >= rect.y) && (_myMousePosition.y <= (rect.y + rect.height)));
	}
}


//	zalecana struktura funkcji, czy najpierw główne, potem podrzędne, czy podrzędne od głównych bezpośrednio pod nimi?