using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnView : MonoBehaviour
{
	//[SerializeField] private LevelService LevelService;

	private const float _startXPosition = 8.0f;
	private const float _endXPosition = -8.0f;
	private const float _acceleration = 5.0f;

	private void FixedUpdate()
	{
		bool destroyColumn;
		destroyColumn = MoveColumn();
		if (destroyColumn)
			Destroy(gameObject);
	}

	private bool MoveColumn()                                       // COLUMN SERVICE								
	{
		if (transform.position.x <= _startXPosition && transform.position.x >= _endXPosition)
		{
			transform.position += (Vector3.left * Time.deltaTime * _acceleration);
			return false;
		}
		else
		{
			return true;
		}
	}
}
