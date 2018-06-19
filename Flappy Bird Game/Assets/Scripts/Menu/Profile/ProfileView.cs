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
	private ProjectData _projectData;

	[Inject]
	private AchievementSingleEntryView _achievementSingleEntryView;

	[Inject]
	private DelegateService _delegateService;

	[Inject]
	private DiContainer _container;

	private const int xPosition = 390;
	private const int yPosition = 228;

	private void Start()
	{
		_logoButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		_profileViewText.text = "NAME\n" + _projectData.EntireList[_projectData.CurrentID].PlayerName + "\n\nHIGHSCORE\n" + _projectData.EntireList[_projectData.CurrentID].HighScore + "\n\nACHIEVEMENTS";

		AchievementSingleEntryView achievementSingleEntryViewInstance = Instantiate(_achievementSingleEntryView);
		_container.Inject(achievementSingleEntryViewInstance);
		achievementSingleEntryViewInstance.transform.SetParent(gameObject.transform);
		achievementSingleEntryViewInstance.ListAchievements(_projectData.EntireList[_projectData.CurrentID], xPosition, yPosition);
	}
}
