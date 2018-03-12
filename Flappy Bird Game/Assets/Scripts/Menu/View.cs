using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

	private MainLobbyModel _mainLobbyModel;
	private ProfileModel _profileModel;
	private AchievementsModel _achievementsModel;

	public void SetModel(MainLobbyModel model)
	{
		_mainLobbyModel = model;
	}



	public void SetModel(ProfileModel model)
	{
		_profileModel = model;
	}



	public void SetModel(AchievementsModel model)
	{
		_achievementsModel = model;
	}
}
