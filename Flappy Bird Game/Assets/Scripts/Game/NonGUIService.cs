using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonGUIService : MonoBehaviour
{
	// PLAYER
	private float _sensitivity;
	private float _velocity;
	private float _gravity;
	private float _moveVertical;
	private Vector2 _gravityMovement;
	private Vector2 _playerMovement;
	private Vector2 _mergedMovement;

	// COLUMN
	private const float _startXPosition = 8.0f;
	private const float _endXPosition = -8.0f;
	private const float _acceleration = 5.0f;
	private const float _minRange = -3.0f;
	private const float _maxRange = 3.0f;
	private float _yPosition;

	// BACKGROUND
	private const float _horizontalMove = 0.05f;
	private const float _speed = 3.0f;
	private const float _rightEdge1 = -11.723f;
	private const float _rightEdge2 = 6.68f;

	[SerializeField] private GameManager GameManager;
	[SerializeField] private ParticleSystem AchievementParticles;
	[SerializeField] private GUIGamePlayView GUIGamePlayView;
	[SerializeField] private GUISummaryView GUISummaryView;

	private void Start()
	{
		_sensitivity = 12f;
		_velocity = 0.0f;
		_gravity = 3f;

		_playerMovement = new Vector2(0.0f, 0.0f);
	}



	public void MovePlayer(PlayerView player)                                                   // wyniesienie tego do serwisu bedzie wymagało monobehaviour, co będzie problemem przy prefabach                            
	{
		_moveVertical = Input.GetAxis("Vertical");

		if (Input.GetKeyUp("s") || Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			Input.ResetInputAxes();                                                     // reset wartosci getinputaxis, player moze podskoczyc po osiagnieciu wartosci 1
			_velocity = 0;                                                              // reset predkosci po wzbiciu sie w gore, player znow zaczyna opadać z predkoscia poczatkowa 0
		}

		_playerMovement = Vector2.up * _moveVertical * Time.deltaTime * _sensitivity;           // wyliczenie wektora ruchu playera na bazie Input.GetAxis()

		_velocity += _gravity * Time.deltaTime;                                         // predkosc jako iloczyn grawitacji (przyspieszenia) i czasu
		_gravityMovement = Vector2.down * _velocity * Time.deltaTime;                       // wyliczenie wektora przyspieszenia

		_mergedMovement = _playerMovement + _gravityMovement;                                       // suma wektorów ruchu i opadania
		player.transform.Translate(_mergedMovement);                                                   // przesuniecie o sume wektorów
	}



	public void PointEarned(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Score"))                                                       // zdobyty punkt
		{
			GameManager.CurrentScore = 1;
			if (GameManager.AchievementToUnlock())
			{
				AchievementParticles.Play();
				StartCoroutine(GUIGamePlayView.AchievementUnlockedNotification());
			}
		}
	}



	public void LifeLost(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))          // stracone życie
		{
			CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.Summary;
		}
	}



	public void MoveColumn(ColumnView column)                                       // SERWIS COLUMNY+PLAYERA									
	{
		if (column.transform.position.x <= _startXPosition && column.transform.position.x >= _endXPosition)
		{
			column.transform.position += (Vector3.left * Time.deltaTime * _acceleration);
		}
		else
		{
			Destroy(column);
		}
	}


	public void InitializeColumn(ColumnView column)
	{
		_yPosition = Random.Range(_minRange, _maxRange);

		column.transform.position = new Vector3(_startXPosition, _yPosition);
	}



	public void MoveBackground(BackgroundGameView background)
	{
		if (background.transform.position.x >= _rightEdge1 && background.transform.position.x < _rightEdge2)
		{
			background.transform.position += (new Vector3(_horizontalMove, 0.0f, 0.0f) * Time.deltaTime * _speed);
		}
		else
		{
			background.transform.position = new Vector2(_rightEdge1, 0.0f);
		}
	}
}
