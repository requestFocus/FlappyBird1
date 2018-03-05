using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsView : MonoBehaviour {

	[SerializeField] private Texture LogoButton;
	public Texture CreditsButtonInactive;

	private ResizeViewService ResizeViewService;
	private DrawElementViewService DrawElementViewService;
	private SetGUIStyleViewService SetGUIStyleViewService;

	private Rect _logoRect;

	void Start()
	{
		ResizeViewService = new ResizeViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
		SetGUIStyleViewService.SetGUIStyle();
	}



	public void DrawCreditsMenu()               // obsluga CREDITS
	{
		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">PROGRAMMING / DESIGN\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">MACIEJ NIEŚCIORUK</color>\n\n" +
								"GRAPHICS\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">INTERNET</color>\n\n" +
								"SPECIAL THANKS TO\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">MICHAŁ PODYMA</color></color>";
		GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

		DrawElementViewService.DrawCommonViewELements(LogoButton, CreditsButtonInactive);
	}
}
