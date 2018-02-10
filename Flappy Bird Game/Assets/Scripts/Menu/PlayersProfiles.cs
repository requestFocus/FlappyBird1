using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public sealed class PlayersProfiles
{
	private static PlayersProfiles _instance;

	public static PlayersProfiles Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new PlayersProfiles();
			}
			return _instance;
		}
	}

	private PlayersProfiles() { }

	public List<PlayerProfile> ListOfProfiles = new List<PlayerProfile>();                      
	public int CurrentProfile = -1;
}


