using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobby : MonoBehaviour {

	public Texture viento; 
	public Texture vientoR;
	public Texture vientoG;
	public Texture vientoB;
	public ResizeController resizeController;

	private Vector3 myMousePosition;

	private static bool LoginMenu;
	private static bool MainMenu;
	private static bool Help;
	private static bool Credits;
	private static bool Achievements;

	private bool isButtonClicked;
	private string playerName;
	private string loginField;
	private string loginButton;


	private void Start()
	{
		playerName = "";
		loginField = "Your name: ";
		loginButton = "Click to log in";
		LoginMenu = true;

		//PlayerPrefs.DeleteAll();
	}

	private void Update()
	{
		PlayerPrefs.SetString("Name", playerName);      // zapisz USERNAME do PlayerPrefs
	}

	private void OnGUI()
	{

		GUI.color = Color.white;

		if (LoginMenu)
		{
			DrawLoginMenu();
		}

		else if (MainMenu) {
			DrawMainMenu();
	
		}

		else if (Help)
		{
			DrawMenu(200, vientoR);
		}

		else if (Credits)
		{
			DrawMenu(300, vientoG);
		}

		else if (Achievements)
		{
			DrawMenu(400, vientoB);
			PlayerPrefs.SetInt("Visited", 1);
		}
	}	

	private Rect DrawElement(int x, int y, int width, int height, Texture graphicViento)
	{
		if (!graphicViento)
		{
			Debug.Log("No texture assigned");
			throw new Exception();
		}

		Rect buttonScalableDimensions = resizeController.ResizeGUI(new Rect(x, y, width, height));

		//GUI.DrawTexture(ResizeGUI(new Rect(x, y, width, height)), graphicViento);
		GUI.DrawTexture(buttonScalableDimensions, graphicViento);

		return buttonScalableDimensions;
	}

	private void DrawMenu(int xposition, Texture graphicViento)				// obsluga BACK buttona i pojedynczego MENU
	{
		GUI.Label(new Rect(10, 10, 100, 100), "Logged as: " + PlayerPrefs.GetString("Name", playerName) + " // " + PlayerPrefs.GetInt("Visited", 0));

		Rect First = DrawElement(100, 100, 100, 100, viento);
		DrawElement(xposition, 100, 100, 100, graphicViento);

		//myMousePosition = Input.mousePosition;		// Input.mousePosition operuje w przestrzeni bottom left to top right
		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	
	
		if (Input.GetMouseButtonDown(0))
		{
			if ((myMousePosition.x >= First.x) && (myMousePosition.x <= (First.x + First.width)) && (myMousePosition.y >= First.y) && (myMousePosition.y <= (First.y + First.height)))
			{
				LoginMenu = false;
				MainMenu = true;
				Help = false;
				Credits = false;
				Achievements = false;
			}
		}
	}

	private void DrawMainMenu()								// obsluga MAIN MENU
	{

		GUI.Label(new Rect(10, 10, 100, 100), "Logged as: " + PlayerPrefs.GetString("Name", playerName) + " // " + PlayerPrefs.GetInt("Visited", 0));
		isButtonClicked = GUI.Button(new Rect(10, 60, 100, 25), "Logout?");

		if (isButtonClicked)
		{
			LoginMenu = true;
			MainMenu = false;
			playerName = "";
		}

		Rect First = DrawElement(100, 100, 100, 100, viento);            // x y w h img
		Rect Second = DrawElement(200, 100, 100, 100, vientoR);
		Rect Third = DrawElement(300, 100, 100, 100, vientoG);
		Rect Fourth = DrawElement(400, 100, 100, 100, vientoB);

		//myMousePosition = Input.mousePosition;		// Input.mousePosition operuje w przestrzeni bottom left to top right
		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{

			if ((myMousePosition.x >= First.x) && (myMousePosition.x <= (First.x + First.width)) && (myMousePosition.y >= First.y) && (myMousePosition.y <= (First.y + First.height)))
			{
				LoginMenu = false;
				MainMenu = true;
				Help = false;
				Credits = false;
				Achievements = false;
				//Debug.Log("MousePosition X: " + myMousePosition.x + " Y: " + myMousePosition.y + " // " + "RectDimensions X: " + First.x + " do " + (First.x + First.width) + " Y: " + First.y + " do " + (First.y + First.height));
			}
			//else if (myMousePosition.x >= 200 && myMousePosition.x <= 300 && myMousePosition.y >= 100 && myMousePosition.y <= 200)
			else if ((myMousePosition.x >= Second.x) && (myMousePosition.x <= (Second.x + Second.width)) && (myMousePosition.y >= Second.y) && (myMousePosition.y <= (Second.y + Second.height)))
			{
				LoginMenu = false;
				MainMenu = false;
				Help = true;
				Credits = false;
				Achievements = false;
			}
			//else if (myMousePosition.x >= 300 && myMousePosition.x <= 400 && myMousePosition.y >= 100 && myMousePosition.y <= 200)
			else if ((myMousePosition.x >= Third.x) && (myMousePosition.x <= (Third.x + Third.width)) && (myMousePosition.y >= Third.y) && (myMousePosition.y <= (Third.y + Third.height)))
			{
				LoginMenu = false;
				MainMenu = false;
				Help = false;
				Credits = true;
				Achievements = false;
			}
			//else if (myMousePosition.x >= 400 && myMousePosition.x <= 500 && myMousePosition.y >= 100 && myMousePosition.y <= 200)
			else if ((myMousePosition.x >= Fourth.x) && (myMousePosition.x <= (Fourth.x + Fourth.width)) && (myMousePosition.y >= Fourth.y) && (myMousePosition.y <= (Fourth.y + Fourth.height)))
			{
				LoginMenu = false;
				MainMenu = false;
				Help = false;
				Credits = false;
				Achievements = true;
			}
		}
	}

	private void DrawLoginMenu()
	{
		GUI.Label(new Rect(10, 10, 100, 25), loginField);
		playerName = GUI.TextField(new Rect(80, 10, 100, 25), playerName, 10);
		isButtonClicked = GUI.Button(new Rect(10, 35, 100, 25), loginButton);

		if (isButtonClicked)									// czy kliknieto button ZALOGUJ?
		{
			if (playerName.Length > 0)							// wpisano USERNAME
			{
				LoginMenu = false;								// wylacz tryb LOGIN MENU
				MainMenu = true;								// aktywuj tryb MAIN MENU
			}
			else												// NIE WPISANO USERNAME
			{
				Debug.Log("bad login");
			}
		}
	}
}
