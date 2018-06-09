using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GUIFailureSummaryView : MonoBehaviour 
{
	[SerializeField] private Text NameScoreSummary;
	[SerializeField] private Text NoHighscoreSummary;
	[SerializeField] private Button RepeatButton;
	[SerializeField] private Button DontRepeatButton;
	[SerializeField] private GameObject SummaryBackground;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

	private void Start()
	{
		NameScoreSummary.text = "";
		NoHighscoreSummary.text = "";
		SetSummaryScreen(false);

		DisplayGUISummaryView();
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
	}

	public void BackToMenu()                                            // WIDOK SUMMARY				
	{
		Main.BackFromGamePlay = true;
		SceneManager.LoadScene("Menu");
	}

	public void DisplayGUISummaryView()                                // WIDOK SUMMARY
	{
		SetSummaryScreen(true);

		NameScoreSummary.text = _currentPlayerData.CurrentProfile.PlayerName + ", your score is " + _currentPlayerData.CurrentScore;

		NoHighscoreSummary.text = "Better luck next time...";
	}

	public void SetSummaryScreen(bool state)                           // WIDOK SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		SummaryBackground.SetActive(state);
		RepeatButton.gameObject.SetActive(state);
		DontRepeatButton.gameObject.SetActive(state);
	}
}
