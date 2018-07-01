using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SinglePlayerStatsView : MonoBehaviour
{
	[Inject]
	private DiContainer _container;

	[Inject]
	private AchievementSingleEntryView _achievementSingleEntryView;

	//[SerializeField] private Text _playerName;
	//[SerializeField] private Text _highscore;
	public Text PlayerName;
	public Text HighScore;

	private AchievementSingleEntryView _achievementSingleEntryViewInstance;

	public void CreateSinglePlayerStatsView(PlayerProfile playerProfile, Vector3 playerNameLabelPos, Vector3 highscoreLabelPos, Vector3 achievementsLabelPos)
	{
		PlayerName.text = playerProfile.PlayerName;
		playerNameLabelPos.y -= 20;
		PlayerName.transform.position = playerNameLabelPos;

		HighScore.text = playerProfile.HighScore.ToString();
		highscoreLabelPos.y -= 20;
		HighScore.transform.position = highscoreLabelPos;

		_achievementSingleEntryViewInstance = Instantiate(_achievementSingleEntryView);
		_container.Inject(_achievementSingleEntryViewInstance);
		_achievementSingleEntryViewInstance.transform.SetParent(gameObject.transform);
		achievementsLabelPos.y -= 40;
		_achievementSingleEntryViewInstance.ListAchievements(playerProfile, achievementsLabelPos);
	}
}
