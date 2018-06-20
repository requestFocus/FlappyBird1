using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HowToPlayView : View<HowToPlayModel, Controller<HowToPlayModel>>
{
	[SerializeField] private Button _logoButton;
	[SerializeField] private Text _howToPlayText;
	[SerializeField] private Image _howToPlayButtonInactive;

	[Inject]
	private DelegateService _delegateService;

	[Inject]
	private ProjectData _projectData;

	public void Start()
	{
		Debug.Log("_projectData.CurrentID w HowToPlayView: " + _projectData.CurrentID);
		//_projectData.Tekst = "tekst zmieniony w HowToPlayView";
		//Debug.Log("HowToPlayView Tekst: " + _projectData.Tekst);

		_logoButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		_howToPlayText.text = "USE ARROWS ↑ / ↓ TO CONTROL THE BEE\n\nBEAT HIGHSCORES, UNLOCK ACHIEVEMENTS\nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!";
	}
}
