using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUISummaryView : View<GUISummaryModel, GUISummaryController>
{
	[SerializeField] private Text NameScoreSummary;
	[SerializeField] private Text NewHighscoreSummary;
	[SerializeField] private Text NewAchievementsSummary;
	[SerializeField] private Button RepeatButton;
	[SerializeField] private Button DontRepeatButton;
	[SerializeField] private GameObject SummaryBackground;

	[SerializeField] private GUIService GUIService;
	//[SerializeField] private LevelService LevelService;

	private void Start()
	{
		NameScoreSummary.text = "";
		NewHighscoreSummary.text = "";
		NewAchievementsSummary.text = "";
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

		NameScoreSummary.text = Model.CurrentProfile.PlayerName + ", your score is " + LevelService.Instance.CurrentScore;

		/*
		 * nowy highscore wyznacza konieczność uaktualnienia danych
		 * 
		 * odblokowanie nowego achievementu oznacza, że jest nowy highscore,
		 * ale nowy highscore nie oznacza odblokowania nowego achievementu
		 */

		if (LevelService.Instance.CurrentScore > Model.CurrentProfile.HighScore)
		{
			NewHighscoreSummary.text = "New highscore! You did well!";

			if (Model.AchievementIsUnlocked)							// służy wyłącznie wyświetleniu info o odblokowanym achievemencie, aktualizacja modelu nastąpiła w GUIGamePlayView
			{
				NewAchievementsSummary.text = "New achievement(s) unlocked! Congrats!";
			}

			Controller.UpdateModel(LevelService.Instance.CurrentScore);
		}
	}

	private void SetSummaryScreen(bool state)                           // WIDOK SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		SummaryBackground.SetActive(state);
		RepeatButton.gameObject.SetActive(state);
		DontRepeatButton.gameObject.SetActive(state);
	}
}
