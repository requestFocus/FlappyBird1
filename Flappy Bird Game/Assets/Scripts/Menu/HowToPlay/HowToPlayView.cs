using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HowToPlayView : View<HowToPlayModel, Controller<HowToPlayModel>>
{
	[SerializeField] private Button LogoButton;
	[SerializeField] private Text HowToPlayText;
	[SerializeField] private Image HowToPlayButtonInactive;

	[Inject]
	private DelegateService _delegateService;

	public void Start()
	{
		LogoButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		HowToPlayText.text = "USE ARROWS ↑ / ↓ TO CONTROL THE BEE\n\nBEAT HIGHSCORES, UNLOCK ACHIEVEMENTS\nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!";
	}
}
