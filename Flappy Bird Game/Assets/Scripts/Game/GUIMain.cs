using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	[SerializeField] private ViewManager ViewManagerPrefab;
	[SerializeField] private ViewManager ViewManagerInstance;

	private void Awake()
	{
		ViewManagerInstance = Instantiate(ViewManagerPrefab);

		//LevelService.Instance.OnCurrentStateChangeDel = SwitchViewInViewManager;					// przy takim wywołaniu obiekt delegata musi być publiczny

		LevelService.Instance.OnStateChange(SwitchViewInViewManager);
	}

	public void SwitchViewInViewManager()
	{
		ViewManagerInstance.SwitchView();           
	}
}
