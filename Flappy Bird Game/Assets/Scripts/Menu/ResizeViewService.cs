using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeViewService
{
	private float _defaultScreenWidth = 800;
	private float _defaultScreenHeight = 600;
	private float _scaleWidth;
	private float _scaleHeigth;
	private float _usableScale;
	private float _middleButtonXPosition;
	private float _middleButtonYPosition;

	private Vector2 _myMousePosition;
	private Vector2 _myMousePositionForUpdate;
	
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

		_middleButtonXPosition = rect.x + rect.width / 2;
		_middleButtonYPosition = rect.y + rect.height / 2;

		switch (horizontalAlignment)
		{
			case Horizontal.left:
				//middleButtonXPosition = middleButtonXPosition;                                                                 // bez zmian
				break;
			case Horizontal.center:
				_middleButtonXPosition = _middleButtonXPosition + ((Screen.width - _defaultScreenWidth) / 2);                   // przesuwa się o polowę tego, jak zmienia się wielkość ekranu
				break;
			case Horizontal.right:
				_middleButtonXPosition = _middleButtonXPosition + (Screen.width - _defaultScreenWidth);                      // przesuwa się o tyle, o ile zmienia się wielkość ekranu
				break;
		}

		switch (verticalAlignment)
		{
			case Vertical.top:
				//middleButtonYPosition = middleButtonYPosition;                                                                 // bez zmian
				break;
			case Vertical.center:
				_middleButtonYPosition = _middleButtonYPosition + ((Screen.height - _defaultScreenHeight) / 2);                   // przesuwa się o polowę tego, jak zmienia się wielkość ekranu
				break;
			case Vertical.bottom:
				_middleButtonYPosition = _middleButtonYPosition + (Screen.height - _defaultScreenHeight);                       // przesuwa się o tyle, o ile zmienia się wielkość ekranu
				break;
		}

		rect.x = _middleButtonXPosition - (rect.width * _usableScale / 2);
		rect.y = _middleButtonYPosition - (rect.height * _usableScale / 2);

		return new Rect(rect.x, rect.y, rect.width * _usableScale, rect.height * _usableScale);
	}



	public bool ClickedWithin(Rect rect)
	{
		_myMousePosition = Event.current.mousePosition;
		return ((_myMousePosition.x >= rect.x) && (_myMousePosition.x <= (rect.x + rect.width)) && (_myMousePosition.y >= rect.y) && (_myMousePosition.y <= (rect.y + rect.height)));
	}



	public bool ClickedWithinForUpdate(Rect rect)               // @ AchievementsView => Update() nie rozumie Event.current.mousePosition, trzeba użyć Input.mousePosition
	{
		_myMousePositionForUpdate = Input.mousePosition;
		return ((_myMousePositionForUpdate.x >= rect.x) && (_myMousePositionForUpdate.x <= (rect.x + rect.width)) && (_myMousePositionForUpdate.y >= (Screen.height - rect.y - rect.height)) && (_myMousePositionForUpdate.y <= (Screen.height - rect.y)));
	}
}
