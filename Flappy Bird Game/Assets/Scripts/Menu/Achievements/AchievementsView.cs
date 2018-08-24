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

    [Inject]
    private SoundService _soundService;

	[SerializeField] private Text _playerNameLabel;
	[SerializeField] private Text _highscoreLabel;
	[SerializeField] private Text _achievementsLabel;

	private void Start()
	{
		_logoButton.onClick.AddListener(delegate
		{
            _soundService.PlayOkSound();
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
        //multiplePlayerStatsViewInstance.transform.SetParent(gameObject.transform);                // użyj, jeśli chcesz wyłączyć maske i testować liste achievementów
        multiplePlayerStatsViewInstance.transform.SetParent(GameObject.FindGameObjectWithTag("Mask").transform);

        multiplePlayerStatsViewInstance.CreateEmptyContainers(_projectData);
	}
}
