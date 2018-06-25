using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SinglePlayerStatsView : MonoBehaviour
{
	[Inject]
	private DiContainer _container;

	[Inject]
	private AchievementSingleEntryView _achievementSingleEntryView;

	[SerializeField] private Text _playerName;
	[SerializeField] private Text _highscore;

	public void CreateSinglePlayerStatsView(PlayerProfile playerProfile, Vector3 playerNamePos, Vector3 highscorePos, Vector3 achievementsPos)
	{
		_playerName.text = playerProfile.PlayerName;
		playerNamePos.y -= 20;
		_playerName.transform.position = playerNamePos;

		_highscore.text = playerProfile.HighScore.ToString();
		highscorePos.y -= 20;
		_highscore.transform.position = highscorePos;

		AchievementSingleEntryView achievementSingleEntryViewInstance = Instantiate(_achievementSingleEntryView);
		_container.Inject(achievementSingleEntryViewInstance);
		achievementSingleEntryViewInstance.transform.SetParent(gameObject.transform);
		achievementSingleEntryViewInstance.ListAchievements(playerProfile, achievementsPos);
	}
}
