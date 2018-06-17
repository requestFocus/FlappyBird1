using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayView : View<HowToPlayModel, Controller<HowToPlayModel>>
{
	[SerializeField] private Button LogoButton;
	[SerializeField] private Text HowToPlayText;
	[SerializeField] private Image HowToPlayButtonInactive;

	public delegate void OnHowToPlayViewSet(MenuScreensService.MenuScreens state);
	public OnHowToPlayViewSet OnHowToPlayViewSetDel;

	public void Start()
	{
		LogoButton.onClick.AddListener(ClickLogo);
		HowToPlayText.text = "USE ARROWS ↑ / ↓ TO CONTROL THE BEE\n\nBEAT HIGHSCORES, UNLOCK ACHIEVEMENTS\nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!";
	}

	public void ClickLogo()				//=========================================================================pomyslec o wyrzuceniu tego do jakiegos serwisu
	{
		OnHowToPlayViewSetDel(MenuScreensService.MenuScreens.MainMenu);
		Destroy(gameObject);
	}

	//public void DrawHowtoPlayMenu()
	//{
	//	SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">USE ARROWS ( <color=#" + SetGUIStyleViewService.LightGreyFont + ">↑</color> / <color=#" + SetGUIStyleViewService.LightGreyFont + ">↓</color> ) TO CONTROL THE BEE\n\n" +
	//					"BEAT HIGHSCORES, UNLOCK ACHIEVEMENTS \nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!</color>";
	//	GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

	//	DrawElementViewService.DrawCommonViewELements(LogoButton, HowtoPlayButtonInactive);
	//}
}
