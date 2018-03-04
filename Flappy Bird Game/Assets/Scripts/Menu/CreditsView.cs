using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsView : MonoBehaviour {

	[SerializeField] private Texture LogoButton;
	public Texture CreditsButtonInactive;

	private ResizeControllerViewService ResizeControllerViewService;
	private DrawElementViewService DrawElementViewService;
	private SetGUIStyleViewService SetGUIStyleViewService;

	private Rect _logoRect;
	//private Vector2 MyMousePosition;



	void Start ()
	{
		ResizeControllerViewService = new ResizeControllerViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
	}



	public void DrawCreditsMenu()               // obsluga CREDITS
	{
		//MyMousePosition = Event.current.mousePosition;
		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
		DrawElementViewService.DrawElement(350, 550, 100, 30, CreditsButtonInactive, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		SetGUIStyleViewService.SetGUIStyle();

		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeControllerViewService.ClickedWithin(_logoRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
				SetGUIStyleViewService.LabelContent.text = "";
			}
		}

		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">PROGRAMMING / DESIGN\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">MACIEJ NIEŚCIORUK</color>\n\n" +
								"GRAPHICS\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">INTERNET</color>\n\n" +
								"SPECIAL THANKS TO\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">MICHAŁ PODYMA</color></color>";
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);
	}
}
