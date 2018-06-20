using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainLobbyView : MonoBehaviour
{
	[SerializeField] private Image _logoButton;                                            // umożliwia wykorzystanie modyfikatora private z dostępem do zmiennej w ramach inspectora unity
	[SerializeField] private Button _achievementsButton;
	[SerializeField] private Button _creditsButton;
	[SerializeField] private Button _howToPlayButton;
	[SerializeField] private Button _newGameButton;
	[SerializeField] private Button _profileButton;
	[SerializeField] private Button _logoutButton;

	[Inject]
	private DelegateService _delegateService;

	private void Start()
	{
		_newGameButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.NewGame);
		});

		_howToPlayButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.HowtoPlay);
		});

		_creditsButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.Credits);
		});

		_achievementsButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.Achievements);
		});

		_profileButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.Profile);
		});

		_logoutButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.Login);
		});
	}
}
