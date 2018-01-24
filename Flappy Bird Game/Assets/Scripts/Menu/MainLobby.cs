﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobby : MonoBehaviour {

	public Texture LogoButton; 
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

	public PlayerProfile playerProfile;
	public PlayersProfiles playersProfiles;                             // lista profili tworzona podczas gry
	public PlayerProfileController playerProfileController;
	public ResizeController resizeController;

	private Vector3 myMousePosition;
	private string justPlayerName;

	private static bool MainMenu;
	private static bool HowtoPlay;
	private static bool Credits;
	private static bool Achievements;
	private static bool NewGame;
	private static bool GamePlay;

	private void Start()
	{
		MainMenu = true;
		justPlayerName = "";
		//PlayerPrefs.DeleteAll();
	}

	private void Update()
	{
		// ================================================================= czy to nie działa tak samo jak OnGUI()?
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
			}

			// NEW GAME
			else if ((myMousePosition.x >= newGameRect.x) && (myMousePosition.x <= (newGameRect.x + newGameRect.width)) && (myMousePosition.y >= newGameRect.y) && (myMousePosition.y <= (newGameRect.y + newGameRect.height)))
			{
				MainMenu = false;
				HowtoPlay = false;
				Credits = false;
				Achievements = false;
				NewGame = true;
			}

			// HOW TO PLAY
			else if ((myMousePosition.x >= howtoPlayRect.x) && (myMousePosition.x <= (howtoPlayRect.x + howtoPlayRect.width)) && (myMousePosition.y >= howtoPlayRect.y) && (myMousePosition.y <= (howtoPlayRect.y + howtoPlayRect.height)))
			{
				MainMenu = false;
				HowtoPlay = true;
				Credits = false;
				Achievements = false;
				NewGame = false;
			}

			// CREDITS
			else if ((myMousePosition.x >= creditsRect.x) && (myMousePosition.x <= (creditsRect.x + creditsRect.width)) && (myMousePosition.y >= creditsRect.y) && (myMousePosition.y <= (creditsRect.y + creditsRect.height)))
			{
				MainMenu = false;
				HowtoPlay = false;
				Credits = true;
				Achievements = false;
				NewGame = false;
			}

			// ACHIEVEMENTS
			else if ((myMousePosition.x >= achievementsRect.x) && (myMousePosition.x <= (achievementsRect.x + achievementsRect.width)) && (myMousePosition.y >= achievementsRect.y) && (myMousePosition.y <= (achievementsRect.y + achievementsRect.height)))
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
		justPlayerName = GUI.TextField(resizeController.ResizeGUI(new Rect(350, 270, 100, 25)), justPlayerName, 10);

		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		Rect startRect = DrawElement(300, 300, 200, 60, StartButton);
		DrawElement(350, 550, 100, 30, menuElement);

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

			if ((myMousePosition.x >= startRect.x) && (myMousePosition.x <= (startRect.x + startRect.width)) && (myMousePosition.y >= startRect.y) && (myMousePosition.y <= (startRect.y + startRect.height)))
			{
				if (justPlayerName.Length > 0)
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
		GUI.Label(resizeController.ResizeGUI(new Rect(10, 10, 300, 50)), "Name: " + playerProfile.playerName + " // Highscore: " + playerProfile.highScore);
		Rect gamePlayRect = DrawElement(315, 400, 170, 170, HighscoreBoost);                       

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
				playerProfileController.SaveProfile(playersProfiles);
			}

			if ((myMousePosition.x >= gamePlayRect.x) && (myMousePosition.x <= (gamePlayRect.x + gamePlayRect.width)) && (myMousePosition.y >= gamePlayRect.y) && (myMousePosition.y <= (gamePlayRect.y + gamePlayRect.height)))
			{
				playerProfile.highScore = playerProfile.highScore + 1;                                          // DEMONSTRACJA DZIAŁANIA PLAYERPREFS/JSON
				// dlaczego dodaje sie dwa razy po jednym kliknieciu? =====================================================================================================
				playerProfileController.SaveProfile(playersProfiles);
			}
		}
	}

	private void DrawCreditsMenu(Texture menuElement)               // obsluga CREDITS
	{ 
		Rect logoRect = DrawElement(315, 20, 170, 170, LogoButton);
		DrawElement(350, 550, 100, 30, menuElement);

		GUI.Label(resizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "Credits section to come...");

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

		GUI.Label(resizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "Achievements section to come...");

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

		GUI.Label(resizeController.ResizeGUI(new Rect(300, 270, 200, 30)), "How to Play section to come...");

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
		bool isOnTheList = false;

		if (playerProfileController.LoadProfiles() is PlayersProfiles)                      // jesli istnieje lista w pamieci
		//if (PlayerPrefs.GetString("ProfileSettings").Length > 0)						// jeśli PlayerPrefs zawiera dane====================================================
		{
			playersProfiles = playerProfileController.LoadProfiles();

			for (int i = 0; i < playersProfiles.listOfProfiles.Count; i++)
			{
				if (playersProfiles.listOfProfiles[i].playerName.Equals(justPlayerName))            // jeśli na liście wystepuje podane NAME
				{
					playerProfile = playersProfiles.listOfProfiles[i];
					isOnTheList = true;
					break;
				}
			}

			if (!isOnTheList)                                                                               // jesli na liscie nie wystepuje podane NAME
			{
				playerProfile = new PlayerProfile(justPlayerName, 0, false);
				playersProfiles.listOfProfiles.Add(playerProfile);
			}
		}
		else																				// jesli nie istnieje lista w pamieci
		{
			playersProfiles.listOfProfiles.Add(playerProfile);								// tworzy liste i dopisuje aktualnego playerProfile
		}
	}
}