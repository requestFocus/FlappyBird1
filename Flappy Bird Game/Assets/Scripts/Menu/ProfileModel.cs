using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class ProfileModel
//{
//	public static PlayerProfile CurrentProfile;

//	//public MainLobbyModel MainLobbyModel;
//	//public int TestProfile;

//	public ProfileModel()
//	{
//		CurrentProfile = MainLobbyModel.CurrentProfile;

//		//MainLobbyModel = new MainLobbyModel();
//		//TestProfile = MainLobbyModel.TestModel;

//		//Debug.Log("TestProfile: " + TestProfile);
//		//Debug.Log("MainLobbyModel.TestModel: " + MainLobbyModel.TestModel);
//	}
//}

public class ProfileModel
{
	public PlayerProfile CurrentProfile;
	public MainLobbyModel MainLobbyModel;
	public int TestProfile;

	public ProfileModel()
	{
		MainLobbyModel = new MainLobbyModel();
		CurrentProfile = MainLobbyModel.CurrentProfile;
		TestProfile = MainLobbyModel.TestModel;
	}
}
