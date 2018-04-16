using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayView : View<HowToPlayModel, Controller<HowToPlayModel>>
{
	[SerializeField] private Texture LogoButton;
	[SerializeField] private Texture HowtoPlayButtonInactive;
	[SerializeField] private ResizeViewService ResizeViewService;
	[SerializeField] private DrawElementViewService DrawElementViewService;
	[SerializeField] private SetGUIStyleViewService SetGUIStyleViewService;

	public void Start()
	{
		ResizeViewService = new ResizeViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
		SetGUIStyleViewService.SetGUIStyle();
	}



	public void DrawHowtoPlayMenu()
	{
		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">USE ARROWS ( <color=#" + SetGUIStyleViewService.LightGreyFont + ">↑</color> / <color=#" + SetGUIStyleViewService.LightGreyFont + ">↓</color> ) TO CONTROL THE BEE\n\n" +
						"BEAT HIGHSCORES, UNLOCK ACHIEVEMENTS \nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!</color>";
		GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

		DrawElementViewService.DrawCommonViewELements(LogoButton, HowtoPlayButtonInactive);
	}
}
