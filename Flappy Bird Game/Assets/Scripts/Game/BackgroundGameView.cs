using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGameView : MonoBehaviour
{
	[SerializeField] private LevelService LevelService;

	private void FixedUpdate ()
	{
		LevelService.MoveBackground(this);
	}
}

