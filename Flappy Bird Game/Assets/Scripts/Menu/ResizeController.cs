using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeController : MonoBehaviour
{
	public Rect ResizeGUI(Rect rect)
	{
		float DefaultScreenWidth = 800;
		float DefaultScreenHeight = 600;
		float RectToScreenWidthRatio;
		float RectToScreenHeightRatio;
		float RectWidth;
		float RectHeight;
		float RectX;
		float RectY;

		RectX = (rect.x / DefaultScreenWidth) * Screen.width;               // liczy wspolrzedną X recta (przysłane X dzielone przez domyslną szerokośc razy aktualna szerokość ekranu)
		RectY = (rect.y / DefaultScreenHeight) * Screen.height;               // liczy współrzędną Y recta (przysłane Y dzielone przez domyslną wysokosc razy aktualna wysokość ekranu)



		RectToScreenWidthRatio = rect.width / DefaultScreenWidth;              // liczy STAŁY wspolczynnik wymiaru recta do domyslnej szerokości ekranu
		RectToScreenHeightRatio = rect.height / DefaultScreenHeight;            // liczy STAŁY wspolczynnik wymiaru recta do domyslnej wysokości ekranu

		RectWidth = RectToScreenWidthRatio * Screen.width;                    // liczy ZMIENNĄ wyskalowaną szerokość recta na podstawie wspolczynnika i aktualnej szerokości ekranu
		RectHeight = RectToScreenHeightRatio * Screen.height;               // liczy ZMIENNĄ wyskalowaną wysokosc recta na podstawie wspolczynnika i aktualnej wysokości ekranu

		RectWidth *= (RectHeight / rect.height);       // i jeszcze raz to samo z uwzględnieniem zmian wysokości
		RectHeight *= (RectWidth / rect.width);      // i jeszcze raz to samo z uwzględnieniem zmian szerokości


		return new Rect(RectX, RectY, RectWidth, RectHeight);
	}

	/*
	 * tak trzeba zmodyfikować tą klase, żeby obrazki skalowały się proporcjonalnie, a całe pole nie dało się obcinać poniżej/powyżej pewnego obszaru
	 */
}
