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
		ActOnClick(_newGameButton, MenuScreensService.MenuScreens.NewGame);

		ActOnClick(_howToPlayButton, MenuScreensService.MenuScreens.HowtoPlay);

		ActOnClick(_creditsButton, MenuScreensService.MenuScreens.Credits);

		ActOnClick(_achievementsButton, MenuScreensService.MenuScreens.Achievements);

		ActOnClick(_profileButton, MenuScreensService.MenuScreens.Profile);

		ActOnClick(_logoutButton, MenuScreensService.MenuScreens.Login);
	}

    private void Update()                                               // poki co tylko tutaj, pozniej w summarySuccess i summaryFailure
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void ActOnClick(Button button, MenuScreensService.MenuScreens state)
	{
		button.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(state);
		});
	}
}


