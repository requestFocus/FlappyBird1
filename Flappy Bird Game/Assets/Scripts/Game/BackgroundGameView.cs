using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGameView : MonoBehaviour
{
	[SerializeField] private LevelService NonGUIService;

	private void FixedUpdate ()
	{
		NonGUIService.MoveBackground(this);
	}
}

