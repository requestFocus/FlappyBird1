using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuScreensService
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
	public static MenuScreens MenuStates;
}