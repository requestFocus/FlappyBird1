using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject MainMenuButton;
	public GameObject HelpMenuButton;
	public GameObject CreditsMenuButton;

	private Vector3 myMousePosition;

	private static bool MainMenu;
	private static bool Help;
	private static bool Credits;

	private void Start()
	{
		MainMenu = true;
	}

	private void Update()
	{
	}

	private void OnGUI()
	{

		if (MainMenu) {
			DrawMainMenu();

		}

		else if (Help)
		{
			DrawMenu(200);
		}

		else if (Credits)
		{
			DrawMenu(300);
		}

	}	

	private void DrawMenu(int xposition)				// obsluga BACK buttona i pojedynczego MENU
	{
		//myMousePosition = Input.mousePosition;		// Input.mousePosition operuje w przestrzeni bottom left to top right
		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (HelpMenuButton.GetComponent<Button>())
		{
			if (myMousePosition.x >= 100 && myMousePosition.x <= 200 && myMousePosition.y >= 100 && myMousePosition.y <= 200)
			{
				MainMenu = true;
				Help = false;
				Credits = false;
			}
		}
	}

	private void DrawMainMenu()								// obsluga MAIN MENU
	{

		//myMousePosition = Input.mousePosition;		// Input.mousePosition operuje w przestrzeni bottom left to top right
		myMousePosition = Event.current.mousePosition;  // Event.current.mousePosition operuje w przestrzeni top left to bottom right	

		if (Input.GetMouseButtonDown(0))
		{

			if (myMousePosition.x >= 100 && myMousePosition.x <= 200 && myMousePosition.y >= 100 && myMousePosition.y <= 200)
			{
				MainMenu = true;
				Help = false;
				Credits = false;
			}
			else if (myMousePosition.x >= 200 && myMousePosition.x <= 300 && myMousePosition.y >= 100 && myMousePosition.y <= 200)
			{
				MainMenu = false;
				Help = true;
				Credits = false;
			}
			else if (myMousePosition.x >= 300 && myMousePosition.x <= 400 && myMousePosition.y >= 100 && myMousePosition.y <= 200)
			{
				MainMenu = false;
				Help = false;
				Credits = true;
			}
			else if (myMousePosition.x >= 400 && myMousePosition.x <= 500 && myMousePosition.y >= 100 && myMousePosition.y <= 200)
			{
				MainMenu = false;
				Help = false;
				Credits = false;
			}
		}
	}

}

