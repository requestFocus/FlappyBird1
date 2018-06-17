using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProfileView : View<ProfileModel, Controller<ProfileModel>>
{
	[SerializeField] private Button LogoButton;
	[SerializeField] private Text ProfileViewText;
	[SerializeField] private Image ProfileViewButtonInactive;

	[Inject]
	private AchievementSingleEntryView _achievementSingleEntryView;

	[Inject]
	private DiContainer _container;

	public delegate void OnProfileViewSet(MenuScreensService.MenuScreens state);                  //======= wyciagnac na zewnatrz?
	public OnProfileViewSet OnProfileViewSetDel;

	private const int xPosition = 390;
	private const int yPosition = 228;

	private void Awake()
	{
		Model = new ProfileModel()
		{
			CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID]
		};
	}

	private void Start ()
	{
		LogoButton.onClick.AddListener(ClickLogo);
		ProfileViewText.text = "NAME\n" + Model.CurrentProfile.PlayerName + "\n\nHIGHSCORE\n" + Model.CurrentProfile.HighScore + "\n\nACHIEVEMENTS";

		AchievementSingleEntryView achievementSingleEntryViewInstance = Instantiate(_achievementSingleEntryView);
		_container.Inject(achievementSingleEntryViewInstance);
		achievementSingleEntryViewInstance.transform.SetParent(gameObject.transform);
		achievementSingleEntryViewInstance.ListAchievements(Model.CurrentProfile, xPosition, yPosition);
	}

	public void ClickLogo()             //=========================================================================pomyslec o wyrzuceniu tego do jakiegos serwisu
	{
		OnProfileViewSetDel(MenuScreensService.MenuScreens.MainMenu);
		Destroy(gameObject);
	}
}
