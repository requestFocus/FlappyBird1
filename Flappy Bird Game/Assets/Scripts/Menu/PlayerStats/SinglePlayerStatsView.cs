using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SinglePlayerStatsView : MonoBehaviour
{
	[Inject]
	private DiContainer _container;

	[Inject]
	private AchievementSingleEntryView _achievementSingleEntryView;

	public Text PlayerName;
	public Text HighScore;

	public AchievementSingleEntryView AchievementSingleEntryViewInstance;

	public void CreateSinglePlayerStatsView(PlayerProfile playerProfile, Vector3 playerNameLabelPos, Vector3 highscoreLabelPos, Vector3 achievementsLabelPos)
	{
		PlayerName.text = playerProfile.PlayerName;
		playerNameLabelPos.y -= 40;
		PlayerName.transform.position = playerNameLabelPos;

		HighScore.text = playerProfile.HighScore.ToString();
		highscoreLabelPos.y -= 40;
		HighScore.transform.position = highscoreLabelPos;

		AchievementSingleEntryViewInstance = Instantiate(_achievementSingleEntryView);
		_container.Inject(AchievementSingleEntryViewInstance);
		AchievementSingleEntryViewInstance.transform.SetParent(gameObject.transform);
		achievementsLabelPos.y -= 32;
		AchievementSingleEntryViewInstance.ListAchievements(playerProfile, achievementsLabelPos);
	}
}

