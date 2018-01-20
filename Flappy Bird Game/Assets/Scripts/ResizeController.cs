using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeController : MonoBehaviour
{
	public Rect ResizeGUI(Rect rect)
	{
		float OrigScreenWidthRatio = rect.width / 800;				// liczy wspolczynnik wymiaru recta do domyslnej szerokości ekranu
		float rectWidth = OrigScreenWidthRatio * Screen.width;		// liczy wyskalowaną szerokość recta na podstawie wspolczynnika i aktualnej szerokości ekranu
		float OrigScreenHeightRatio = rect.height / 600;            // liczy wspolczynnik wymiaru recta do domyslnej wysokości ekranu
		float rectHeight = OrigScreenHeightRatio * Screen.height;   // liczy wyskalowaną szerokość recta na podstawie wspolczynnika i aktualnej wysokości ekranu
		float rectX = (rect.x / 800) * Screen.width;				// liczy wspolrzedną X recta (przysłane X dzielone przez domyslną szerokośc razy aktualna szerokość ekranu)
		float rectY = (rect.y / 600) * Screen.height;               // liczy współrzędną Y recta (przysłane Y dzielone przez domyslną wysokosc razy aktualna wysokość ekranu)

		return new Rect(rectX, rectY, rectWidth, rectHeight);
	}
}
