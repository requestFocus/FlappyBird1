using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIService : MonoBehaviour
{
	//[SerializeField] private Text AchievementUnlockedGamePlay;

	//private void Start()
	//{
	//	AchievementUnlockedGamePlay.text = "";
	//}

	public void StartPause()                                           // SERWIS WIDOKU GAMEPLAY
	{
		Time.timeScale = 0;
	}

	public void BreakPause()                                           // SERWIS WIDOKU SUMMARY
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


	//public IEnumerator AchievementUnlockedNotification()                // WIDOK GAMEPLAY, wyswietla info o odblokowaniu achievementu
	//{
	//	AchievementUnlockedGamePlay.text = "New achievement!";
	//	yield return new WaitForSeconds(2);
	//	AchievementUnlockedGamePlay.text = "";
	//}
}
