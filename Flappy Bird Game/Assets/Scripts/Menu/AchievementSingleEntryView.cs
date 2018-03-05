using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSingleEntryView : MonoBehaviour {

	public Texture Complete10Active;
	public Texture Complete10Inactive;
	public Texture Complete25Active;
	public Texture Complete25Inactive;
	public Texture Complete50Active;
	public Texture Complete50Inactive;

	public DrawElementViewService DrawElementViewService;



	void Start ()
	{
		DrawElementViewService = new DrawElementViewService();
	}



	public void ListAchievements(int currentProfile, PlayerProfile playerProfile, int xPosition, int yPosition)
	{
		if (playerProfile.Complete10)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);         // IKONY ACHIEVEMENTOW MAJA WYMIARY 96x110
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}

		xPosition += 30;
		if (playerProfile.Complete25)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}

		xPosition += 30;
		if (playerProfile.Complete50)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Active, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Inactive, ResizeControllerViewService.Horizontal.right, ResizeControllerViewService.Vertical.center);
		}
	}
}
