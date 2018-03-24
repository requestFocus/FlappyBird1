using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnView : MonoBehaviour
{
	[SerializeField] private NonGUIService NonGUIService;

	void Start ()
	{
		NonGUIService.InitializeColumn(this);
	}

	private void FixedUpdate()
	{
		NonGUIService.MoveColumn(this);
	}
}
