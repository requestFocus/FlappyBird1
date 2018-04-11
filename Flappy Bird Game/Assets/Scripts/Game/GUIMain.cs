using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	[SerializeField] private ViewManager ViewManagerPrefab;
	[SerializeField] private ViewManager ViewManagerInstance;

	[SerializeField] private LevelService LevelService;


	private void Awake()
	{
		ViewManagerInstance = Instantiate(ViewManagerPrefab);
		LevelService.OnCurrentStateChange = SwitchViewInViewManager;

	//	LevelService.OnStateChange(SwitchViewInViewManager);
	}

	//private void Update()
	//{
	//	ViewManagerInstance.SwitchView();
	//}

	public void SwitchViewInViewManager()
	{
		Debug.Log("Switch state");
		ViewManagerInstance.SwitchView();  //??????                           
	}
}
