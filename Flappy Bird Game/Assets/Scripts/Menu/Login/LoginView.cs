﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour {

	//public string JustPlayerName;

	[SerializeField] private Button LogoButton;
	[SerializeField] private InputField NameField;

	public Text EnterYourName;
	private LoginViewService _loginViewService;

	public delegate void OnStateSet(MenuScreensService.MenuScreens state);
	public OnStateSet OnStateSetDel;

	public void Start()
	{
		_loginViewService = new LoginViewService();

		//JustPlayerName = "";
		EnterYourName.text = "Enter your name\nand click on the logo";

		LogoButton.onClick.AddListener(ClickLogo);
	}

	public void ClickLogo()
	{
		if (NameField.text.Length > 0)
		{
			_loginViewService.CheckPlayerPrefs(NameField.text);                         // odpal LoadProfile, sprawdz aktualna liste i przypisz dane do pol obiektu
			OnStateSetDel(MenuScreensService.MenuScreens.MainMenu);
			Destroy(gameObject);
		}
	}

	//public void DrawLoginMenu()                                 // jest innej budowy niż pozostale widoki, dlatego nie korzysta z DrawElementViewService.DrawCommonViewELements(LogoButton);
	//{
	//	//	_logoRect = _drawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.top);
	//	//	JustPlayerName = GUI.TextField(_resizeViewService.ResizeGUI(new Rect(350, 270, 100, 25), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), JustPlayerName, 10);

	//	//	_setGUIStyleViewService.LabelContent.text = "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">Enter your name\nand click on the logo</color>";
	//	//	GUI.Label(_resizeViewService.ResizeGUI(new Rect(350, 310, 100, 25), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), _setGUIStyleViewService.LabelContent, _setGUIStyleViewService.LabelStyle); // ENTER YOUR NAME label

	//	//	if (Input.GetMouseButtonDown(0))
	//	//	{
	//	//		if (_resizeViewService.ClickedWithin(_logoRect))
	//	//		{
	//	//			if (JustPlayerName.Length > 0)
	//	//			{
	//	//				_loginViewService.CheckPlayerPrefs(JustPlayerName);                         // odpal LoadProfile, sprawdz aktualna liste i przypisz dane do pol obiektu
	//	//				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
	//	//			}
	//	//		}
	//	//	}
	//}
}
