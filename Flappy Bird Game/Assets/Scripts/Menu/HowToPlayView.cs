using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayView : MonoBehaviour {

	[SerializeField] private Texture LogoButton;
	public Texture HowtoPlayButtonInactive;
	public ResizeControllerViewService ResizeControllerViewService;
	public DrawElementViewService DrawElementViewService;
	public SetGUIStyleViewService SetGUIStyleViewService;

	private Rect _logoRect;
	//public Vector2 MyMousePosition;



	public void Start()
	{
		ResizeControllerViewService = new ResizeControllerViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
	}



	public void DrawHowtoPlayMenu()
	{
		//MyMousePosition = Event.current.mousePosition;
		SetGUIStyleViewService.SetGUIStyle();

		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
		DrawElementViewService.DrawElement(350, 550, 100, 30, HowtoPlayButtonInactive, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">USE ARROWS ( <color=#" + SetGUIStyleViewService.LightGreyFont + ">↑</color> / <color=#" + SetGUIStyleViewService.LightGreyFont + ">↓</color> ) TO CONTROL THE BEE\n\n" +
						"BEAT HIGHSCORES, UNLOCK ACHIEVEMENTS \nAND HAVE FUN!\n\nWATCH OUT! GRAVITY KILLS!\n\nGOOD LUCK!</color>";
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeControllerViewService.ClickedWithin(_logoRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
				SetGUIStyleViewService.LabelContent.text = "";
			}
		}
	}
}
