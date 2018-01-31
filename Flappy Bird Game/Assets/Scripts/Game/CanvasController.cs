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
	public GameObject SummaryBackground;

	private void Start()
	{
		SummaryBackground.SetActive(false);
	}

	public void DisplayCanvas()
	{
		Time.timeScale = 0;
		ScoreText.text = "<color=WHITE>" + PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName + ", your score (now highscore) is " + 
								PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore + "</color>";
		PlayerProfileController.SaveProfile(PlayersProfiles.Instance);                          // zapisz wyniki przed powrotem do sceny MENU
		Canvas.gameObject.SetActive(true);
	}

	private void OnEnable()
	{
		SummaryBackground.SetActive(true);
		RepeatButton.onClick.AddListener(RepeatGame);
		DontRepeat.onClick.AddListener(BackToMenu);
	}

	public void RepeatGame()
	{
		SceneManager.LoadScene("Game");
		BreakPause();
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene("Menu");
		BreakPause();
	}

	private void BreakPause()
	{
		Time.timeScale = 1;
		SummaryBackground.SetActive(false);
	}

}
