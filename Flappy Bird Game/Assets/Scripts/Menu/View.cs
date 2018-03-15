using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
=======
public class View<T> : MonoBehaviour {
>>>>>>> Generics

	/* 
	 * Widoki, które nie posiadają Modelu nie dziedziczą po View<T>, tylko bezpośrednio po MonoBehaviour
	 */ 

	protected T _Model;

	public void SetModel(T model)
	{
		_Model = model;
	}
}
