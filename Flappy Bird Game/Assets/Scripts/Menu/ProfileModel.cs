using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileModel
{
	public static PlayerProfile CurrentProfile;

	public ProfileModel()
	{
		CurrentProfile = MainLobbyModel.CurrentProfile;
	}
}
