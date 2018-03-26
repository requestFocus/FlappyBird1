using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMain : MonoBehaviour
{
	public BackgroundGameView BackgroundGameView;

	private void Start()
	{
		BackgroundGameView = Instantiate(BackgroundGameView);
	}

}
