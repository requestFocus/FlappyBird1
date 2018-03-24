using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUISummaryView : MonoBehaviour {

	[SerializeField] private Text NameScoreSummary;
	[SerializeField] private Text NewHighscoreSummary;
	[SerializeField] private Button RepeatButton;
	[SerializeField] private Button DontRepeatButton;
	[SerializeField] private GameObject SummaryBackground;

	[SerializeField] private GameManager GameManager;
	[SerializeField] private GUIService GUIService;

	private PlayerProfileController _playerProfileController = new PlayerProfileController();

	private void Start()
	{
		NameScoreSummary.text = "";
		NewHighscoreSummary.text = "";
		SetSummaryScreen(false);
	}

	private void OnEnable()                                             // WIDOK SUMMARY
	{
		RepeatButton.onClick.AddListener(RepeatGame);
		DontRepeatButton.onClick.AddListener(BackToMenu);
	}

	public void RepeatGame()                                            // WIDOK SUMMARY
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		SceneManager.LoadScene("Game");
		BackFromPause();
	}

	public void BackToMenu()                                            // WIDOK SUMMARY				
	{
		Main.BackFromGamePlay = true;
		SceneManager.LoadScene("Menu");
		BackFromPause();
	}

	public void BackFromPause()                                         // WIDOK SUMMARY
	{
		GUIService.BreakPause();								    // timescale back to 1
		SummaryBackground.SetActive(false);                         // odciemnij tło
	}

	public void DisplayGUISummaryView()                                // WIDOK SUMMARY
	{
		GUIService.StartPause();
		SetSummaryScreen(true);

		NameScoreSummary.text = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName + ", your score is " + GameManager.CurrentScore;

		if (GUIService.CheckHighscoreTable(GameManager.CurrentScore))
		{
			NewHighscoreSummary.text = "New highscore! You did well!";
		}
		// KONTROLER
		_playerProfileController.SaveProfile(PlayersProfiles.Instance);               // zapisz wyniki przed powrotem do sceny MENU
	}

	private void SetSummaryScreen(bool state)                           // WIDOK SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		SummaryBackground.SetActive(state);
		RepeatButton.gameObject.SetActive(state);
		DontRepeatButton.gameObject.SetActive(state);
	}
}
