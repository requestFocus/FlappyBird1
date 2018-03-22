using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnView : MonoBehaviour {

	private const float _startXPosition = 5.0f;
	private const float _endXPosition = -10.88f;
	private const float _acceleration = 5.0f;
	private const float _minRange = -3.0f;
	private const float _maxRange = 3.0f;
	private float _yPosition;

	void Start ()
	{
		_yPosition = Random.Range(_minRange, _maxRange);

		transform.position = new Vector3(_startXPosition, _yPosition);
	}

	private void FixedUpdate()
	{
		MoveColumn();
	}

	private void MoveColumn()													
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
