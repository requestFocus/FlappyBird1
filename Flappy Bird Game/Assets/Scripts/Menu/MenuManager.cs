using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuManager : MonoBehaviour {

	public static bool BackFromGamePlay;

	[Inject]
	private MenuFactory _menuFactory;

	[Inject]
	private MenuScreensService _menuScreensService;

	[Inject]
	private DelegateService _delegateService;

	private void Awake()
	{
		//PlayerPrefs.DeleteAll();                                                // CZYSZCZENIE PLAYERPREFS

		if (!BackFromGamePlay)                                                  // jeśli uruchomiono aplikacje, ale nie rozegrano gry
		{
			SetState(MenuScreensService.MenuScreens.Login);
		}
		else                                                                    // jeśli nastąpil powrot z gry i przeładowano scene z GAME na MENU
		{
			SetState(MenuScreensService.MenuScreens.MainMenu);
		}
	}

	public void SwitchView()
	{ 
		switch (_menuScreensService.MenuStates)
		{
			case MenuScreensService.MenuScreens.Login:
				LoginView loginView = _menuFactory.CreateConcreteLoginView();
				loginView.transform.SetParent(gameObject.transform);
				loginView.OnLoginViewSetDel = SetState;								// nie korzysta z DelegateService, jego delegat jest nieco inny od pozostałych
				break;

			case MenuScreensService.MenuScreens.MainMenu:
				MainLobbyView mainLobbyView = _menuFactory.CreateConcreteMainLobbyView();
				mainLobbyView.transform.SetParent(gameObject.transform);
				_delegateService.OnStateSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.HowtoPlay:
				HowToPlayView howToPlay = _menuFactory.CreateConcreteHowToPlayView();
				howToPlay.transform.SetParent(gameObject.transform);
				_delegateService.OnStateSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.Credits:
				CreditsView creditsView = _menuFactory.CreateConcreteCreditsView();
				creditsView.transform.SetParent(gameObject.transform);
				_delegateService.OnStateSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.Achievements:
				AchievementsView achievementsView = _menuFactory.CreateConcreteAchievementsView();
				achievementsView.transform.SetParent(gameObject.transform);
				_delegateService.OnStateSetDel = SetState;
				break;

			case MenuScreensService.MenuScreens.Profile:
				ProfileView profileView = _menuFactory.CreateConcreteProfileView();
				profileView.transform.SetParent(gameObject.transform);
				_delegateService.OnStateSetDel = SetState; break;

			case MenuScreensService.MenuScreens.NewGame:
				SceneManager.LoadScene("Game");
				break;
		}
	}

	public void SetState(MenuScreensService.MenuScreens state)
	{
		_menuScreensService.MenuStates = state;
		SwitchView();
	}
}

