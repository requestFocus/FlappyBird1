using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginView : View {

	public static string JustPlayerName;

	[SerializeField] private Texture LogoButton;

	private ResizeViewService _resizeViewService;
	private DrawElementViewService _drawElementViewService;
	private SetGUIStyleViewService _setGUIStyleViewService;
	private LoginViewService _loginViewService;
	private Rect _logoRect;


	public void Start()
	{
		JustPlayerName = "";
		_resizeViewService = new ResizeViewService();
		_drawElementViewService = new DrawElementViewService();
		_setGUIStyleViewService = new SetGUIStyleViewService();
		_loginViewService = new LoginViewService();
		_setGUIStyleViewService.SetGUIStyle();
	}



	public void DrawLoginMenu()                                 // jest innej budowy niż pozostale widoki, dlatego nie korzysta z DrawElementViewService.DrawCommonViewELements(LogoButton);
	{
		_logoRect = _drawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.top);
		JustPlayerName = GUI.TextField(_resizeViewService.ResizeGUI(new Rect(350, 270, 100, 25), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), JustPlayerName, 10);

		_setGUIStyleViewService.LabelContent.text = "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">Enter your name\nand click on the logo</color>";
		GUI.Label(_resizeViewService.ResizeGUI(new Rect(350, 310, 100, 25), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), _setGUIStyleViewService.LabelContent, _setGUIStyleViewService.LabelStyle); // ENTER YOUR NAME label

		if (Input.GetMouseButtonDown(0))
		{
			if (_resizeViewService.ClickedWithin(_logoRect))
			{
				if (JustPlayerName.Length > 0)
				{
					_loginViewService.CheckPlayerPrefs();                         // odpal LoadProfile, sprawdz aktualna liste i przypisz dane do pol obiektu
					MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
				}
			}
		}
	}
}
