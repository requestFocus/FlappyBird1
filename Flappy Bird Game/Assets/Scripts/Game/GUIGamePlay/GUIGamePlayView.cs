using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIGamePlayView : View<GUIGamePlayModel, GUIGamePlayController>								// GUIGamePlayView jest głównym widokiem zawierającym widok player PLUS obstacle
{
	[SerializeField] private Text NameScoreGamePlay;
	[SerializeField] private Text ScoreGamePlay;
	[SerializeField] private Text HighScoreGamePlay;
	[SerializeField] private Text AchievementUnlockedGamePlay;

	[SerializeField] private ParticleSystem AchievementParticles;
	[SerializeField] private LevelService LevelService;                 // do wyswietlania aktualnego score'a

	private void Start()
	{
		LevelService.CurrentScore = 0;
		Time.timeScale = 1;
		AchievementUnlockedGamePlay.text = "";

		//Debug.Log(nameof(Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10));	//============================ 4.0 vs 6.0
	}

	/*
	 * tutaj mam dostęp do Modelu i Kontrolera, które są mi potrzebne do weryfikowania i przyznawania achievementów
	 * w PlayerView mam dostęp do OnTriggerEnter2D, gdzie naliczane są punkty lub kończona gra
	 */

	private void Update()
	{
		DisplayGUIGamePlayView();

		if (Controller.VerifyIfAchievementUnlocked(Model, LevelService.CurrentScore))                             // jeśli TRUE to achievement unlocked, a wtedy ParticleSystem.Play()
		{																				//========================================= czy mogę wysyłać Model do Kontrolera bezpośrednio z Widoku? podpięcie Modelu pod kontroler sprawi, że zaktualizowany zostanie "inny" Model, nie ten AKTUALNY						
			ParticleSystem AchievementParticlesInstance = Instantiate(AchievementParticles);
			AchievementParticlesInstance.Play();

			StartCoroutine(AchievementUnlockedNotification());
		}
	}


	public void DisplayGUIGamePlayView()                                // WIDOK GAMEPLAY
	{
		NameScoreGamePlay.text = Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].PlayerName;
		ScoreGamePlay.text = "score: " + LevelService.CurrentScore;
		HighScoreGamePlay.text = "highscore: " + Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].HighScore;
	}



	public IEnumerator AchievementUnlockedNotification()                // WIDOK GAMEPLAY, wyswietla info o odblokowaniu achievementu
	{
		AchievementUnlockedGamePlay.text = "New achievement!";
		yield return new WaitForSeconds(2);
		AchievementUnlockedGamePlay.text = "";
	}
}
