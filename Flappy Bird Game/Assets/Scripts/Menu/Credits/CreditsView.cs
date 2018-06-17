using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CreditsView : View<CreditsModel, Controller<CreditsModel>>
{
	[SerializeField] private Button LogoButton;
	[SerializeField] private Text CreditsViewText;
	[SerializeField] private Image CreditsViewButtonInactive;

	[Inject]
	private DelegateService _delegateService;

	public void Start()
	{
		LogoButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		CreditsViewText.text = "PROGRAMMING / DESIGN\nMACIEJ NIEŚCIORUK\n\nGRAPHICS\nINTERNET\n\nSPECIAL THANKS TO\nMICHAŁ PODYMA";
	}
}
