using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMain : MonoBehaviour
{
	[SerializeField] private BackgroundGameView BackgroundGameViewPrefab;
	[SerializeField] private PlayerView PlayerView;

	private void Start()
	{
		Instantiate(BackgroundGameViewPrefab, gameObject.transform);       // skrypt nie musi byc niszczony, bo obiekt ma zapętlone przejście i wystarczy jedna instancja
	}
}
