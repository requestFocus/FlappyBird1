using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreensService
{
	public enum MenuScreens
	{
		Login,
		MainMenu,
		HowtoPlay,
		Credits,
		Achievements,
		NewGame,
		Profile
	};
	public MenuScreens MenuStates;
}