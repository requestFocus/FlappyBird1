using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
	[SerializeField] private Text NameScoreSummary;
	[SerializeField] private Text NewHighscoreSummary;
	[SerializeField] private Text NameScoreGamePlay;
	[SerializeField] private Text ScoreGamePlay;
	[SerializeField] private Text HighScoreGamePlay;
	[SerializeField] private Text AchievementUnlockedGamePlay;
	[SerializeField] private Button RepeatButton;
	[SerializeField] private Button DontRepeat;
	[SerializeField] private Canvas Canvas;
	[SerializeField] private GameObject SummaryBackground;
	[SerializeField] private GameManager GameManager;

	private PlayerProfileController _playerProfileController = new PlayerProfileController();

	private void Start()
	{
		NameScoreSummary.text = "";
		NewHighscoreSummary.text = "";
		AchievementUnlockedGamePlay.text = "";
		SetSummaryScreen(false);
	}

	private void Update()
	{
		DisplayCanvasOnGamePlay();
	}

	private void OnEnable()                                             // SERWIS WIDOKU SUMMARY
	{
		RepeatButton.onClick.AddListener(RepeatGame);
		DontRepeat.onClick.AddListener(BackToMenu);
	}

	public void RepeatGame()                                            // SERWIS WIDOKU SUMMARY
	{
		SceneManager.LoadScene("Game");
		BreakPause();
	}

	public void BackToMenu()                                            // SERWIS WIDOKU SUMMARY				
	{
		Main.BackFromGamePlay = true;
		SceneManager.LoadScene("Menu");
		BreakPause();
	}

	private void BreakPause()											// SERWIS WIDOKU SUMMARY
	{
		Time.timeScale = 1;
		SummaryBackground.SetActive(false);
	}

	public void DisplayCanvasOnGamePlay()								// WIDOK GAMEPLAY
	{
		if (Time.timeScale == 1)										// jeśli gra trwa
		{
			NameScoreGamePlay.text = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName;
			ScoreGamePlay.text = "score: " + GameManager.CurrentScore;
			HighScoreGamePlay.text = "highscore: " + PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore;
		}
		else if (Time.timeScale == 0)									// jeśli gra się zakończyła schowaj elementy UI gameplayu
		{
			NameScoreGamePlay.text = "";
			ScoreGamePlay.text = "";
			HighScoreGamePlay.text = "";
		}
	}

	public void DisplayCanvasOnSummary()                                // WIDOK SUMMARY
	{
		Time.timeScale = 0;
		SetSummaryScreen(true);

		NameScoreSummary.text = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName + ", your score is " + GameManager.CurrentScore;

		if (CheckHighscoreTable())
		{
			NewHighscoreSummary.text = "New highscore! You did well!";
		}

		_playerProfileController.SaveProfile(PlayersProfiles.Instance);               // zapisz wyniki przed powrotem do sceny MENU		// KONTROLER===== jedyne miejsce, które ma wpływ na model
	}

	private void SetSummaryScreen(bool state)                           // SERWIS(?) WIDOKU SUMMARY, aktywuje i wyswietla tło i przyciski powrót/powtórz
	{
		SummaryBackground.SetActive(state);
		RepeatButton.gameObject.SetActive(state);
		DontRepeat.gameObject.SetActive(state);
	}

	private bool CheckHighscoreTable()                                  // SERWIS WIDOKU SUMMARY, informuje czy player ma nowy highscore
	{
		if (GameManager.CurrentScore > PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore)
		{
			PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore = GameManager.CurrentScore;
			return true;
		}

		return false;
	}

	public IEnumerator AchievementUnlockedNotification()                // SERWIS WIDOKU GAMEPLAY, wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
	}
}
