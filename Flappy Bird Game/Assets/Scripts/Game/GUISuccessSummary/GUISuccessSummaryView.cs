using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GUISuccessSummaryView : MonoBehaviour 
{
	[SerializeField] private Text _nameScoreSummary;
	[SerializeField] private Text _newHighscoreSummary;
	[SerializeField] private Text _newAchievementsSummary;
	[SerializeField] private Button _repeatButton;
	[SerializeField] private Button _dontRepeatButton;
	[SerializeField] private GameObject _summaryBackground;

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

	[Inject]
	private PlayerProfileController _playerProfileController;

	private void Start()
	{
		_nameScoreSummary.text = "";
		_newHighscoreSummary.text = "";
		_newAchievementsSummary.text = "";
		SetSummaryScreen(false);

		DisplayGUISummaryView();
	}

	private void OnEnable()                                             // WIDOK SUMMARY
	{
		_repeatButton.onClick.AddListener(RepeatGame);
		_dontRepeatButton.onClick.AddListener(BackToMenu);
	}

	public void RepeatGame()                                            // WIDOK SUMMARY
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		SceneManager.LoadScene("Game");
	}

	public void BackToMenu()                                            // WIDOK SUMMARY				
	{
		MenuManager.BackFromGamePlay = true;
		SceneManager.LoadScene("Menu");
	}


	/*
	 * nowy highscore wyznacza konieczność uaktualnienia danych
	 * 
	 * odblokowanie nowego achievementu oznacza, że jest nowy highscore,
	 * ale nowy highscore nie oznacza odblokowania nowego achievementu
	 */

	public void DisplayGUISummaryView()                                // WIDOK SUMMARY
	{
		SetSummaryScreen(true);

		_nameScoreSummary.text = _projectData.EntireList[_projectData.CurrentID].PlayerName + ", your score is " + _currentPlayerData.CurrentScore;

		_newHighscoreSummary.text = "New highscore! You did well!";

		if (_currentPlayerData.AchievementIsUnlocked)							// służy wyłącznie wyświetleniu info o odblokowanym achievemencie, aktualizacja modelu nastąpiła w GUIGamePlayView
			_newAchievementsSummary.text = "New achievement(s) unlocked! Congrats!";

		UpdateModel(_currentPlayerData.CurrentScore);
	}

	public void SetSummaryScreen(bool state)                           // WIDOK SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		_summaryBackground.SetActive(state);
		_repeatButton.gameObject.SetActive(state);
		_dontRepeatButton.gameObject.SetActive(state);
	}

	public void UpdateModel(int score)
	{
		_projectData.EntireList[_projectData.CurrentID].HighScore = score;

		_playerProfileController.SaveProfile(_projectData);               // zapisz wyniki przed powrotem do sceny MENU
	}
}
