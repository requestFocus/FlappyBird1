using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour {

	private float _horizontalMove;
	private float _speed;
	private float _rightEdge1;
	private float _rightEdge2;

	private void Start()
	{
		_horizontalMove = 0.05f;
		_speed = 3.0f;
		_rightEdge1 = -11.723f;
		_rightEdge2 = 6.68f;
	}

	void FixedUpdate ()
	{
		MoveBackground();
	}

	private void MoveBackground()
	{
		if (transform.position.x >= _rightEdge1 && transform.position.x < _rightEdge2)
		{
			//_horizontalMove = _horizontalMove + 0.004f;
			transform.position += (new Vector3(_horizontalMove, 0.0f, 0.0f) * Time.deltaTime * _speed);
		}
		else
		{
			transform.position  = new Vector2(_rightEdge1, 0.0f);
		}
	}
}

