using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGameView : MonoBehaviour
{
	[SerializeField] private NonGUIService NonGUIService;

	private void FixedUpdate ()
	{
		NonGUIService.MoveBackground(this);
	}
}

