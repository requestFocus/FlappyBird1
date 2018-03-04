using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginView : MonoBehaviour {

	[SerializeField] private Texture LogoButton;
	public ResizeControllerViewService ResizeControllerViewService;
	public DrawElementViewService DrawElementViewService;
	public SetGUIStyleViewService SetGUIStyleViewService;
	public LoginViewService LoginViewService;

	private Rect _logoRect;
	public static string JustPlayerName;
	public Vector2 MyMousePosition;



	public void Start()
	{
		JustPlayerName = "";
		ResizeControllerViewService = new ResizeControllerViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
		LoginViewService = new LoginViewService();
	}



	public void DrawLoginMenu()
	{
		MyMousePosition = Event.current.mousePosition;
		SetGUIStyleViewService.SetGUIStyle();

		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
		JustPlayerName = GUI.TextField(ResizeControllerViewService.ResizeGUI(new Rect(350, 270, 100, 25), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), JustPlayerName, 10);

		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">Enter your name\nand click on the logo</color>";
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(350, 310, 100, 25), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle); // ENTER YOUR NAME label

		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeControllerViewService.ClickedWithin(_logoRect))
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
