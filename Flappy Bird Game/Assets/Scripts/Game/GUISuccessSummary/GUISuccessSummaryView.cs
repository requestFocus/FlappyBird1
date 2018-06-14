using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GUISuccessSummaryView : MonoBehaviour 
{
	[SerializeField] private Text NameScoreSummary;
	[SerializeField] private Text NewHighscoreSummary;
	[SerializeField] private Text NewAchievementsSummary;
	[SerializeField] private Button RepeatButton;
	[SerializeField] private Button DontRepeatButton;
	[SerializeField] private GameObject SummaryBackground;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

	[Inject]
	private PlayerProfileController _playerProfileController;

	private void Start()
	{
		NameScoreSummary.text = "";
		NewHighscoreSummary.text = "";
		NewAchievementsSummary.text = "";
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

		NameScoreSummary.text = _currentPlayerData.CurrentProfile.PlayerName + ", your score is " + _currentPlayerData.CurrentScore;

		if (_currentPlayerData.CurrentScore> _currentPlayerData.CurrentProfile.HighScore)
		{
			NewHighscoreSummary.text = "New highscore! You did well!";

			if (_currentPlayerData.AchievementIsUnlocked)							// służy wyłącznie wyświetleniu info o odblokowanym achievemencie, aktualizacja modelu nastąpiła w GUIGamePlayView
			{
				NewAchievementsSummary.text = "New achievement(s) unlocked! Congrats!";
			}

			UpdateModel(_currentPlayerData.CurrentScore);
		}
	}

	public void SetSummaryScreen(bool state)                           // WIDOK SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		SummaryBackground.SetActive(state);
		RepeatButton.gameObject.SetActive(state);
		DontRepeatButton.gameObject.SetActive(state);
	}

	public void UpdateModel(int score)
	{
		_currentPlayerData.CurrentProfile.HighScore = score;

		PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID] = _currentPlayerData.CurrentProfile;

		_playerProfileController.SaveProfile(PlayersProfiles.Instance);               // zapisz wyniki przed powrotem do sceny MENU
	}
}
