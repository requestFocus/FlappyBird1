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

	public List<PlayerProfile> ListOfProfiles;                      // czy to powinno być statyczne? czy to ListOfProfiles powinno być instancją singletona?
	public int CurrentProfile = -1;
}





//public sealed class PlayersProfiles
//{
//	private static List<PlayerProfile> _listOfProfiles;

//	public static List<PlayerProfile> ListOfProfiles
//	{
//		get
//		{
//			if (_listOfProfiles == null)
//			{
//				_listOfProfiles = new List<PlayerProfile>();
//			}
//			return _listOfProfiles;
//		}
//	}
//}