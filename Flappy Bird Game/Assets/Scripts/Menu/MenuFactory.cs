using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuFactory : MonoBehaviour
{
	[Inject]
	private LoginView _loginView;

	[Inject]
	private MainLobbyView _mainLobbyView;

	[Inject]
	private ProfileView _profileView;

	[Inject]
	private DiContainer container;

	[Inject]
	private HowToPlayView _howToPlayView;

	[Inject]
	private CreditsView _creditsView;

	[Inject]
	private AchievementsView _achievementsView;

	public LoginView CreateConcreteLoginView()
	{
		LoginView loginView = Instantiate(_loginView);
		container.Inject(loginView);
		return loginView;
	}

	public MainLobbyView CreateConcreteMainLobbyView()
	{
		MainLobbyView mainLobbyView = Instantiate(_mainLobbyView);
		container.Inject(mainLobbyView);
		return mainLobbyView;
	}

	public HowToPlayView CreateConcreteHowToPlayView()
	{
		HowToPlayView howToPlayView = Instantiate(_howToPlayView);
		container.Inject(howToPlayView);
		return howToPlayView;
	}

	public CreditsView CreateConcreteCreditsView()
	{
		CreditsView creditsView = Instantiate(_creditsView);
		container.Inject(creditsView);
		return creditsView;
	}

	public AchievementsView CreateConcreteAchievementsView()
	{
		AchievementsView achievementsView = Instantiate(_achievementsView);
		container.Inject(achievementsView);
		return achievementsView;
	}

	public ProfileView CreateConcreteProfileView()
	{
		ProfileView profileView = Instantiate(_profileView);
		container.Inject(profileView);
		return profileView;
	}
}
