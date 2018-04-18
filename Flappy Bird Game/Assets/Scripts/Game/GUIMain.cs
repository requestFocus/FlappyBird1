using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	[SerializeField] private ViewManager ViewManager;

	private void Awake()
	{
		LevelService.Instance.OnCurrentStateChangeDel = SwitchViewInViewManager;                    // przy takim "standardowym" (dla projektu) wywołaniu obiekt delegata musi być publiczny
	}

	public void SwitchViewInViewManager()
	{
		ViewManager.SwitchView();           
	}
}
