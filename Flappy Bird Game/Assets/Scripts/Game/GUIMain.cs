﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	[SerializeField] private ViewManager ViewManagerPrefab;
	[SerializeField] private ViewManager ViewManagerInstance;

	////public delegate void SetState();                                   
	//public delegate void SetState(CurrentGameStateService.GameStates state);                                    
	//public SetState SetStateIns;                                       

	private void Start()
	{
		ViewManagerInstance = Instantiate(ViewManagerPrefab);

		//SwitchViewInViewManager(SetStateIns);                          
	}

	private void Update()
	{
		ViewManagerInstance.SwitchView();
	}

	//public void SwitchViewInViewManager(SetState SetStateIns)           
	//{                                                                  
	//	//SetStateIns();
	//	//ViewManagerInstance.SwitchView();                             
	//}                                                                   
}
