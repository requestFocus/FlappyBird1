using UnityEngine;

public class ColumnView : MonoBehaviour
{
	private const float _startXPosition = 8.0f;
	private const float _endXPosition = -8.0f;
	private const float _acceleration = 5.0f;
	
	private void FixedUpdate()
	{
		MoveColumn();
	}

	private void MoveColumn()                                       // COLUMN SERVICE								
	{
		if (transform.position.x <= _startXPosition && transform.position.x >= _endXPosition && CurrentGameStateService.CurrentGameState == CurrentGameStateService.GameStates.GamePlay)
			transform.position += (Vector3.left * Time.deltaTime * _acceleration);
		else
			Destroy(gameObject);
	}
}
