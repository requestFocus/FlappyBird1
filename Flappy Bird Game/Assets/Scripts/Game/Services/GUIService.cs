using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIService : MonoBehaviour
{
	public void RepeatGame()                                            // WIDOK SUMMARY
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		SceneManager.LoadScene("Game");
	}

	public void BackToMenu()                                            // WIDOK SUMMARY				
	{
		Main.BackFromGamePlay = true;
		SceneManager.LoadScene("Menu");
		//Time.timeScale = 1;
	}
}
