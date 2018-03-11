using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsView : View {

	[SerializeField] private Texture LogoButton;
	[SerializeField] private Texture AchievementsButtonInactive;
	[SerializeField] private Texture NextAchievementPage;
	[SerializeField] private Texture PreviousAchievementPage;

	[SerializeField] private AchievementSingleEntryView AchievementSingleEntryView;

	private ResizeViewService _resizeViewService;
	private DrawElementViewService _drawElementViewService;
	private SetGUIStyleViewService _setGUIStyleViewService;
	private LoginViewService _loginViewService;

	private Rect _nextAchievementPage;
	private Rect _previousAchievementPage;
	private float _listAchievementsFrom;
	private float _listAchievementsTo;
	private const float _scope = 5;

	private void Start ()
	{
		_listAchievementsFrom = 0;
		_listAchievementsTo = _scope;

		_resizeViewService = new ResizeViewService();
		_drawElementViewService = new DrawElementViewService();
		_setGUIStyleViewService = new SetGUIStyleViewService();
		_setGUIStyleViewService.SetGUIStyle();
	}



	private void Update ()
	{
		if (MenuScreensService.MenuStates.Equals(MenuScreensService.MenuScreens.Achievements))
		{
			CalculateStartAndEndPositionsForAchievements();
		}
	}



	public void DrawAchievementsMenu()
	{
		ListNameScoreAchievements(_listAchievementsFrom, _listAchievementsTo);

		_drawElementViewService.DrawCommonViewELements(LogoButton, AchievementsButtonInactive);
	}


	//public void DrawAchievementsMenu()                                              //====================DLACZEGO TU NIE DZIAŁA EXIT (clickedwithin logo), CHOCIAZ NIE MA BLEDU?
	//{
	//	_drawElementViewService.DrawCommonViewELements(LogoButton, AchievementsButtonInactive);

	//	ListNameScoreAchievements(_listAchievementsFrom, _listAchievementsTo);
	//}



	private void ListNameScoreAchievements(float listFrom, float listTo)
	{
		// LABELS
		GUI.Label(_resizeViewService.ResizeGUI(new Rect(200, 240, 150, 30), ResizeViewService.Horizontal.left, ResizeViewService.Vertical.center), "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">NAME</color>", _setGUIStyleViewService.LabelStyle);
		GUI.Label(_resizeViewService.ResizeGUI(new Rect(300, 240, 150, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">HIGHSCORE</color>", _setGUIStyleViewService.LabelStyle);
		GUI.Label(_resizeViewService.ResizeGUI(new Rect(430, 240, 150, 30), ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center), "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">ACHIEVEMENTS</color>", _setGUIStyleViewService.LabelStyle);

		// BUTTONS
		_previousAchievementPage = _drawElementViewService.DrawElement(376, 430, 16, 18, PreviousAchievementPage, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
		_nextAchievementPage = _drawElementViewService.DrawElement(410, 430, 16, 18, NextAchievementPage, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);

		int yPosition = 270;
		int xPosition = 465;

		for (int i = (int)listFrom; i < AchievementsModel.EntireList.Count && i < (int)listTo; i++)                              // wypisze liste userów od A do B
		{
			// PLAYERNAME
			GUI.Label(_resizeViewService.ResizeGUI(new Rect(200, yPosition, 150, 30), ResizeViewService.Horizontal.left, ResizeViewService.Vertical.center),
						"<color=#" + _setGUIStyleViewService.LightGreyFont + ">" + AchievementsModel.EntireList[i].PlayerName + "</color>", _setGUIStyleViewService.LabelStyle);

			// HIGHSCORE
			GUI.Label(_resizeViewService.ResizeGUI(new Rect(300, yPosition, 150, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center),
						"<color=#" + _setGUIStyleViewService.LightGreyFont + ">" + AchievementsModel.EntireList[i].HighScore + "</color>", _setGUIStyleViewService.LabelStyle);

			// ACHIEVEMENTS
			AchievementSingleEntryView.ListAchievements(AchievementsModel.EntireList[i], xPosition, yPosition);                      // wypisuje achievementy dla aktualnie parsowanego w pętli obiektu

			yPosition += 30;
			xPosition = 465;
		}

		MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;
	}



	private void CalculateStartAndEndPositionsForAchievements()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_resizeViewService.ClickedWithinForUpdate(_previousAchievementPage) && _listAchievementsFrom > 0)
			{
				_listAchievementsFrom -= _scope;
				_listAchievementsTo -= _scope;
			}

			if (_resizeViewService.ClickedWithinForUpdate(_nextAchievementPage) && _listAchievementsTo < AchievementsModel.EntireList.Count)
			{
				_listAchievementsFrom += _scope;
				_listAchievementsTo += _scope;
			}
		}
	}
}
