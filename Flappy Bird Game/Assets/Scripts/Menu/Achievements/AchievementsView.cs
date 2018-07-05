using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AchievementsView : MonoBehaviour
{
	[SerializeField] private Button _logoButton;
	[SerializeField] private Image _achievementsButtonInactive;

	[Inject]
	private DiContainer _container;

	[Inject]
	private DelegateService _delegateService;

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private MultiplePlayerStatsView _multiplePlayerStatsView;

	[SerializeField] private Text _playerNameLabel;
	[SerializeField] private Text _highscoreLabel;
	[SerializeField] private Text _achievementsLabel;

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

		InitiateMultipleStatsView();
	}

	private void InitiateMultipleStatsView()
	{
		MultiplePlayerStatsView multiplePlayerStatsViewInstance = Instantiate(_multiplePlayerStatsView);
		_container.Inject(multiplePlayerStatsViewInstance);
		multiplePlayerStatsViewInstance.transform.SetParent(gameObject.transform);

		multiplePlayerStatsViewInstance.CreateEmptyContainers(_projectData);
	}
}
