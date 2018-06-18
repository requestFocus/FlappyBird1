﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class GUIFailureSummaryView : MonoBehaviour 
{
	[SerializeField] private Text _nameScoreSummary;
	[SerializeField] private Text _noHighscoreSummary;
	[SerializeField] private Button _repeatButton;
	[SerializeField] private Button _dontRepeatButton;
	[SerializeField] private GameObject _summaryBackground;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

	private void Start()
	{
		_nameScoreSummary.text = "";
		_noHighscoreSummary.text = "";
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

	public void DisplayGUISummaryView()                                // WIDOK SUMMARY
	{
		SetSummaryScreen(true);

		_nameScoreSummary.text = _currentPlayerData.CurrentProfile.PlayerName + ", your score is " + _currentPlayerData.CurrentScore;

		_noHighscoreSummary.text = "Better luck next time...";
	}

	public void SetSummaryScreen(bool state)                           // WIDOK SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		_summaryBackground.SetActive(state);
		_repeatButton.gameObject.SetActive(state);
		_dontRepeatButton.gameObject.SetActive(state);
	}
}
