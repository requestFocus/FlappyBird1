using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsView : MonoBehaviour {

	[SerializeField] private Texture LogoButton;
	public Texture AchievementsButtonInactive;
	public Texture NextAchievementPage;
	public Texture PreviousAchievementPage;

	public AchievementSingleEntryView AchievementSingleEntryView;
	public ResizeViewService ResizeViewService;
	public DrawElementViewService DrawElementViewService;
	public SetGUIStyleViewService SetGUIStyleViewService;
	public LoginViewService LoginViewService;

	private Rect _logoRect;
	private Rect _nextAchievementPage;
	private Rect _previousAchievementPage;
	private float _listAchievementsFrom;
	private float _listAchievementsTo;
	private float _scope;

	void Start ()
	{
		_scope = 5;
		_listAchievementsFrom = 0;
		_listAchievementsTo = _scope;

		ResizeViewService = new ResizeViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
		SetGUIStyleViewService.SetGUIStyle();
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
		if (LoginViewService.ThereIsAList)                                                                            // jesli istnieje lista w pamieci
		{
			ListNameScoreAchievements(_listAchievementsFrom, _listAchievementsTo);
		}
		else                                                                                            // jesli w pamieci nie istnieje lista userów
		{
			GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">No results yet.</color>", SetGUIStyleViewService.LabelStyle);
		}

		DrawElementViewService.DrawCommonViewELements(LogoButton, AchievementsButtonInactive);
	}

	//public void DrawAchievementsMenu()                                              //====================DLACZEGO TO NIE DZIAŁA, CHOCIAZ NIE MA BLEDU?
	//{
	//	DrawElementViewService.DrawCommonViewELements(LogoButton, AchievementsButtonInactive);

	//	if (LoginViewService.ThereIsAList)                                                                            // jesli istnieje lista w pamieci
	//	{
	//		ListNameScoreAchievements(_listAchievementsFrom, _listAchievementsTo);
	//	}
	//	else                                                                                            // jesli w pamieci nie istnieje lista userów
	//	{
	//		GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">No results yet.</color>", SetGUIStyleViewService.LabelStyle);
	//	}
	//}



	private void ListNameScoreAchievements(float listFrom, float listTo)
	{
		// LABELS
		GUI.Label(ResizeViewService.ResizeGUI(new Rect(200, 240, 150, 30), ResizeViewService.Horizontal.left, ResizeViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">NAME</color>", SetGUIStyleViewService.LabelStyle);
		GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, 240, 150, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">HIGHSCORE</color>", SetGUIStyleViewService.LabelStyle);
		GUI.Label(ResizeViewService.ResizeGUI(new Rect(430, 240, 150, 30), ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center), "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">ACHIEVEMENTS</color>", SetGUIStyleViewService.LabelStyle);

		// BUTTONS
		_previousAchievementPage = DrawElementViewService.DrawElement(376, 430, 16, 18, PreviousAchievementPage, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_nextAchievementPage = DrawElementViewService.DrawElement(410, 430, 16, 18, NextAchievementPage, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);

		int yPosition = 270;
		int xPosition = 465;

		for (int i = (int)listFrom; i < PlayersProfiles.Instance.ListOfProfiles.Count && i < (int)listTo; i++)                              // wypisze liste userów od A do B
		{
			// PLAYERNAME
			GUI.Label(ResizeViewService.ResizeGUI(new Rect(200, yPosition, 150, 30), ResizeViewService.Horizontal.left, ResizeViewService.Vertical.center),
						"<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].PlayerName + "</color>", SetGUIStyleViewService.LabelStyle);

			// HIGHSCORE
			GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, yPosition, 150, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center),
						"<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + PlayersProfiles.Instance.ListOfProfiles[i].HighScore + "</color>", SetGUIStyleViewService.LabelStyle);

			// ACHIEVEMENTS
			AchievementSingleEntryView.ListAchievements(i, PlayersProfiles.Instance.ListOfProfiles[i], xPosition, yPosition);                      // wypisuje achievementy dla aktualnie parsowanego w pętli obiektu

			yPosition += 30;
			xPosition = 465;
		}

		MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;
	}



	private void CalculateStartAndEndPositionsForAchievements()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeViewService.ClickedWithinForUpdate(_previousAchievementPage) && _listAchievementsFrom > 0)
			{
				_listAchievementsFrom -= _scope;
				_listAchievementsTo -= _scope;
			}

			if (ResizeViewService.ClickedWithinForUpdate(_nextAchievementPage) && _listAchievementsTo < PlayersProfiles.Instance.ListOfProfiles.Count)
			{
				_listAchievementsFrom += _scope;
				_listAchievementsTo += _scope;
			}
		}
	}
}
