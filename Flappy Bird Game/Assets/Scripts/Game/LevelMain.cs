using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMain : MonoBehaviour
{
	public BackgroundGameView BackgroundGameView;
	public PlayerView PlayerViewPrefab;

	private void Start()
	{
		Instantiate(BackgroundGameView, gameObject.transform);                        // skrypt nie musi byc niszczony, bo obiekt ma zapętlone przejście i wystarczy jedna instancja
		Instantiate(PlayerViewPrefab, gameObject.transform);
	}

}
