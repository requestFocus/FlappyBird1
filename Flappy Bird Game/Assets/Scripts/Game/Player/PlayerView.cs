using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
	[SerializeField] private LevelService LevelService;

	private float _sensitivity;
	private float _velocity;
	private float _gravity;
	private float _moveVertical;
	private Vector2 _gravityMovement;
	private Vector2 _playerMovement;
	private Vector2 _mergedMovement;

	private void Update()
	{
		MovePlayer();
	}


	private void OnTriggerEnter2D(Collider2D collision)            
	{
		LevelService.PointEarned(collision);
		LevelService.LifeLost(collision);
	}



	private void MovePlayer()                                                   // PLAYER SERVICE                         
	{
		_sensitivity = 12f;
		_gravity = 3f;

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
		transform.Translate(_mergedMovement);                                                   // przesuniecie o sume wektorów
	}
}
