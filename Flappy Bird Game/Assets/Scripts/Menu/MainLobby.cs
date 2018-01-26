using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public PlayersProfiles PlayersProfiles;                             // lista profili tworzona podczas gry
	public PlayerProfileController PlayerProfileController;				
	public ResizeController ResizeController;

	private Vector3 _myMousePosition;
	private string _justPlayerName;

	private static bool MainMenu;
	private static bool HowtoPlay;
	private static bool Credits;
	private static bool Achievements;
	private static bool NewGame;
	private static bool GamePlay;
	private jakisenum eeee = jakisenum.menu;					//============================== zastąpić ENUMami boole powyżej i użyć ich w switchu

	private void Start()
	{
		MainMenu = true;
		_justPlayerName = "";
		//PlayerPrefs.DeleteAll();
	}

	enum jakisenum { menu, achiev};								//=============================== deklaracja enuma

	private void Update()
	{
		// ================================================================= czy to nie działa tak samo jak OnGUI()?
	}

	private void OnGUI()
	{

		if (MainMenu) {												//=========================== tutaj użyc switcha, który jako case'y przyjmuje różne stany ENUMa
			DrawMainMenu();
		}

		else if (NewGame)                        // zawiera ekran wpisania imienia i przycisk Start!
			{
			DrawNewGameMenu(NewGameButtonInactive);
		}

		else if (Credits)					
		{
			DrawCreditsMenu(CreditsButtonInactive);
		}

		else if (Achievements)
		{
			DrawAchievementsMenu(AchievementsButtonInactive);
		}

		else if (HowtoPlay)
		{
			DrawHowtoPlayMenu(HowtoPlayButtonInactive);
		}

		else if (GamePlay)
		{
			DrawGamePlay();
		}
	}	

	//private Rect DrawElement(int x, int y, int width, int height, Texture menuElement)
	//{
	//	Rect buttonScalableDimensions = resizeController.ResizeGUI(new Rect(x, y, width, height));
	//	GUI.DrawTexture(buttonScalableDimensions, menuElement);

	//	return buttonScalableDimensions;
	//}

	private Rect DrawElement(int x, int y, int width, int height, Texture menuElement)
	{
		Rect buttonScalableDimensions = ResizeController.ResizeGUI(new Rect(x, y, width, height));
		GUI.DrawTexture(buttonScalableDimensions, menuElement);

		return buttonScalableDimensions;
	}

	private void DrawMainMenu()								// obsluga MAIN MENU
	{
		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		Rect newGameRect = DrawElement(300, 250, 200, 60, NewGameButton);            // x y w h img
		Rect howtoPlayRect = DrawElement(300, 330, 200, 60, HowtoPlayButton);
		Rect creditsRect = DrawElement(300, 410, 200, 60, CreditsButton);
		Rect achievementsRect = DrawElement(300, 490, 200, 60, AchievementsButton);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{

			// LOGO - MAIN MENU						//============================================ zastąpić te sprawdzania kształtu buttona osobną funkcją!!
			if ((_myMousePosition.x >= logoRect.x) && (_myMousePosition.x <= (logoRect.x + logoRect.width)) && (_myMousePosition.y >= logoRect.y) && (_myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;					// a te ustawianie booli zwykłym ustawieniem stanu ENUMa
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;
			}

			// NEW GAME
			else if ((_myMousePosition.x >= newGameRect.x) && (_myMousePosition.x <= (newGameRect.x + newGameRect.width)) && (_myMousePosition.y >= newGameRect.y) && (_myMousePosition.y <= (newGameRect.y + newGameRect.height)))
			{
				MainMenu = false;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = true;
			}

			// HOW TO PLAY
			else if ((_myMousePosition.x >= howtoPlayRect.x) && (_myMousePosition.x <= (howtoPlayRect.x + howtoPlayRect.width)) && (_myMousePosition.y >= howtoPlayRect.y) && (_myMousePosition.y <= (howtoPlayRect.y + howtoPlayRect.height)))
			{
				MainMenu = false;
				HowtoPlay = true;
				Credits = false;
				Achievements = false;
				NewGame = false;
			}

			// CREDITS
			else if ((_myMousePosition.x >= creditsRect.x) && (_myMousePosition.x <= (creditsRect.x + creditsRect.width)) && (_myMousePosition.y >= creditsRect.y) && (_myMousePosition.y <= (creditsRect.y + creditsRect.height)))
			{
				MainMenu = false;
				HowtoPlay = false;
				Credits = true;
				Achievements = false;
				NewGame = false;
			}

			// ACHIEVEMENTS
			else if ((_myMousePosition.x >= achievementsRect.x) && (_myMousePosition.x <= (achievementsRect.x + achievementsRect.width)) && (_myMousePosition.y >= achievementsRect.y) && (_myMousePosition.y <= (achievementsRect.y + achievementsRect.height)))
			{
				MainMenu = false;
				HowtoPlay = false;
				Credits = false;
				Achievements = true;
				NewGame = false;
			}
		}
	}

	private void DrawNewGameMenu(Texture menuElement)               // obsluga NEW GAME
	{
		_justPlayerName = GUI.TextField(ResizeController.ResizeGUI(new Rect(350, 270, 100, 25)), _justPlayerName, 10);

		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		Rect startRect = DrawElement(300, 300, 200, 60, StartButton);
		DrawElement(350, 550, 100, 30, menuElement);

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((_myMousePosition.x >= logoRect.x) && (_myMousePosition.x <= (logoRect.x + logoRect.width)) && (_myMousePosition.y >= logoRect.y) && (_myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;
			}

			if ((_myMousePosition.x >= startRect.x) && (_myMousePosition.x <= (startRect.x + startRect.width)) && (_myMousePosition.y >= startRect.y) && (_myMousePosition.y <= (startRect.y + startRect.height)))
			{
				if (_justPlayerName.Length > 0)
				{
					CheckPlayerPrefs();							// jesli istnieje podany name w playerprefs, odpal LoadProfile i przypisz dane do pol obiektu

					MainMenu = false;
					HowtoPlay = false;
					Credits = false;
					Achievements = false;
					NewGame = false;
					GamePlay = true;
				}
				else                                                // NIE WPISANO USERNAME
				{
					Debug.Log("bad login");
					// kod obslugi bledu, JAK POKAZAC? ====================================================================================================
				}
			}
		}
	}

	private void DrawGamePlay()               // TUTAJ BEDZIE SCENA Z WŁAŚCIWĄ GRĄ, POKI CO ZAŚLEPKA
	{
		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		GUI.Label(ResizeController.ResizeGUI(new Rect(10, 10, 300, 50)), "Name: " + PlayerProfile.PlayerName + " // Highscore: " + PlayerProfile.HighScore);
		Rect gamePlayRect = DrawElement(315, 400, 170, 170, HighscoreBoost);                       

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((_myMousePosition.x >= logoRect.x) && (_myMousePosition.x <= (logoRect.x + logoRect.width)) && (_myMousePosition.y >= logoRect.y) && (_myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;
				PlayerProfileController.SaveProfile(PlayersProfiles);
			}

			if ((_myMousePosition.x >= gamePlayRect.x) && (_myMousePosition.x <= (gamePlayRect.x + gamePlayRect.width)) && (_myMousePosition.y >= gamePlayRect.y) && (_myMousePosition.y <= (gamePlayRect.y + gamePlayRect.height)))
			{
				PlayerProfile.HighScore = PlayerProfile.HighScore + 1;                                          // DEMONSTRACJA DZIAŁANIA PLAYERPREFS/JSON
				// dlaczego dodaje sie dwa razy po jednym kliknieciu? =====================================================================================================
				PlayerProfileController.SaveProfile(PlayersProfiles);
			}
		}
	}

	private void DrawCreditsMenu(Texture menuElement)               // obsluga CREDITS
	{ 
		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "Credits section to come...");

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((_myMousePosition.x >= logoRect.x) && (_myMousePosition.x <= (logoRect.x + logoRect.width)) && (_myMousePosition.y >= logoRect.y) && (_myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;
			}
		}
	}

	private void DrawAchievementsMenu(Texture menuElement)               // obsluga ACHIEVEMENTS
	{
		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "Achievements section to come...");

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((_myMousePosition.x >= logoRect.x) && (_myMousePosition.x <= (logoRect.x + logoRect.width)) && (_myMousePosition.y >= logoRect.y) && (_myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;
			}
		}
	}

	private void DrawHowtoPlayMenu(Texture menuElement)               // obsluga HOW TO PLAY
	{
		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(ResizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "How to Play section to come...");

		_myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((_myMousePosition.x >= logoRect.x) && (_myMousePosition.x <= (logoRect.x + logoRect.width)) && (_myMousePosition.y >= logoRect.y) && (_myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;
			}
		}
	}

	private void CheckPlayerPrefs()								// ładowane po kliknieciu buttona START w menu NEW GAME
	{
		bool isOnTheList = false;

		if (PlayerProfileController.LoadProfiles() is PlayersProfiles)                      // jesli istnieje lista w pamieci
		//if (PlayerPrefs.GetString("ProfileSettings").Length > 0)						// jeśli PlayerPrefs zawiera dane====================================================
		{
			PlayersProfiles = PlayerProfileController.LoadProfiles();

			for (int i = 0; i < PlayersProfiles.listOfProfiles.Count; i++)
			{
				if (PlayersProfiles.listOfProfiles[i].PlayerName.Equals(_justPlayerName))            // jeśli na liście wystepuje podane NAME
				{
					PlayerProfile = PlayersProfiles.listOfProfiles[i];
					isOnTheList = true;
					break;
				}
			}

			if (!isOnTheList)                                                                               // jesli na liscie nie wystepuje podane NAME
			{
				PlayerProfile = new PlayerProfile(_justPlayerName, 0, false);
				PlayersProfiles.listOfProfiles.Add(PlayerProfile);
			}
		}
		else																				// jesli nie istnieje lista w pamieci
		{
			PlayerProfile = new PlayerProfile(_justPlayerName, 0, false);
			PlayersProfiles.listOfProfiles.Add(PlayerProfile);								// tworzy liste i dopisuje aktualnego playerProfile
		}
	}
}
