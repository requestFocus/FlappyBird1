using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
	[SerializeField]
	private MenuFactory _menuFactory;

	[SerializeField]
	private LoginView _loginView;

	[SerializeField]
	private MainLobbyView _mainLobbyView;

	[SerializeField]
	private HowToPlayView _howToPlayViewPrefab;

	[SerializeField]
	private CreditsView _creditsView;

	[SerializeField]
	private AchievementsView _achievementsView;

	[SerializeField]
	private ProfileView _profileView;

	[SerializeField]
	private AchievementSingleEntryView _achievementSingleEntryView;

	public override void InstallBindings()
	{
		Container.Bind<MenuFactory>().FromComponentInNewPrefab(_menuFactory).AsSingle().NonLazy();

		Container.Bind<MenuScreensService>().FromNew().AsSingle().NonLazy();

		Container.Bind<LoginViewService>().FromNew().AsSingle().NonLazy();

		Container.Bind<ProjectDataService>().FromNew().AsSingle().NonLazy();

		Container.Bind<LoginView>().FromInstance(_loginView).AsSingle().Lazy();
		Container.Bind<MainLobbyView>().FromInstance(_mainLobbyView).AsSingle().Lazy();
		Container.Bind<HowToPlayView>().FromInstance(_howToPlayViewPrefab).AsSingle().Lazy();
		Container.Bind<CreditsView>().FromInstance(_creditsView).AsSingle().Lazy();
		Container.Bind<AchievementsView>().FromInstance(_achievementsView).AsSingle().Lazy();
		Container.Bind<ProfileView>().FromInstance(_profileView).AsSingle().Lazy();

		Container.Bind<AchievementSingleEntryView>().FromInstance(_achievementSingleEntryView).AsSingle().Lazy();

		Container.Bind<DelegateService>().FromNew().AsSingle().NonLazy();
	}
}
