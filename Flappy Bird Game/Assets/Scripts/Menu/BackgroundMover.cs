using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

	private float _horizontalMove;
	private float _speed;

	private void Start()
	{
		_horizontalMove = -0.024f;
	}

	void Update ()
	{
		MoveBackground();
	}

	private void MoveBackground()
	{
		if (transform.position.x >= -0.024f && transform.position.x <= 23.42f)
		{
			transform.position = new Vector2(_horizontalMove, 0.0f);
			_horizontalMove = _horizontalMove + 0.004f;
		}
	}
}


// -0.024 do 23.42