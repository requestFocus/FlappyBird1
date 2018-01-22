using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobby : MonoBehaviour {

	public Texture LogoButton; 
	public Texture BackButton;
	public Texture AchievementsButton;
	public Texture CreditsButton;
	public Texture HowtoPlayButton;
	public Texture NewGameButton;
	public Texture StartButton;

	public Texture BackButtonInactive;
	public Texture AchievementsButtonInactive;
	public Texture CreditsButtonInactive;
	public Texture HowtoPlayButtonInactive;
	public Texture NewGameButtonInactive;

	public PlayerProfile playerProfile;
	public PlayerProfileController playerProfileController;
	public ResizeController resizeController;

	private Vector3 myMousePosition;

	private static bool MainMenu;
	private static bool HowtoPlay;
	private static bool Credits;
	private static bool Achievements;
	private static bool NewGame;
	private static bool GamePlay;

	private bool isButtonClicked;
	private string nameField;

		private void Start()
	{
		playerProfile = new PlayerProfile() {
			playerName = ""
		};
		nameField = "Name: ";
		MainMenu = true;

		//PlayerPrefs.DeleteAll();
	}

	private void Update()
	{

	}

	private void OnGUI()
	{

		if (MainMenu) {
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

	private Rect DrawElement(int x, int y, int width, int height, Texture menuElement)
	{
		Rect buttonScalableDimensions = resizeController.ResizeGUI(new Rect(x, y, width, height));
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

		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{

			// LOGO - MAIN MENU
			if ((myMousePosition.x >= logoRect.x) && (myMousePosition.x <= (logoRect.x + logoRect.width)) && (myMousePosition.y >= logoRect.y) && (myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;
				HowtoPlay = true;
				Credits = false;
				Achievements = false;
				NewGame = false;
				Debug.Log("logo");

			}

			// NEW GAME
			else if ((myMousePosition.x >= newGameRect.x) && (myMousePosition.x <= (newGameRect.x + newGameRect.width)) && (myMousePosition.y >= newGameRect.y) && (myMousePosition.y <= (newGameRect.y + newGameRect.height)))
			{
				MainMenu = false;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = true;
				Debug.Log("new game");

				playerProfile.highScore++;
				playerProfileController.SaveProfile(playerProfile);
			}

			// HOW TO PLAY
			else if ((myMousePosition.x >= howtoPlayRect.x) && (myMousePosition.x <= (howtoPlayRect.x + howtoPlayRect.width)) && (myMousePosition.y >= howtoPlayRect.y) && (myMousePosition.y <= (howtoPlayRect.y + howtoPlayRect.height)))
			{
				MainMenu = false;
				HowtoPlay = true;
				Credits = false;
				Achievements = false;
				NewGame = false;
				Debug.Log("how to play");
			}

			// CREDITS
			else if ((myMousePosition.x >= creditsRect.x) && (myMousePosition.x <= (creditsRect.x + creditsRect.width)) && (myMousePosition.y >= creditsRect.y) && (myMousePosition.y <= (creditsRect.y + creditsRect.height)))
			{
				MainMenu = false;
				HowtoPlay = false;
				Credits = true;
				Achievements = false;
				NewGame = false;
				Debug.Log("credits");
			}

			// ACHIEVEMENTS
			else if ((myMousePosition.x >= achievementsRect.x) && (myMousePosition.x <= (achievementsRect.x + achievementsRect.width)) && (myMousePosition.y >= achievementsRect.y) && (myMousePosition.y <= (achievementsRect.y + achievementsRect.height)))
			{
				MainMenu = false;
				HowtoPlay = false;
				Credits = false;
				Achievements = true;
				NewGame = false;
				Debug.Log("achievements");
			}
		}
	}

	private void DrawNewGameMenu(Texture menuElement)               // obsluga NEW GAME
	{
		GUI.Label(new Rect(10, 10, 100, 25), nameField);
		playerProfile.playerName = GUI.TextField(new Rect(80, 10, 100, 25), playerProfile.playerName, 10);

		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);
		Rect startRect = DrawElement(300, 300, 200, 60, StartButton);


		if (isButtonClicked)
		{
			MainMenu = false;
			playerProfileController.SaveProfile(playerProfile);
			playerProfile.playerName = "";
		}

		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((myMousePosition.x >= logoRect.x) && (myMousePosition.x <= (logoRect.x + logoRect.width)) && (myMousePosition.y >= logoRect.y) && (myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;

			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			if ((myMousePosition.x >= startRect.x) && (myMousePosition.x <= (startRect.x + startRect.width)) && (myMousePosition.y >= startRect.y) && (myMousePosition.y <= (startRect.y + startRect.height)))
			{
				if (playerProfile.playerName.Length > 0)
				{
					CheckPlayerPrefs();

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
					/* kod obslugi bledu */
				}
			}
		}
	}

	private void DrawGamePlay()               // obsluga pojedynczego MENU i back buttona pod postacią LOGO
	{
		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		GUI.Label(new Rect(10, 10, 100, 100), "Your name is: " + playerProfile.playerName + " // Highscore: " + playerProfile.highScore);
		isButtonClicked = GUI.Button(new Rect(10, 60, 100, 25), "Change user?");
		DrawElement(315, 300, 170, 170, LogoButton);                        // ZAŚLEPKA

		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((myMousePosition.x >= logoRect.x) && (myMousePosition.x <= (logoRect.x + logoRect.width)) && (myMousePosition.y >= logoRect.y) && (myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				MainMenu = true;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;
			}
		}

		playerProfile.highScore++;											// DEMONSTRACJA DZIAŁANIA PLAYERPREFS/JSON
		playerProfileController.SaveProfile(playerProfile);
	}

	private void DrawCreditsMenu(Texture menuElement)               // obsluga CREDITS
	{ 
		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(new Rect(350, 300, 300, 30), "Credits section to come...");

		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((myMousePosition.x >= logoRect.x) && (myMousePosition.x <= (logoRect.x + logoRect.width)) && (myMousePosition.y >= logoRect.y) && (myMousePosition.y <= (logoRect.y + logoRect.height)))
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

		GUI.Label(new Rect(350, 300, 300, 30), "Achievements section to come...");

		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((myMousePosition.x >= logoRect.x) && (myMousePosition.x <= (logoRect.x + logoRect.width)) && (myMousePosition.y >= logoRect.y) && (myMousePosition.y <= (logoRect.y + logoRect.height)))
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

		GUI.Label(new Rect(350, 300, 300, 30), "How to Play section to come...");

		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{
			if ((myMousePosition.x >= logoRect.x) && (myMousePosition.x <= (logoRect.x + logoRect.width)) && (myMousePosition.y >= logoRect.y) && (myMousePosition.y <= (logoRect.y + logoRect.height)))
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
				/* sprawdzanie jsona */
				if (playerProfileController.CheckIfProfileExist(playerProfile.playerName))
					playerProfileController.LoadProfile();
	}
}
