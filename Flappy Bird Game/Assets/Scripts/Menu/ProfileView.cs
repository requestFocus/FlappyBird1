using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileView : MonoBehaviour {

	[SerializeField] private Texture LogoButton;
	public Texture ProfileButtonInactive;

	public AchievementSingleEntryView AchievementSingleEntryView;

	public ResizeControllerViewService ResizeControllerViewService;
	public DrawElementViewService DrawElementViewService;
	public SetGUIStyleViewService SetGUIStyleViewService;

	private Rect _logoRect;
	//public Vector2 MyMousePosition;

	void Start ()
	{
		ResizeControllerViewService = new ResizeControllerViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
	}
	


	public void DrawProfileMenu()               // obsluga NEW GAME
	{
		int yPosition = 370;
		int xPosition = 360;

		//MyMousePosition = Event.current.mousePosition;
		SetGUIStyleViewService.SetGUIStyle();

		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
		DrawElementViewService.DrawElement(350, 550, 100, 30, ProfileButtonInactive, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">NAME\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + LoginViewService.PlayerProfile.PlayerName + "</color>\n\n" +
								"HIGHSCORE\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + LoginViewService.PlayerProfile.HighScore + "</color>\n\n" +
								"ACHIEVEMENTS\n</color>";
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

		AchievementSingleEntryView.ListAchievements(PlayersProfiles.Instance.CurrentProfile, LoginViewService.PlayerProfile, xPosition, yPosition);                     // wypisuje achievementy dla zalogowanego playera

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
