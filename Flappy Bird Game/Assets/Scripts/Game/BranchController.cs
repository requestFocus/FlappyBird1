using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour {

	private float obstacleAcceleration;
	private float startXPosition;
	private float endXPosition;
	private float yPosition;

	void Start () {
		obstacleAcceleration = 75f;

		startXPosition = 5.0f;
		endXPosition = -10.88f;
		yPosition = 0;
	}

	private void FixedUpdate()
	{
		if (transform.position.x <= 5 && transform.position.x >= -10.88f)
		{
			transform.position += (new Vector3(-0.1f, yPosition, 0) * Time.deltaTime * obstacleAcceleration);
		}
		else
		{
			// COROUTINE? =================================================
			//yPosition = RandomizeYPosition();
			transform.position = new Vector2(startXPosition, yPosition);
		}
	}

	private float RandomizeYPosition()
	{
		return yPosition = Random.Range(-3.0f, 3.0f);
	}

}
