using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUISummaryView : View<GUISummaryModel, GUISummaryController>
{
	[SerializeField] private Text NameScoreSummary;
	[SerializeField] private Text NewHighscoreSummary;
	[SerializeField] private Button RepeatButton;
	[SerializeField] private Button DontRepeatButton;
	[SerializeField] private GameObject SummaryBackground;

	[SerializeField] private GUIService GUIService;
	[SerializeField] private LevelService LevelService;

	private void Start()
	{
		NameScoreSummary.text = "";
		NewHighscoreSummary.text = "";
		SetSummaryScreen(false);
	}

	private void Update()
	{
		DisplayGUISummaryView();
	}

	private void OnEnable()                                             // WIDOK SUMMARY
	{
		RepeatButton.onClick.AddListener(GUIService.RepeatGame);
		DontRepeatButton.onClick.AddListener(GUIService.BackToMenu);
	}

	public void DisplayGUISummaryView()                                // WIDOK SUMMARY
	{
		Time.timeScale = 0;
		SetSummaryScreen(true);

		NameScoreSummary.text = Model.PlayersProfilesSentFromGamePlay.ListOfProfiles[Model.PlayersProfilesSentFromGamePlay.CurrentProfile].PlayerName + ", your score is " + LevelService.CurrentScore;

		/*
		 * DODATKOWE INFO: czy odblokowano achievement? 
		 * jak dodać model GUIGamePlayModel, żeby korzystać z jego zaktualizowanych danych? ----- ten model sam się dodaje w GUIMain, kiedy GUISummary.Model dostaje kopię GUIGamePlay.Model
		 */

		if (LevelService.CurrentScore > Model.PlayersProfilesSentFromGamePlay.ListOfProfiles[Model.PlayersProfilesSentFromGamePlay.CurrentProfile].HighScore)
		{
			NewHighscoreSummary.text = "New highscore! You did well!";

			Controller.CheckHighscoreTable(Model, LevelService.CurrentScore);       // jeśli scena nie będzie przeładowywana, trzeba od razu poinformować model GUIGamePlayView, bo inaczej dane się rozjadą
			Controller.UpdateModel(Model.PlayersProfilesSentFromGamePlay);
		}
	}

	private void SetSummaryScreen(bool state)                           // WIDOK SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		SummaryBackground.SetActive(state);
		RepeatButton.gameObject.SetActive(state);
		DontRepeatButton.gameObject.SetActive(state);
	}
}
