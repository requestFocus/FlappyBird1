using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileView : View<ProfileModel, ProfileController> {

	[SerializeField] private Texture LogoButton;
	[SerializeField] private Texture ProfileButtonInactive;

	[SerializeField] private AchievementSingleEntryView AchievementSingleEntryView;
	[SerializeField] private ResizeViewService ResizeViewService;
	[SerializeField] private DrawElementViewService DrawElementViewService;
	[SerializeField] private SetGUIStyleViewService SetGUIStyleViewService;

	void Start ()
	{
		ResizeViewService = new ResizeViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
		SetGUIStyleViewService.SetGUIStyle();
	}


	public void DrawProfileView()               // obsluga NEW GAME
	{
		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">NAME\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + _model.CurrentProfile.PlayerName + "</color>\n\n" +
								"HIGHSCORE\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + _model.CurrentProfile.HighScore + "</color>\n\n" +
								"ACHIEVEMENTS\n</color>";
		GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

		AchievementSingleEntryView.ListAchievements(_model.CurrentProfile, 360, 370);                     // wypisuje achievementy dla zalogowanego playera

		DrawElementViewService.DrawCommonViewELements(LogoButton, ProfileButtonInactive);
	}
}
