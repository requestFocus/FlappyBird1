using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuManager : MonoBehaviour {

	[Inject]
	private MenuFactory _menuFactory;

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private MenuScreensService _menuScreensService;

	[Inject]
	private DelegateService _delegateService;

	private void Awake()
	{
        //PlayerPrefs.DeleteAll();												// CZYSZCZENIE PLAYERPREFS

        if (!_projectData.BackFromGamePlay)                                     // jeśli uruchomiono aplikacje, ale nie rozegrano jeszcze gry
		{
			SetState(MenuScreensService.MenuScreens.Login);						// apka startuje od LoginView na wejściu sceny MENU
		}
		else                                                                    // jeśli nastąpil powrot z gry i przeładowanie scene z GAME na MENU
		{
			SetState(MenuScreensService.MenuScreens.MainMenu);					// apka startuje z MainLobbyView na wejściu sceny GAME
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

