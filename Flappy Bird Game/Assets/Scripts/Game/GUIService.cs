using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIService : MonoBehaviour
{
	public void TimeScaleStop()                                           // SERWIS WIDOKU GAMEPLAY
	{
		Time.timeScale = 0;
	}



	public void TimeScaleStart()                                           // SERWIS WIDOKU SUMMARY
	{
		Time.timeScale = 1;
	}



	public bool CheckHighscoreTable(int currentScore)                                  // SERWIS WIDOKU SUMMARY, informuje CZY player ma nowy highscore
	{
		if (currentScore > PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore)
		{
			PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore = currentScore;
			return true;
		}

		return false;
	}


	public void RepeatGame()                                            // WIDOK SUMMARY
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		SceneManager.LoadScene("Game");
		TimeScaleStart();
	}



	public void BackToMenu()                                            // WIDOK SUMMARY				
	{
		Main.BackFromGamePlay = true;
		SceneManager.LoadScene("Menu");
		TimeScaleStart();
	}
}
