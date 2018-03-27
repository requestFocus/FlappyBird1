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

	[SerializeField] private GUIService GUIService;
	[SerializeField] private LevelService LevelService;

	private PlayerProfileController _playerProfileController = new PlayerProfileController();

	/*
	 * może być konieczne Destroy(gameObject) GUIGamePlayView, żeby znikały Texty z GamePlayu na górze ekranu
	 */

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

		NameScoreSummary.text = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName + ", your score is " + LevelService.CurrentScore;

		if (GUIService.CheckHighscoreTable(LevelService.CurrentScore))
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
