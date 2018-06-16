using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsView : View<CreditsModel, Controller<CreditsModel>>
{
	[SerializeField] private Button LogoButton;
	[SerializeField] private Text CreditsViewText;
	[SerializeField] private Image CreditsViewButtonInactive;

	public delegate void OnCreditsViewSet(MenuScreensService.MenuScreens state);					//======= wyciagnac na zewnatrz?
	public OnCreditsViewSet OnCreditsViewSetDel;

	public void Start()
	{
		LogoButton.onClick.AddListener(ClickLogo);
		CreditsViewText.text = "PROGRAMMING / DESIGN\nMACIEJ NIEŚCIORUK\n\nGRAPHICS\nINTERNET\n\nSPECIAL THANKS TO\nMICHAŁ PODYMA";
	}

	public void ClickLogo()             //=========================================================================pomyslec o wyrzuceniu tego do jakiegos serwisu
	{
		OnCreditsViewSetDel(MenuScreensService.MenuScreens.MainMenu);
		Destroy(gameObject);
	}


	//public void DrawCreditsMenu()               // obsluga CREDITS
	//{
	//	_setGUIStyleViewService.LabelContent.text = "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">" +
	//										"PROGRAMMING / DESIGN\n<color=#" + _setGUIStyleViewService.LightGreyFont + ">MACIEJ NIEŚCIORUK</color>\n\n" +
	//										"GRAPHICS\n<color=#" + _setGUIStyleViewService.LightGreyFont + ">INTERNET</color>\n\n" +
	//										"SPECIAL THANKS TO\n<color=#" + _setGUIStyleViewService.LightGreyFont + ">MICHAŁ PODYMA</color></color>";
	//	GUI.Label(_resizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), _setGUIStyleViewService.LabelContent, _setGUIStyleViewService.LabelStyle);

	//	_drawElementViewService.DrawCommonViewELements(LogoButton, CreditsButtonInactive);
	//}
}
