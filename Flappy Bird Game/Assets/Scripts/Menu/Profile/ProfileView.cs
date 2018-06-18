using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProfileView : View<ProfileModel, Controller<ProfileModel>>
{
	[SerializeField] private Button _logoButton;
	[SerializeField] private Text _profileViewText;
	[SerializeField] private Image _profileViewButtonInactive;

	[Inject]
	private AchievementSingleEntryView _achievementSingleEntryView;

	[Inject]
	private DelegateService _delegateService;

	[Inject]
	private DiContainer _container;

	private const int xPosition = 390;
	private const int yPosition = 228;

	private void Awake()
	{
		Model = new ProfileModel()
		{
			CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID]
		};
	}

	private void Start()
	{
		_logoButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		_profileViewText.text = "NAME\n" + Model.CurrentProfile.PlayerName + "\n\nHIGHSCORE\n" + Model.CurrentProfile.HighScore + "\n\nACHIEVEMENTS";

		AchievementSingleEntryView achievementSingleEntryViewInstance = Instantiate(_achievementSingleEntryView);
		_container.Inject(achievementSingleEntryViewInstance);
		achievementSingleEntryViewInstance.transform.SetParent(gameObject.transform);
		achievementSingleEntryViewInstance.ListAchievements(Model.CurrentProfile, xPosition, yPosition);
	}
}
