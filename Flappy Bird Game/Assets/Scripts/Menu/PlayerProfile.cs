using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]									// czy to musi byc Serializable
public class PlayerProfile {

	public string playerName;
	public int highScore;
	public bool complete10;

	public PlayerProfile(string playerName, int highScore, bool complete10)
	{
		this.playerName = playerName;
		this.highScore = highScore;
		this.complete10 = complete10;
	}
}




/* 
 * GITIGNORE
Skad wiedziec, jakie pliki wykluczać? bo chyba powinno być to storage.ide // GOOGLE IT!

PROFIL
W jaki sposob obslugiwac profil gracza podczas gry: w czasie rzeczywistym czy po skonczonej grze? 
singleton, jeden statyczny obiekt przekazywany między scenami, tworzony w momencie, kiedy gracz podaje imie i istniejący do czasu wyłączenia gry
*/