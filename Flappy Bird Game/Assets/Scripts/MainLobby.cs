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

	public PlayerProfile playerProfile;
	public PlayerProfileController playerProfileController;
	public ResizeController resizeController;

	private Vector3 myMousePosition;

	private static bool MainMenu;
	private static bool HowtoPlay;
	private static bool Credits;
	private static bool Achievements;
	private static bool NewGame;
	private static bool NameMenu;

	private bool isButtonClicked;
	private string nameField;
	private string nameButton;


	private void Start()
	{
		playerProfile = new PlayerProfile();
		playerProfile.playerName = "";
		nameField = "Your name: ";
		nameButton = "Click to log in";
		MainMenu = true;

		//PlayerPrefs.DeleteAll();
	}

	private void Update()
	{

	}

	private void OnGUI()
	{

		GUI.color = Color.white;

		if (MainMenu) {
			DrawMainMenu();
		}

		else if (HowtoPlay)
		{
			DrawChosenMenu(HowtoPlayButton);
		}

		else if (Credits)					
		{
			DrawChosenMenu(CreditsButton);
		}

		else if (Achievements)
		{
			DrawChosenMenu(AchievementsButton);
		}

		else if (NewGame)						// zawiera ekran wpisania imienia i przycisk Start!
		{
			DrawChosenMenu(NewGameButton);
		}
	}	

	private Rect DrawElement(int x, int y, int width, int height, Texture menuElement)
	{
		Rect buttonScalableDimensions = resizeController.ResizeGUI(new Rect(x, y, width, height));
		GUI.DrawTexture(buttonScalableDimensions, menuElement);

		return buttonScalableDimensions;
	}

	private void DrawChosenMenu(Texture menuElement)				// obsluga pojedynczego MENU i back buttona pod postacią LOGO
	{
		GUI.Label(new Rect(10, 10, 100, 100), "Your name is: " + playerProfile.playerName + " // Highscore: " + playerProfile.highScore);
		Rect logoRect = DrawElement(330, 20, 186, 186, LogoButton);
		DrawElement(310, 250, 200, 60, menuElement);

		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
	
		if (Input.GetMouseButtonDown(0))
		{
			if ((myMousePosition.x >= logoRect.x) && (myMousePosition.x <= (logoRect.x + logoRect.width)) && (myMousePosition.y >= logoRect.y) && (myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				NameMenu = false;
				MainMenu = true;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = false;

			}
		}
	}

	private void DrawMainMenu()								// obsluga MAIN MENU
	{

		GUI.Label(new Rect(10, 10, 100, 100), "Your name is: " + playerProfile.playerName + " // Highscore: " + playerProfile.highScore);
		isButtonClicked = GUI.Button(new Rect(10, 60, 100, 25), "Change user?");

		if (isButtonClicked)
		{
			NameMenu = true;
			MainMenu = false;
			playerProfileController.SaveProfile(playerProfile);
			playerProfile.playerName = "";
		}

		Rect logoRect = DrawElement(330, 20, 186, 186, LogoButton);
		Rect newGameRect = DrawElement(310, 250, 200, 60, NewGameButton);            // x y w h img
		Rect howtoPlayRect = DrawElement(310, 330, 200, 60, HowtoPlayButton);
		Rect creditsRect = DrawElement(310, 410, 200, 60, CreditsButton);
		Rect achievementsRect = DrawElement(310, 490, 200, 60, AchievementsButton);

		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{

			// LOGO - MAIN MENU
			if ((myMousePosition.x >= logoRect.x) && (myMousePosition.x <= (logoRect.x + logoRect.width)) && (myMousePosition.y >= logoRect.y) && (myMousePosition.y <= (logoRect.y + logoRect.height)))
			{
				NameMenu = false;
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
				NameMenu = false;
				MainMenu = false;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = true;
				Debug.Log("new game");
			}

			// HOW TO PLAY
			else if ((myMousePosition.x >= howtoPlayRect.x) && (myMousePosition.x <= (howtoPlayRect.x + howtoPlayRect.width)) && (myMousePosition.y >= howtoPlayRect.y) && (myMousePosition.y <= (howtoPlayRect.y + howtoPlayRect.height)))
			{
				NameMenu = false;
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
				NameMenu = false;
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
				NameMenu = false;
				MainMenu = false;
				HowtoPlay = false;
				Credits = false;
				Achievements = true;
				NewGame = false;
				Debug.Log("achievements");

				playerProfile.highScore++;
				playerProfileController.SaveProfile(playerProfile);
			}
		}
	}

	private void DrawLoginMenu()								// wchodzi dopiero po wybraniu NEW GAME
	{
		GUI.Label(new Rect(10, 10, 100, 25), nameField);
		playerProfile.playerName = GUI.TextField(new Rect(80, 10, 100, 25), playerProfile.playerName, 10);
		isButtonClicked = GUI.Button(new Rect(10, 35, 100, 25), nameButton);

		if (isButtonClicked)									
		{
			if (playerProfile.playerName.Length > 0)	// wpisano USERNAME
			{

				/* sprawdzanie jsona */
				if (playerProfileController.CheckIfProfileExist(playerProfile.playerName))
					playerProfileController.LoadProfile();

				NameMenu = false;								// wylacz tryb LOGIN MENU
				MainMenu = true;								// aktywuj tryb MAIN MENU
			}
			else												// NIE WPISANO USERNAME
			{
				Debug.Log("bad login");
				/* kod obslugi bledu */
			}
		}

	}
}
