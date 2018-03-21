using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIService {

	public void StartPause()                                           // SERWIS WIDOKU GAMEPLAY
	{
		Time.timeScale = 0;
	}

	public void BreakPause()                                           // SERWIS WIDOKU SUMMARY
	{
		Time.timeScale = 1;
	}
}
