using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CreditsView : View<CreditsModel, Controller<CreditsModel>>
{
	[SerializeField] private Button _logoButton;
	[SerializeField] private Text _creditsViewText;
	[SerializeField] private Image _creditsViewButtonInactive;

	[Inject]
	private ProjectData _projectData;

	[Inject]
	private DelegateService _delegateService;

	public void Start()
	{
		//Debug.Log("CreditsView Tekst oryginalny: " + _projectData.Tekst);

		_logoButton.onClick.AddListener(delegate
		{
			Destroy(gameObject);
			_delegateService.ClickLogo(MenuScreensService.MenuScreens.MainMenu);
		});

		_creditsViewText.text = "PROGRAMMING / DESIGN\nMACIEJ NIEŚCIORUK\n\nGRAPHICS\nINTERNET\n\nSPECIAL THANKS TO\nMICHAŁ PODYMA";
	}
}
