﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentGameStateService
{
	public enum GameStates
	{
		GamePlay,
		Summary
	};
	public static GameStates CurrentGameState;
}