using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawElementViewService
{
	ResizeControllerViewService ResizeControllerViewService = new ResizeControllerViewService();

	public Rect DrawElement(int x, int y, int width, int height, Texture menuElement, ResizeControllerViewService.Horizontal horizontalAlignment, ResizeControllerViewService.Vertical verticalAlignment)
	{
		Rect RectScalableDimensions = ResizeControllerViewService.ResizeGUI(new Rect(x, y, width, height), horizontalAlignment, verticalAlignment);
		GUI.DrawTexture(RectScalableDimensions, menuElement);

		return RectScalableDimensions;
	}
}
