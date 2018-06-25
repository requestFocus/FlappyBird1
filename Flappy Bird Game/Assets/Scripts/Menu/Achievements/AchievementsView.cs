using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AchievementsView : MonoBehaviour
{
	[SerializeField] private Button _logoButton;
	[SerializeField] private Text _playerNameLabel;
	[SerializeField] private Text _highscoreLabel;
	[SerializeField] private Text _achievementsLabel;
	[SerializeField] private Image _achievementsButtonInactive;

	[Inject]
	private DiContainer _container;

	[Inject]
	private DelegateService _delegateService;

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private SinglePlayerStatsView _singlePlayerStatsView;

	private void Start()
	{
		_logoButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		_playerNameLabel.text = "NAME";
		_highscoreLabel.text = "HIGHSCORE";
		_achievementsLabel.text = "ACHIEVEMENTS";

		ListPlayerWithStats();
	}

	private void ListPlayerWithStats()
	{
		Vector3 playerNamePos = _playerNameLabel.transform.position;
		Vector3 highscorePos = _highscoreLabel.transform.position;
		Vector3 achievementsPos = _achievementsLabel.transform.position;

		for (int i = 0; i < _projectData.EntireList.Count; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);

			singlePlayerStatsViewInstance.CreateSinglePlayerStatsView(_projectData.EntireList[i], playerNamePos, highscorePos, achievementsPos);

			playerNamePos.y -= 30;
			highscorePos.y -= 30;
			achievementsPos.y -= 30;
		}
	}
}
