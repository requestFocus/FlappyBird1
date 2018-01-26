using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                                   // czy to musi byc Serializable
public class PlayerProfile {

	public string PlayerName;
	public int HighScore;
	public bool Complete10;

	public PlayerProfile(string playerName, int highScore, bool complete10)
	{
		PlayerName = playerName;
		HighScore = highScore;
		Complete10 = complete10;
	}
}




/* 
PROFIL
W jaki sposob obslugiwac profil gracza podczas gry: w czasie rzeczywistym czy po skonczonej grze? 
singleton, jeden statyczny obiekt przekazywany między scenami, tworzony w momencie, kiedy gracz podaje imie i istniejący do czasu wyłączenia gry
*/