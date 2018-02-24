using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                                   // czy to musi byc Serializable
public class PlayerProfile {

	public string PlayerName;
	public int HighScore;
	public bool Complete10;
	public bool Complete25;
	public bool Complete50;

	public PlayerProfile(string playerName, int highScore, bool complete10, bool complete25, bool complete50)
	{
		PlayerName = playerName;
		HighScore = highScore;
		Complete10 = complete10;
		Complete25 = complete25;
		Complete50 = complete50;
	}
}


