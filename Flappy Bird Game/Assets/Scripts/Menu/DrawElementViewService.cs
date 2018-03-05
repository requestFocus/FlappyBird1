using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawElementViewService
{
	public ResizeViewService ResizeViewService = new ResizeViewService();
	public SetGUIStyleViewService SetGUIStyleViewService = new SetGUIStyleViewService();

	private Rect _logoRect;

	public Rect DrawElement(int x, int y, int width, int height, Texture menuElement, ResizeViewService.Horizontal horizontalAlignment, ResizeViewService.Vertical verticalAlignment)
	{
		Rect RectScalableDimensions = ResizeViewService.ResizeGUI(new Rect(x, y, width, height), horizontalAlignment, verticalAlignment);
		GUI.DrawTexture(RectScalableDimensions, menuElement);

		return RectScalableDimensions;
	}


	public void DrawCommonViewELements(Texture logoElement, Texture menuElement)
	{
		_logoRect = DrawElement(315, 20, 170, 170, logoElement, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.top);
		DrawElement(350, 550, 100, 30, menuElement, ResizeViewService.Horizontal.center, ResizeViewService.Vertical.bottom);

		if (Input.GetMouseButtonDown(0))
		{
			if (ResizeViewService.ClickedWithin(_logoRect))
			{
				MenuScreensService.MenuStates = MenuScreensService.MenuScreens.MainMenu;
			}
		}
	}
}
