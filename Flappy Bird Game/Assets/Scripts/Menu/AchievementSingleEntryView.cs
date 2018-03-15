using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSingleEntryView : View<AchievementsModel> {

	[SerializeField] private Texture Complete10Active;
	[SerializeField] private Texture Complete10Inactive;
	[SerializeField] private Texture Complete25Active;
	[SerializeField] private Texture Complete25Inactive;
	[SerializeField] private Texture Complete50Active;
	[SerializeField] private Texture Complete50Inactive;

	private DrawElementViewService _drawElementViewService;

	private void Start()
	{
		_drawElementViewService = new DrawElementViewService();
	}



	public void ListAchievements(PlayerProfile playerProfile, int xPosition, int yPosition)
	{
		if (playerProfile.Complete10)
		{
			_drawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Active, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);         // IKONY ACHIEVEMENTOW MAJA WYMIARY 96x110
		}
		else
		{
			_drawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete10Inactive, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}

		xPosition += 30;

		if (playerProfile.Complete25)
		{
			_drawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Active, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}
		else
		{
			_drawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete25Inactive, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}

		xPosition += 30;

		if (playerProfile.Complete50)
		{
			_drawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Active, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}
		else
		{
			_drawElementViewService.DrawElement(xPosition, yPosition, 23, 28, Complete50Inactive, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.center);
		}
	}
}
