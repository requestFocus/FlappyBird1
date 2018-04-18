using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMain : MonoBehaviour
{
	[SerializeField] private ViewManager ViewManager;
	[SerializeField] private LevelService LevelService;

	private void Awake()
	{
		LevelService.OnCurrentStateChangeDel = SwitchViewInViewManager;                    // przy takim "standardowym" (dla projektu) wywołaniu obiekt delegata musi być publiczny
	}

	public void SwitchViewInViewManager()
	{
		ViewManager.SwitchView();           
	}
}
