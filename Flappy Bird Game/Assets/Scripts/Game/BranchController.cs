using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour {

	private const float _startXPosition = 5.0f;
	private const float _endXPosition = -10.88f;
	private const float _acceleration = 5.0f;
	private float _yPosition;

	void Start ()
	{
		_yPosition = Random.Range(-3.0f, 3.0f);

		transform.position = new Vector3(_startXPosition, _yPosition);
	}

	private void FixedUpdate()
	{
		MoveObstacle();
	}

	private void MoveObstacle()
	{
		if (transform.position.x <= _startXPosition && transform.position.x >= _endXPosition)
		{
			transform.position += (Vector3.left * Time.deltaTime * _acceleration);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}


/*
So static 2D colliders shouldn't move,
like walls and floors,
dynamic 2D colliders can move
but should have a rigidbody2D attached.
Standard 2D rigidbodies like our
Player are moved using 2D physics forces.
Kinematic 2D rigidbodies are
moved using their transform.
*/
