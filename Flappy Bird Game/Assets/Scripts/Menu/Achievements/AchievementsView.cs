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
	private MultiplePlayerStatsView _multiplePlayerStatsView;

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

		Vector3 playerNameLabelPos = _playerNameLabel.transform.position;
		Vector3 highscoreLabelPos = _highscoreLabel.transform.position;
		Vector3 achievementsLabelPos = _achievementsLabel.transform.position;

		MultiplePlayerStatsView multiplePlayerStatsViewInstance = Instantiate(_multiplePlayerStatsView);
		_container.Inject(multiplePlayerStatsViewInstance);
		multiplePlayerStatsViewInstance.transform.SetParent(gameObject.transform);

		multiplePlayerStatsViewInstance.ListPlayerWithStats(_projectData, playerNameLabelPos, highscoreLabelPos, achievementsLabelPos);
	}
}
