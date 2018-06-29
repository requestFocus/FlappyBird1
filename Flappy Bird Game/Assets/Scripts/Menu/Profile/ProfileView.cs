using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProfileView : MonoBehaviour
{
	[SerializeField] private Button _logoButton;
	[SerializeField] private Image _profileViewButtonInactive;
	[SerializeField] private Text _playerNameLabel;
	[SerializeField] private Text _highscoreLabel;
	[SerializeField] private Text _achievementsLabel;

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private SinglePlayerStatsView _singlePlayerStatsView;

	[Inject]
	private DelegateService _delegateService;

	[Inject]
	private DiContainer _container;

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

		InitiateProfileStatsView();
	}

	private void InitiateProfileStatsView()
	{
		Vector3 playerNamePos = _playerNameLabel.transform.position;
		Vector3 highscorePos = _highscoreLabel.transform.position;
		Vector3 achievementsPos = _achievementsLabel.transform.position;

		SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);
		_container.Inject(singlePlayerStatsViewInstance);
		singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);

		singlePlayerStatsViewInstance.CreateSinglePlayerStatsView(_projectData.EntireList[_projectData.CurrentID], playerNamePos, highscorePos, achievementsPos);
	}
}
