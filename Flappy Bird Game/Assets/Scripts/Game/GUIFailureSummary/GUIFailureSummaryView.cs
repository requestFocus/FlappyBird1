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
	private ProjectData _projectData;

	[Inject]
	private CurrentPlayerData _currentPlayerData;

    [Inject]
    private SoundService _soundService;

	[Inject]
	private CurrentGameStateService _currentGameStateService;

	private void Start()
	{
		_nameScoreSummary.text = "";
		_noHighscoreSummary.text = "";
		SetSummaryScreen(false);

		DisplayGUISummaryView();
	}

    private void Update()                                               // poki co tylko tutaj, pozniej w summarySuccess i summaryFailure
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnEnable()                                             // WIDOK SUMMARY
	{
		_repeatButton.onClick.AddListener(RepeatGame);
		_dontRepeatButton.onClick.AddListener(BackToMenu);
	}

	public void RepeatGame()                                            // WIDOK SUMMARY
	{
        _soundService.PlayOkSound();
        _currentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.GamePlay;
		SceneManager.LoadScene("Game");
	}

	public void BackToMenu()                                            // WIDOK SUMMARY				
	{
        _soundService.PlayOkSound();
        _projectData.BackFromGamePlay = true;
		SceneManager.LoadScene("Menu");
	}

	public void DisplayGUISummaryView()                                // WIDOK SUMMARY
	{
		SetSummaryScreen(true);

		_nameScoreSummary.text = _projectData.EntireList[_projectData.CurrentID].PlayerName + ", your score is " + _currentPlayerData.CurrentScore + "...";
		_noHighscoreSummary.text = "Better luck next time!";
	}

	public void SetSummaryScreen(bool state)                           // WIDOK SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		_summaryBackground.SetActive(state);
		_repeatButton.gameObject.SetActive(state);
		_dontRepeatButton.gameObject.SetActive(state);
	}
}
