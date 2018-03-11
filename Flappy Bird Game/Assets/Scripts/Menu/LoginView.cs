using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginView : View {

	[SerializeField] private Texture LogoButton;
	[SerializeField] private ResizeViewService ResizeViewService;
	[SerializeField] private DrawElementViewService DrawElementViewService;
	[SerializeField] private SetGUIStyleViewService SetGUIStyleViewService;
	[SerializeField] private LoginViewService LoginViewService;

	public static string JustPlayerName;

	private Rect _logoRect;

	public void Start()
	{
		JustPlayerName = "";
		ResizeViewService = new ResizeViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
		LoginViewService = new LoginViewService();
		SetGUIStyleViewService.SetGUIStyle();
	}



	public void DrawLoginMenu()                                 // jest innej budowy niż pozostale widoki, dlatego nie korzysta z DrawElementViewService.DrawCommonViewELements(LogoButton);
	{
		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.top);
		JustPlayerName = GUI.TextField(ResizeViewService.ResizeGUI(new Rect(350, 270, 100, 25), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), JustPlayerName, 10);

		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">Enter your name\nand click on the logo</color>";
		GUI.Label(ResizeViewService.ResizeGUI(new Rect(350, 310, 100, 25), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle); // ENTER YOUR NAME label

		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeViewService.ClickedWithin(_logoRect))
			{
				if (JustPlayerName.Length > 0)
				{
					LoginViewService.CheckPlayerPrefs();                         // odpal LoadProfile, sprawdz aktualna liste i przypisz dane do pol obiektu
					MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
					SetGUIStyleViewService.LabelContent.text = "";
				}
			}
		}
	}
}
