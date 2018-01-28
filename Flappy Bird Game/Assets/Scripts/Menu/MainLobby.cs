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

	Rect LogoRect;
	Rect NewGameRect;
	Rect HowtoPlayRect;
	Rect CreditsRect;
	Rect AchievementsRect;
	Rect StartRect;
	Rect GamePlayRect;

	private Vector3 _myMousePosition;
	private string _justPlayerName;
	private string _badName;

	private enum MenuScreens
	{
		MainMenu,
		HowtoPlay,
		Credits,
		Achievements,
		NewGame,
		GamePlay
	};
	MenuScreens MenuStates = MenuScreens.MainMenu;		

	private void Start()
	{
		MenuStates = MenuScreens.MainMenu;

		_justPlayerName = "";
		_badName = "";

		//PlayerPrefs.DeleteAll();
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

	private void DrawMainMenu()								// obsluga MAIN MENU
	{
		LogoRect = DrawElement(315, 20, 170, 170, LogoButton);
		NewGameRect = DrawElement(300, 250, 200, 60, NewGameButton);            // x y w h img
		HowtoPlayRect = DrawElement(300, 330, 200, 60, HowtoPlayButton);
		CreditsRect = DrawElement(300, 410, 200, 60, CreditsButton);
		AchievementsRect = DrawElement(300, 490, 200, 60, AchievementsButton);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{

			// sprawdz czy da sie to zamienic na switcha ================================================================

			// LOGO - MAIN MENU						
			if (ClickedWithin(LogoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}

			// NEW GAME
			else if (ClickedWithin(NewGameRect))
			{
				MenuStates = MenuScreens.NewGame;
			}

			// HOW TO PLAY
			else if (ClickedWithin(HowtoPlayRect))
			{
				MenuStates = MenuScreens.HowtoPlay;
			}

			// CREDITS
			else if (ClickedWithin(CreditsRect))
			{
				MenuStates = MenuScreens.Credits;
			}

			// ACHIEVEMENTS
			else if (ClickedWithin(AchievementsRect))
			{
				MenuStates = MenuScreens.Achievements;

			}
		}
	}

	private void DrawNewGameMenu(Texture menuElement)               // obsluga NEW GAME
	{
		
		_justPlayerName = GUI.TextField(ResizeController.ResizeGUI(new Rect(350, 270, 100, 25)), _justPlayerName, 10);
		GUI.Label(ResizeController.ResizeGUI(new Rect(355, 245, 100, 25)), _badName);

		LogoRect = DrawElement(315, 20, 170, 170, LogoButton);
		StartRect = DrawElement(300, 300, 200, 60, StartButton);
		DrawElement(350, 550, 100, 30, menuElement);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(LogoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}
			else if (ClickedWithin(StartRect))
			{
				if (_justPlayerName.Length > 0)
				{
					CheckPlayerPrefs();							// jesli istnieje podany name w playerprefs, odpal LoadProfile i przypisz dane do pol obiektu

					MenuStates = MenuScreens.GamePlay;
				}
				else                                                // NIE WPISANO USERNAME
				{
					_badName = "Enter your name";																			 
				}
			}
		}
	}

	private void DrawGamePlay()               // TUTAJ BEDZIE SCENA Z WŁAŚCIWĄ GRĄ, POKI CO ZAŚLEPKA
	{

		//SceneManager.LoadScene("Game");

		LogoRect = DrawElement(315, 20, 170, 170, LogoButton);
		GUI.Label(ResizeController.ResizeGUI(new Rect(10, 10, 300, 50)), "Name: " + PlayerProfile.PlayerName + " // Highscore: " + PlayerProfile.HighScore);
		GamePlayRect = DrawElement(315, 400, 170, 170, HighscoreBoost);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(LogoRect))
			{
				MenuStates = MenuScreens.MainMenu;
				//PlayerProfileController.SaveProfile(PlayersProfiles.Instance.listOfProfiles);                                           // TEGO BĘDZIE MOŻNA SIĘ POZBYC JAK JUŻ zacznie działać gra
			}

			if (ClickedWithin(GamePlayRect))
			{
				PlayerProfile.HighScore = PlayerProfile.HighScore + 1;                                          // DEMONSTRACJA DZIAŁANIA PLAYERPREFS/JSON
				PlayerProfileController.SaveProfile(PlayersProfiles.Instance);
			}
		}
	}

	private void DrawCreditsMenu(Texture menuElement)               // obsluga CREDITS
	{ 
		LogoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "Credits section to come...");

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(LogoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}
		}
	}

	private void DrawAchievementsMenu(Texture menuElement)
	{
		LogoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "Achievements section to come...");

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(LogoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}
		}
	}

	private void DrawHowtoPlayMenu(Texture menuElement) 
	{
		LogoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "How to Play section to come...");

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if (ClickedWithin(LogoRect))
			{
				MenuStates = MenuScreens.MainMenu;
			}
		}
	}

	private void CheckPlayerPrefs()															// ładowane po kliknieciu buttona START w menu NEW GAME
	{
		bool isOnTheList = false;

		if (PlayerProfileController.LoadProfiles())
		//if (PlayersProfiles.Instance.ListOfProfiles.Count > 0)                      // jesli istnieje lista w pamieci
		{
			Debug.Log("lista istnieje");
			Debug.Log("sprawdzam czy podane NAME istnieje w pamięci");

			for (int i = 0; i < PlayersProfiles.Instance.ListOfProfiles.Count; i++)
			{

				if (PlayersProfiles.Instance.ListOfProfiles[i].PlayerName.Equals(_justPlayerName))   // jeśli na liście wystepuje podane NAME
				{
					PlayerProfile = PlayersProfiles.Instance.ListOfProfiles[i];
					isOnTheList = true;
					Debug.Log("podane NAME istnieje w pamięci");
					break;
				}
			}

			if (!isOnTheList)                                                                // jesli na liscie nie wystepuje podane NAME
			{
				PlayerProfile = new PlayerProfile(_justPlayerName, 0, false);
				PlayersProfiles.Instance.ListOfProfiles.Add(PlayerProfile);
				Debug.Log("podane NAME nie istnieje w pamięci");
			}
		}
		else																				// jesli nie istnieje lista w pamieci
		{
			Debug.Log("lista nie istnieje");
			PlayerProfile = new PlayerProfile(_justPlayerName, 0, false);
			PlayersProfiles.Instance.ListOfProfiles = new List<PlayerProfile>();			// jeśli lista nie jest statyczna to trzeba ją w tym miejscu stworzyć
			PlayersProfiles.Instance.ListOfProfiles.Add(PlayerProfile);                     // a teraz dodać do niej aktualny playerProfile
			Debug.Log("dodano: " + PlayersProfiles.Instance.ListOfProfiles[0].PlayerName);
		}
	}

	private bool ClickedWithin(Rect rect)
	{
		return ((_myMousePosition.x >= rect.x) && (_myMousePosition.x <= (rect.x + rect.width)) && (_myMousePosition.y >= rect.y) && (_myMousePosition.y <= (rect.y + rect.height)));
	}
}
