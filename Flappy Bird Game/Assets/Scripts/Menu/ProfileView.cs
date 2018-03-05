using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileView : MonoBehaviour {

	[SerializeField] private Texture LogoButton;
	public Texture ProfileButtonInactive;

	public AchievementSingleEntryView AchievementSingleEntryView;

	public ResizeViewService ResizeViewService;
	public DrawElementViewService DrawElementViewService;
	public SetGUIStyleViewService SetGUIStyleViewService;

	void Start ()
	{
		ResizeViewService = new ResizeViewService();
		DrawElementViewService = new DrawElementViewService();
		SetGUIStyleViewService = new SetGUIStyleViewService();
		SetGUIStyleViewService.SetGUIStyle();
	}



	public void DrawProfileView()               // obsluga NEW GAME
	{
		SetGUIStyleViewService.LabelContent.text = "<color=#" + SetGUIStyleViewService.DarkGreyFont + ">NAME\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + LoginViewService.PlayerProfile.PlayerName + "</color>\n\n" +
								"HIGHSCORE\n<color=#" + SetGUIStyleViewService.LightGreyFont + ">" + LoginViewService.PlayerProfile.HighScore + "</color>\n\n" +
								"ACHIEVEMENTS\n</color>";
		GUI.Label(ResizeViewService.ResizeGUI(new Rect(300, 300, 200, 30), ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center), SetGUIStyleViewService.LabelContent, SetGUIStyleViewService.LabelStyle);

		AchievementSingleEntryView.ListAchievements(PlayersProfiles.Instance.CurrentProfile, LoginViewService.PlayerProfile, 360, 370);                     // wypisuje achievementy dla zalogowanego playera

		DrawElementViewService.DrawCommonViewELements(LogoButton, ProfileButtonInactive);
	}
}
