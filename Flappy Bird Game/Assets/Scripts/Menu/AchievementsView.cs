using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsView : MonoBehaviour {

	[SerializeField] private Texture LogoButton;
	public Texture AchievementsButtonInactive;
	public Texture NextAchievementPage;
	public Texture PreviousAchievementPage;

	public AchievementSingleEntryView AchievementSingleEntryView;
	public ResizeControllerViewService ResizeControllerViewService;
	public DrawElementViewService DrawElementViewService;
	public SetGUIStyleViewService SetGUIStyleViewService;
	public LoginViewService LoginViewService;

	//public Texture Complete10Active;
	//public Texture Complete10Inactive;
	//public Texture Complete25Active;
	//public Texture Complete25Inactive;
	//public Texture Complete50Active;
	//public Texture Complete50Inactive;

	private Rect _logoRect;
	private Rect _nextAchievementPage;
	private Rect _previousAchievementPage;
	private float _listAchievementsFrom;
	private float _listAchievementsTo;
	private float _scope;

	//public Vector2 MyMousePosition;

	void Start ()
	{
		_scope = 5;
		_listAchievementsFrom = 0;
		_listAchievementsTo = _scope;

		ResizeControllerViewService = new ResizeControllerViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
	}
	
	void Update ()
	{
		if (MenuScreensService.MenuStates.Equals(MenuScreensService.MenuScreens.Achievements))
		{
			CalculateStartAndEndPositionsForAchievements();
		}
	}

	public void DrawAchievementsMenu()
	{
		//MyMousePosition = Event.current.mousePosition;
		SetGUIStyleViewService.SetGUIStyle();

		_logoRect = DrawElementViewService.DrawElement(315, 20, 170, 170, LogoButton, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.top);
		DrawElementViewService.DrawElement(350, 550, 100, 30, AchievementsButtonInactive, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		if (LoginViewService.ThereIsAList)                                                                            // jesli istnieje lista w pamieci
		{
			ListNameScoreAchievements(_listAchievementsFrom, _listAchievementsTo);
			//ListAchievementsWithMasking();
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">No results yet.</color>", SetGUIStyleViewService.LabelStyle);
		}

		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeControllerViewService.ClickedWithin(_logoRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
				SetGUIStyleViewService.LabelContent.text = "";

				_listAchievementsFrom = 0;
				_listAchievementsTo = _scope;
			}
		}

		//CalculateStartAndEndPositionsForAchievements();
	}


	private void ListNameScoreAchievements(float listFrom, float listTo)
	{
		// LABELS
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(200, 240, 150, 30), ResizeControllerViewService.Horizontal.left, ResizeControllerViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">NAME</color>", SetGUIStyleViewService.LabelStyle);
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, 240, 150, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">HIGHSCORE</color>", SetGUIStyleViewService.LabelStyle);
		GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(430, 240, 150, 30), ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">ACHIEVEMENTS</color>", SetGUIStyleViewService.LabelStyle);

		// BUTTONS
		_previousAchievementPage = DrawElementViewService.DrawElement(376, 430, 16, 18, PreviousAchievementPage, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);
		_nextAchievementPage = DrawElementViewService.DrawElement(410, 430, 16, 18, NextAchievementPage, ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.bottom);

		int yPosition = 270;
		int xPosition = 465;

		for (int i = (int)listFrom; i < PlayersProfiles.Instance.ListOfProfiles.Count && i < (int)listTo; i++)                              // wypisze liste userów od A do B
		{
			// PLAYERNAME
			GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(200, yPosition, 150, 30), ResizeControllerViewService.Horizontal.left, ResizeControllerViewService.Vertical.center),
						"<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].PlayerName + "</color>", SetGUIStyleViewService.LabelStyle);

			// HIGHSCORE
			GUI.Label(ResizeControllerViewService.ResizeGUI(new Rect(300, yPosition, 150, 30), ResizeControllerViewService.Horizontal.center, ResizeControllerViewService.Vertical.center),
						"<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].HighScore + "</color>", SetGUIStyleViewService.LabelStyle);

			// ACHIEVEMENTS
			AchievementSingleEntryView.ListAchievements(i, PlayersProfiles.Instance.ListOfProfiles[i], xPosition, yPosition);                      // wypisuje achievementy dla aktualnie parsowanego w pętli obiektu

			yPosition += 30;
			xPosition = 465;
		}

		MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;
	}



	//private void ListAchievements(int currentProfile, PlayerProfile playerProfile, int xPosition, int yPosition)
	//{
	//	if (playerProfile.Complete10)
	//	{
	//		DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);         // IKONY ACHIEVEMENTOW MAJA WYMIARY 96x110
	//	}
	//	else
	//	{
	//		DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
	//	}

	//	xPosition += 30;
	//	if (playerProfile.Complete25)
	//	{
	//		DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
	//	}
	//	else
	//	{
	//		DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
	//	}

	//	xPosition += 30;
	//	if (playerProfile.Complete50)
	//	{
	//		DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
	//	}
	//	else
	//	{
	//		DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
	//	}
	//}




	private void CalculateStartAndEndPositionsForAchievements()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeControllerViewService.ClickedWithinForUpdate(_previousAchievementPage) && _listAchievementsFrom > 0)
			{
				_listAchievementsFrom -= _scope;
				_listAchievementsTo -= _scope;
				//Debug.Log("prev");
			}

			if (ResizeControllerViewService.ClickedWithinForUpdate(_nextAchievementPage) && _listAchievementsTo < PlayersProfiles.Instance.ListOfProfiles.Count)
			{
				_listAchievementsFrom += _scope;
				_listAchievementsTo += _scope;
				//Debug.Log("next");
			}
		}
	}
}
