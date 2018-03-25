using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnView : MonoBehaviour
{
	[SerializeField] private LevelService LevelService;
	private bool _destroyColumn;

	void Start ()
	{
		LevelService.InitializeColumn(this);
	}

	private void FixedUpdate()
	{
		_destroyColumn = LevelService.MoveColumn(this);
		if (_destroyColumn)
			Destroy(gameObject);
	}
}
