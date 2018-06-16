using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView : View<ProfileModel, Controller<ProfileModel>>
{
	[SerializeField] private Button LogoButton;
	[SerializeField] private Text ProfileViewText;
	[SerializeField] private Image ProfileViewButtonInactive;

	[SerializeField] private AchievementSingleEntryView AchievementSingleEntryView;
	AchievementSingleEntryView achievementSingleEntryViewInstance;

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

		achievementSingleEntryViewInstance = Instantiate(AchievementSingleEntryView);
		achievementSingleEntryViewInstance.transform.SetParent(gameObject.transform);
		achievementSingleEntryViewInstance.ListAchievements(Model.CurrentProfile, xPosition, yPosition);
	}

	public void ClickLogo()             //=========================================================================pomyslec o wyrzuceniu tego do jakiegos serwisu
	{
		OnProfileViewSetDel(MenuScreensService.MenuScreens.MainMenu);
		Destroy(gameObject);
	}
}
