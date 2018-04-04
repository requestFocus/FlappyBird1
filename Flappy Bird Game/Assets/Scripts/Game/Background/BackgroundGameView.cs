using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGameView : MonoBehaviour
{
	private const float _horizontalMove = 0.05f;
	private const float _speed = 3.0f;
	private const float _rightEdge1 = -11.723f;
	private const float _rightEdge2 = 6.68f;

	private void FixedUpdate ()
	{
		MoveBackground();
	}

	private void MoveBackground()                   
	{
		if (transform.position.x >= _rightEdge1 && transform.position.x < _rightEdge2)
		{
			transform.position += Vector3.right * _horizontalMove * Time.deltaTime * _speed;
		}
		else
		{
			transform.position = Vector2.right * _rightEdge1;
		}
	}
}

