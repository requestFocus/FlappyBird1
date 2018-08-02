using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundView : MonoBehaviour
{
	private const float _horizontalMove = 0.05f;
	private const float _speed = 3.0f;
	private const float _rightEdge1 = -11.723f;
	private const float _rightEdge2 = 6.68f;

	private void FixedUpdate()
	{
		MoveBackground();
	}

	private void MoveBackground()
	{
		if (transform.position.x >= _rightEdge1 && transform.position.x < _rightEdge2)
		{
			transform.position += (new Vector3(_horizontalMove, 0.0f, 0.0f) * Time.deltaTime * _speed);
		}
		else
		{
			transform.position = new Vector2(_rightEdge1, 0.0f);
		}
	}
}

