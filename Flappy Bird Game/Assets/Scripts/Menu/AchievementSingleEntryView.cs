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
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Active, ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center);         // IKONY ACHIEVEMENTOW MAJA WYMIARY 96x110
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Inactive, ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center);
		}

		xPosition += 30;
		if (playerProfile.Complete25)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Active, ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center);
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Inactive, ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center);
		}

		xPosition += 30;
		if (playerProfile.Complete50)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Active, ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center);
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Inactive, ResizeViewService.Horizontal.right, ResizeViewService.Vertical.center);
		}
	}
}
