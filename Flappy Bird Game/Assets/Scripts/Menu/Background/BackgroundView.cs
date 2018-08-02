using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundView : MonoBehaviour
{
	private const float _speed = 0.15f;
    private const float _rightEdge1 = -9.5f;
    private const float _rightEdge2 = 8.85f;

    private void FixedUpdate()
	{
		MoveBackground();
	}

	private void MoveBackground()
	{
		if (transform.position.x < _rightEdge2)
		{
			transform.position += Vector3.right * Time.deltaTime * _speed;
		}
		else
		{
			transform.position = Vector3.right * _rightEdge1;
		}
	}
}

