using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSingleEntryView : MonoBehaviour {

	[SerializeField] private Texture Complete10Active;
	[SerializeField] private Texture Complete10Inactive;
	[SerializeField] private Texture Complete25Active;
	[SerializeField] private Texture Complete25Inactive;
	[SerializeField] private Texture Complete50Active;
	[SerializeField] private Texture Complete50Inactive;

	[SerializeField] private DrawElementViewService DrawElementViewService;

	private void Start()
	{
		DrawElementViewService = new DrawElementViewService();
	}



	public void ListAchievements(PlayerProfile playerProfile, int xPosition, int yPosition)
	{
		if (playerProfile.Complete10)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Active, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);         // IKONY ACHIEVEMENTOW MAJA WYMIARY 96x110
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Inactive, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}

		xPosition += 30;

		if (playerProfile.Complete25)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Active, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Inactive, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}

		xPosition += 30;

		if (playerProfile.Complete50)
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Active, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}
		else
		{
			DrawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Inactive, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}
	}
}
