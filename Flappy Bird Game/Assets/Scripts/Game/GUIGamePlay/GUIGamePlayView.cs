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

	private bool _achievementIsUnlocked;

	private void Start()
	{
		LevelService.CurrentScore = 0;
		Time.timeScale = 1;
		AchievementUnlockedGamePlay.text = "";
	}


	private void Update()
	{
		DisplayGUIGamePlayView();

		if (AchievementToUnlock(LevelService.CurrentScore))                             // jeśli TRUE to achievement unlocked, a wtedy ParticleSystem.Play()
		{
			ParticleSystem AchievementParticlesInstance = Instantiate(AchievementParticles);
			AchievementParticlesInstance.Play();

			StartCoroutine(AchievementUnlockedNotification());

			_achievementIsUnlocked = false;
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



	//public bool AchievementToUnlock()                                           // weryfikuje i przyznaje achievementy, musi miec dane z modelu
	//{
	//	if (LevelService.CurrentScore == 2)
	//	{
	//		if (!Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10)                                       // nie ma jeszcze achievementu
	//		{
	//			Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete10 = true; //===========!
	//			return true;
	//		}
	//	}
	//	if (LevelService.CurrentScore == 25)
	//	{
	//		if (!Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25)                                        // nie ma jeszcze achievementu
	//		{
	//			Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete25 = true; //===========!
	//			return true;
	//		}
	//	}
	//	if (LevelService.CurrentScore == 50)
	//	{
	//		if (!Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50)                                        // nie ma jeszcze achievementu
	//		{
	//			Model.PlayersProfilesLoadedToModel.ListOfProfiles[Model.PlayersProfilesLoadedToModel.CurrentProfile].Complete50 = true; //===========!
	//			return true;
	//		}
	//	}
	//	return false;                                                                                    // brak achievementu do odblokowania, już posiada wszystko, co się należy
	//}

	public bool AchievementToUnlock(int currentScore)                                           // weryfikuje i przyznaje achievementy, musi miec dane z modelu
	{
		_achievementIsUnlocked = Controller.UnlockAchievement(Model, currentScore);
		return _achievementIsUnlocked;
	}
}
