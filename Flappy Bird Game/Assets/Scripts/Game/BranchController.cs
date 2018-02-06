using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour {

	private float obstacleAcceleration;
	private float startXPosition;
	private float endXPosition;
	private float yPosition;

	void Start () {
		obstacleAcceleration = 50f;

		startXPosition = 5.0f;
		endXPosition = -10.88f;
		yPosition = Random.Range(-3.0f, 3.0f);

		transform.position = new Vector3(startXPosition, yPosition);
	}

	private void FixedUpdate()
	{
		MoveObstacle();
	}

	private void MoveObstacle()
	{
		if (transform.position.x <= startXPosition && transform.position.x >= endXPosition)
		{
			transform.position += (new Vector3(-0.1f, 0, 0) * Time.deltaTime * obstacleAcceleration);
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
