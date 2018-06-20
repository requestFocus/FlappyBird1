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

	private void OnEnable()                                            
	{
		_repeatButton.onClick.AddListener(RepeatGame);
		_dontRepeatButton.onClick.AddListener(BackToMenu);
	}

	public void RepeatGame()                                           
	{
		CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		SceneManager.LoadScene("Game");
	}

	public void BackToMenu()                                           		
	{
		MenuManager.BackFromGamePlay = true;
		SceneManager.LoadScene("Menu");
	}

	public void DisplayGUISummaryView()                           
	{
		SetSummaryScreen(true);

		_nameScoreSummary.text = _projectData.EntireList[_projectData.CurrentID].PlayerName + ", your score is " + _currentPlayerData.CurrentScore;

		_newHighscoreSummary.text = "New highscore! You did well!";

		if (_currentPlayerData.AchievementIsUnlocked)							// służy wyświetleniu info o odblokowanym achievemencie
			_newAchievementsSummary.text = "New achievement(s) unlocked! Congrats!";

		UpdateModel(_currentPlayerData.CurrentScore);
	}

	public void SetSummaryScreen(bool state)                           
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
