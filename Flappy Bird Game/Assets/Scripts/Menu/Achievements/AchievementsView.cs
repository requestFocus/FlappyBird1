using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsView : View<AchievementsModel, Controller<AchievementsModel>>
{
	[SerializeField] private Button LogoButton;
	[SerializeField] private Image AchievementsButtonInactive;
	[SerializeField] private Image NextAchievementPage;
	[SerializeField] private Image PreviousAchievementPage;

	[SerializeField] private AchievementSingleEntryView AchievementSingleEntryView;
	AchievementSingleEntryView achievementSingleEntryViewInstance;

	private LoginViewService _loginViewService;
	private Font font;

	public delegate void OnAchievementsViewSet(MenuScreensService.MenuScreens state);                  //======= wyciagnac na zewnatrz?
	public OnAchievementsViewSet OnAchievementsViewSetDel;

	private int _listAchievementsFrom;
	private int _listAchievementsTo;
	private const int _scope = 5;

	private GameObject PlayerAchievements;

	private void Awake()
	{
		Model = new AchievementsModel()
		{
			EntireList = PlayersProfiles.Instance.ListOfProfiles,
			CurrentProfile = PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfileID]
		};
	}

	private void Start()
	{
		_listAchievementsFrom = 0;
		_listAchievementsTo = _scope;

		LogoButton.onClick.AddListener(ClickLogo);

		//PlayerAchievements.transform.SetParent(gameObject.transform);
		font = (Font)Resources.Load("Fonts/Bungee-Regular");

		//DisplayThem();
		for (int i = 0; i < 1; i++)
		{
			PlayerAchievements = new GameObject("element");
			PlayerAchievements.AddComponent<Text>();
			PlayerAchievements.GetComponent<Text>().text = "element" + i;
			PlayerAchievements.GetComponent<Text>().font = font;
			PlayerAchievements.GetComponent<Text>().color = Color.red;
			PlayerAchievements.GetComponent<Text>().transform.position = new Vector3(300, 200);
		}
	}

	public void ClickLogo()             //=========================================================================pomyslec o wyrzuceniu tego do jakiegos serwisu
	{
		OnAchievementsViewSetDel(MenuScreensService.MenuScreens.MainMenu);
		Destroy(gameObject);
	}

	private void DisplayThem()
	{
		for (int i = 0; i < 1; i++)
		{
			PlayerAchievements = new GameObject("element");
			PlayerAchievements.AddComponent<Text>();
			PlayerAchievements.GetComponent<Text>().text = "element" + i;
			PlayerAchievements.GetComponent<Text>().font = font;
			PlayerAchievements.GetComponent<Text>().color = Color.red;
			PlayerAchievements.GetComponent<Text>().transform.position = new Vector3(300, 200);
		}
	}

	private void ListNameScoreAchievements(int listFrom, int listTo)
	{
		int yPosition = 270;
		int xPosition = 465;

		for (int i = listFrom; i < Model.EntireList.Count && i < (int)listTo; i++)                              // wypisze liste userów od A do B
		{
			if (Model.EntireList[i].PlayerName.Equals(Model.CurrentProfile.PlayerName))             // jeśli wypisuje aktualnego playera
			{
				// np. TextComponent.color = Color.red;
			}

			// PLAYERNAME
			//Model.EntireList[i].PlayerName;

			// HIGHSCORE
			//Model.EntireList[i].HighScore;

			// ACHIEVEMENTS
			//AchievementSingleEntryView.ListAchievements(Model.EntireList[i], xPosition, yPosition);                      // wypisuje achievementy dla aktualnie parsowanego w pętli obiektu

			yPosition += 30;
		}
	}

	//private void Update ()
	//{
	//	if (MenuScreensService.MenuStates.Equals(MenuScreensService.MenuScreens.Achievements))
	//	{
	//		CalculateStartAndEndPositionsForAchievements();
	//	}
	//}


	//private void ListNameScoreAchievements(float listFrom, float listTo)
	//{
	//	GUI.Label(_resizeViewService.ResizeGUI(new Rect(200, 240, 150, 30), ResizeViewService.Horizontal.left, ResizeViewService.Vertical.center), "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">NAME</color>", _setGUIStyleViewService.LabelStyle);
	//	GUI.Label(_resizeViewService.ResizeGUI(new Rect(300, 240, 150, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">HIGHSCORE</color>", _setGUIStyleViewService.LabelStyle);
	//	GUI.Label(_resizeViewService.ResizeGUI(new Rect(430, 240, 150, 30), ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center), "<color=#" + _setGUIStyleViewService.DarkGreyFont + ">ACHIEVEMENTS</color>", _setGUIStyleViewService.LabelStyle);

	//	// BUTTONS
	//	_previousAchievementPage = _drawElementViewService.DrawElement(376, 430, 16, 18, PreviousAchievementPage, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);
	//	_nextAchievementPage = _drawElementViewService.DrawElement(410, 430, 16, 18, NextAchievementPage, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);

	//	int yPosition = 270;
	//	int xPosition = 465;

	//	for (int i = (int)listFrom; i < Model.EntireList.Count && i < (int)listTo; i++)                              // wypisze liste userów od A do B
	//	{
	//		string fontColor = "";

	//		if (Model.EntireList[i].PlayerName.Equals(Model.CurrentProfile.PlayerName))				// jeśli wypisuje aktualnego playera
	//		{
	//			fontColor = _setGUIStyleViewService.DarkRedFont;
	//		}
	//		else																												// jeśli wypisuje pozostałych playerów
	//		{
	//			fontColor = _setGUIStyleViewService.LightGreyFont;	
	//		}

	//		// PLAYERNAME
	//		GUI.Label(_resizeViewService.ResizeGUI(new Rect(200, yPosition, 150, 30), ResizeViewService.Horizontal.left, ResizeViewService.Vertical.center),
	//					"<color=#" + fontColor + ">" + Model.EntireList[i].PlayerName + "</color>", _setGUIStyleViewService.LabelStyle);

	//		// HIGHSCORE
	//		GUI.Label(_resizeViewService.ResizeGUI(new Rect(300, yPosition, 150, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center),
	//					"<color=#" + fontColor + ">" + Model.EntireList[i].HighScore + "</color>", _setGUIStyleViewService.LabelStyle);

	//		// ACHIEVEMENTS
	//		//AchievementSingleEntryView.ListAchievements(Model.EntireList[i], xPosition, yPosition);                      // wypisuje achievementy dla aktualnie parsowanego w pętli obiektu

	//		yPosition += 30;
	//		xPosition = 465;
	//	}

	//	MenuScreensService.MenuStates = MenuScreensService.MenuScreens.Achievements;
	//}



	//private void CalculateStartAndEndPositionsForAchievements()
	//{
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		if (_resizeViewService.ClickedWithinForUpdate(_previousAchievementPage) && _listAchievementsFrom > 0)
	//		{
	//			_listAchievementsFrom -= _scope;
	//			_listAchievementsTo -= _scope;
	//		}

	//		if (_resizeViewService.ClickedWithinForUpdate(_nextAchievementPage) && _listAchievementsTo < Model.EntireList.Count)
	//		{
	//			_listAchievementsFrom += _scope;
	//			_listAchievementsTo += _scope;
	//		}
	//	}
	//}
}
