using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

	protected MainLobbyModel _mainLobbyModel;
	protected ProfileModel _profileModel;
	protected AchievementsModel _achievementsModel;

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

	//protected T _Model;

	//public void SetModel<T>(T model)
	//{
	//	_Model = model;
	//}

}
