using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFactory : MonoBehaviour
{
	[SerializeField] private LoginView _loginView;
	[SerializeField] private MainLobbyView _mainLobbyView;
	[SerializeField] private HowToPlayView _howToPlayView;
	[SerializeField] private CreditsView _creditsView;
	[SerializeField] private AchievementsView _achievementsView;
	[SerializeField] private ProfileView _profileView;

	public LoginView CreateConcreteLoginView()
	{
		LoginView loginView = Instantiate(_loginView);
		return loginView;
	}

	public MainLobbyView CreateConcreteMainLobbyView()
	{
		MainLobbyView mainLobbyView = Instantiate(_mainLobbyView);
		return mainLobbyView;
	}

	public HowToPlayView CreateConcreteHowToPlayView()
	{
		HowToPlayView howToPlayView = Instantiate(_howToPlayView);
		return howToPlayView;
	}

	public CreditsView CreateConcreteCreditsView()
	{
		CreditsView creditsView = Instantiate(_creditsView);
		return creditsView;
	}

	public AchievementsView CreateConcreteAchievementsView()
	{
		AchievementsView achievementsView = Instantiate(_achievementsView);
		return achievementsView;
	}

	public ProfileView CreateConcreteProfileView()
	{
		ProfileView profileView = Instantiate(_profileView);
		return profileView;
	}
}
