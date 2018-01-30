using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{

	public Text ScoreText;
	public Button RepeatButton;
	public Button DontRepeat;
	public Canvas Canvas;

	public PlayerProfileController PlayerProfileController;

	public void DisplayCanvas()
	{
		Time.timeScale = 0;
		ScoreText.text = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName + ", your score (now highscore) is " + 
						PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore;
		PlayerProfileController.SaveProfile(PlayersProfiles.Instance);                          // zapisz wyniki przed powrotem do sceny MENU
		Canvas.gameObject.SetActive(true);
	}

	private void OnEnable()
	{
		
		RepeatButton.onClick.AddListener(RepeatGame);
		DontRepeat.onClick.AddListener(BackToMenu);
	}

	public void RepeatGame()
	{
		SceneManager.LoadScene("Game");
		Time.timeScale = 1;
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1;
	}

}
