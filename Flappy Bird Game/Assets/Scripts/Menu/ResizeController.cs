using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeController : MonoBehaviour
{
	private float _defaultScreenWidth = 800;
	private float _defaultScreenHeight = 600;
	private float _rectToScreenWidthRatio;
	private float _rectToScreenHeightRatio;
	private float _rectWidth;
	private float _rectHeight;
	private float _rectX;
	private float _rectY;

	public Rect ResizeGUI(Rect rect)
	{
		_rectX = (rect.x / _defaultScreenWidth) * Screen.width;               // liczy wspolrzedną X recta (przysłane X dzielone przez domyslną szerokośc razy aktualna szerokość ekranu)
		_rectY = (rect.y / _defaultScreenHeight) * Screen.height;               // liczy współrzędną Y recta (przysłane Y dzielone przez domyslną wysokosc razy aktualna wysokość ekranu)

		_rectToScreenWidthRatio = rect.width / _defaultScreenWidth;              // liczy STAŁY wspolczynnik wymiaru recta do domyslnej szerokości ekranu
		_rectToScreenHeightRatio = rect.height / _defaultScreenHeight;            // liczy STAŁY wspolczynnik wymiaru recta do domyslnej wysokości ekranu

		_rectWidth = _rectToScreenWidthRatio * Screen.width;                    // liczy ZMIENNĄ wyskalowaną szerokość recta na podstawie wspolczynnika i aktualnej szerokości ekranu
		_rectHeight = _rectToScreenHeightRatio * Screen.height;               // liczy ZMIENNĄ wyskalowaną wysokosc recta na podstawie wspolczynnika i aktualnej wysokości ekranu

		_rectWidth *= (_rectHeight / rect.height);       // i jeszcze raz to samo z uwzględnieniem zmian wysokości
		_rectHeight *= (_rectWidth / rect.width);      // i jeszcze raz to samo z uwzględnieniem zmian szerokości

		return new Rect(_rectX, _rectY, _rectWidth, _rectHeight);
	}
}
