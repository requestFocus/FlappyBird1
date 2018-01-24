using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour {

	private float obstacleAcceleration;
	private float startXPosition;
	private float endXPosition;
	private float yPosition;

	void Start () {
		obstacleAcceleration = 1.0f;

		startXPosition = 5.0f;
		endXPosition = -10.88f;
		yPosition = Random.Range(-3.0f, 3.0f);

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
			Debug.Log("w ifie, x: " + transform.position.x + ", y: " + transform.position.y);
		}
		else
		{
			transform.position = new Vector2(startXPosition, yPosition);
			Debug.Log("w elsie, x: " + transform.position.x + ", y: " + transform.position.y);
		}
	}
}
