using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeControllerViewService
{
	private float _defaultScreenWidth = 800;
	private float _defaultScreenHeight = 600;
	private float _scaleWidth;
	private float _scaleHeigth;
	private float _usableScale;

	public Vector2 MyMousePosition;
	public Vector2 MyMousePositionForUpdate;



	public enum Horizontal
	{
		left,
		center,
		right
	}
	public Horizontal HorizontalAlignment;



	public enum Vertical
	{
		top,
		center,
		bottom
	}
	public Vertical VerticalAlignment;



	public Rect ResizeGUI(Rect rect, Horizontal horizontalAlignment, Vertical verticalAlignment)
	{
		_scaleWidth = Screen.width / _defaultScreenWidth;
		_scaleHeigth = Screen.height / _defaultScreenHeight;
		_usableScale = Mathf.Min(_scaleWidth, _scaleHeigth);

		float middleButtonXPosition = rect.x + rect.width / 2;
		float middleButtonYPosition = rect.y + rect.height / 2;

		switch (horizontalAlignment)
		{
			case Horizontal.left:
				//middleButtonXPosition = middleButtonXPosition;                                                                 // bez zmian
				break;
			case Horizontal.center:
				middleButtonXPosition = middleButtonXPosition + ((Screen.width - _defaultScreenWidth) / 2);                   // przesuwa się o polowę tego, jak zmienia się wielkość ekranu
				break;
			case Horizontal.right:
				middleButtonXPosition = middleButtonXPosition + (Screen.width - _defaultScreenWidth);                      // przesuwa się o tyle, o ile zmienia się wielkość ekranu
				break;
		}

		switch (verticalAlignment)
		{
			case Vertical.top:
				//middleButtonYPosition = middleButtonYPosition;                                                                 // bez zmian
				break;
			case Vertical.center:
				middleButtonYPosition = middleButtonYPosition + ((Screen.height - _defaultScreenHeight) / 2);                   // przesuwa się o polowę tego, jak zmienia się wielkość ekranu
				break;
			case Vertical.bottom:
				middleButtonYPosition = middleButtonYPosition + (Screen.height - _defaultScreenHeight);                       // przesuwa się o tyle, o ile zmienia się wielkość ekranu
				break;
		}

		rect.x = middleButtonXPosition - (rect.width * _usableScale / 2);
		rect.y = middleButtonYPosition - (rect.height * _usableScale / 2);

		return new Rect(rect.x, rect.y, rect.width * _usableScale, rect.height * _usableScale);
	}



	public bool ClickedWithin(Rect rect)
	{
		MyMousePosition = Event.current.mousePosition;

		return ((MyMousePosition.x >= rect.x) && (MyMousePosition.x <= (rect.x + rect.width)) && (MyMousePosition.y >= rect.y) && (MyMousePosition.y <= (rect.y + rect.height)));
	}



	public bool ClickedWithinForUpdate(Rect rect)               // Update() nie rozumie Event.current.mousePosition, trzeba użyć Input.mousePosition
	{
		MyMousePositionForUpdate = Input.mousePosition;
		return ((MyMousePositionForUpdate.x >= rect.x) && (MyMousePositionForUpdate.x <= (rect.x + rect.width)) && (MyMousePositionForUpdate.y >= (Screen.height - rect.y - rect.height)) && (MyMousePositionForUpdate.y <= (Screen.height - rect.y)));
	}
}
