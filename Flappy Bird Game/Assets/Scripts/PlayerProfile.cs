using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

