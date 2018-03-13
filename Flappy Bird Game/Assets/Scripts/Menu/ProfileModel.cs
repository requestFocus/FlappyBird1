using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
