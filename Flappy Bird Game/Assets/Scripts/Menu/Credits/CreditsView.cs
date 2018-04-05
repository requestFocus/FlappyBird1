using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsView : View<CreditsModel, Controller<CreditsModel>> {

	[SerializeField] private Texture LogoButton;
	[SerializeField] private Texture CreditsButtonInactive;

	private ResizeViewService _resizeViewService;
	private DrawElementViewService _drawElementViewService;
	private SetGUIStyleViewService _setGUIStyleViewService;

	private void Start()
	{
		_resizeViewService = new ResizeViewService();
		_drawElementViewService = new DrawElementViewService();
		_setGUIStyleViewService = new SetGUIStyleViewService();
		_setGUIStyleViewService.SetGUIStyle();
	}



	public void DrawCreditsMenu()               // obsluga CREDITS
	{
		_setGUIStyleViewService.LabelContent.text = "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">" +
											"PROGRAMMING / DESIGN\n<color=#" + _setGUIStyleViewService.LightGreyFont + ">MACIEJ NIEŚCIORUK</color>\n\n" +
											"GRAPHICS\n<color=#" + _setGUIStyleViewService.LightGreyFont + ">INTERNET</color>\n\n" +
											"SPECIAL THANKS TO\n<color=#" + _setGUIStyleViewService.LightGreyFont + ">MICHAŁ PODYMA</color></color>";
		GUI.Label(_resizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), _setGUIStyleViewService.LabelContent, _setGUIStyleViewService.LabelStyle);

		_drawElementViewService.DrawCommonViewELements(LogoButton, CreditsButtonInactive);
	}
}
