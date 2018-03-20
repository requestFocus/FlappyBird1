﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeController : MonoBehaviour
{
	private float _defaultScreenWidth = 800;
	private float _defaultScreenHeight = 600;
	private float _scaleWidth;
	private float _scaleHeigth;
	private float _usableScale;



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
}





//public Rect ResizeGUI(Rect rect)
//{
//	_rectX = (rect.x / _defaultScreenWidth) * Screen.width;               // liczy wspolrzedną X recta (przysłane X dzielone przez domyslną szerokośc razy aktualna szerokość ekranu)
//	_rectY = (rect.y / _defaultScreenHeight) * Screen.height;               // liczy współrzędną Y recta (przysłane Y dzielone przez domyslną wysokosc razy aktualna wysokość ekranu)

//	_rectToScreenWidthRatio = rect.width / _defaultScreenWidth;              // liczy STAŁY wspolczynnik wymiaru recta do domyslnej szerokości ekranu
//	_rectToScreenHeightRatio = rect.height / _defaultScreenHeight;            // liczy STAŁY wspolczynnik wymiaru recta do domyslnej wysokości ekranu

//	_rectWidth = _rectToScreenWidthRatio * Screen.width;                    // liczy ZMIENNĄ wyskalowaną szerokość recta na podstawie wspolczynnika i aktualnej szerokości ekranu
//	_rectHeight = _rectToScreenHeightRatio * Screen.height;               // liczy ZMIENNĄ wyskalowaną wysokosc recta na podstawie wspolczynnika i aktualnej wysokości ekranu

//	_rectWidth *= (_rectHeight / rect.height);       // i jeszcze raz to samo z uwzględnieniem zmian wysokości
//	_rectHeight *= (_rectWidth / rect.width);      // i jeszcze raz to samo z uwzględnieniem zmian szerokości

//	return new Rect(_rectX, _rectY, _rectWidth, _rectHeight);
//}


//public Rect ResizeGUI(Rect rect)
//{
//	_scaleWidth = Screen.width / _defaultScreenWidth;
//	_scaleHeigth = Screen.height / _defaultScreenHeight;
//	_usableScaleWH = Mathf.Min(_scaleWidth, _scaleHeigth);

//	return new Rect(rect.x * _usableScaleWH, rect.y * _usableScaleWH, rect.width * _usableScaleWH, rect.height * _usableScaleWH);
//}


//if (alignHorizontal.cen)
//{
//	rect.x = rect.x;																 // bez zmian
//}
//else if (alignHorizontal.Equals("center"))
//{
//	rect.x = rect.x + ((Screen.width - _defaultScreenWidth) / 2);					// przesuwa się o polowę tego, jak zmienia się wielkość ekranu
//}
//else if (alignHorizontal.Equals("right"))
//{
//	rect.x = rect.x + (Screen.width - _defaultScreenWidth);			             // przesuwa się o tyle, o ile zmienia się wielkość ekranu
//}

//if (alignVertical.Equals("top"))
//{
//	rect.y = rect.y;												               // bez zmian
//}
//else if (alignVertical.Equals("center"))
//{
//	rect.y = rect.y + ((Screen.height - _defaultScreenHeight) / 2);				   // przesuwa się o polowę tego, jak zmienia się wielkość ekranu
//}
//else if (alignVertical.Equals("bottom"))
//{
//	rect.y = rect.y + (Screen.height - _defaultScreenHeight);				        // przesuwa się o tyle, o ile zmienia się wielkość ekranu
//}