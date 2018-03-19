using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameManager GameManager;
	[SerializeField] private ParticleSystem PlayerParticles;
	[SerializeField] private CanvasController CanvasController;

	private float _sensitivity;
	private float _velocity;
	private float _gravity;

	private float _moveVertical;
	private Vector2 _gravityMovement;
	private Vector2 _beeMovement;
	private Vector2 _movement;

	void Start()
	{
		_sensitivity = 12f;
		_velocity = 0.0f;
		_gravity = 3f;

		_beeMovement = new Vector2(0.0f, 0.0f);
	}



	private void Update()
	{
		MoveBee();
	}



	private void OnTriggerEnter2D(Collider2D collision)				
	{
		if (collision.gameObject.CompareTag("Score"))                                                       // zdobyty punkt
		{
			GameManager.CurrentScore = 1;
			if (GameManager.AchievementToUnlock())
			{
				PlayerParticles.Play();
				StartCoroutine(CanvasController.AchievementUnlockedNotification());
			}
		}

		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))     // stracone życie
		{
			GameManager.CanvasController.DisplayCanvasOnSummary();
		}
	}



	private void MoveBee()											// SERWIS, PORUSZA PLAYEREM
	{
		_moveVertical = Input.GetAxis("Vertical");

		if (Input.GetKeyUp("s") || Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			Input.ResetInputAxes();														// reset wartosci getinputaxis, player moze podskoczyc po osiagnieciu wartosci 1
			_velocity = 0;																// reset predkosci po wzbiciu sie w gore, player znow zaczyna opadać z predkoscia poczatkowa 0
		}

		_beeMovement = Vector2.up * _moveVertical * Time.deltaTime * _sensitivity;			// wyliczenie wektora ruchu playera na bazie Input.GetAxis()

		_velocity += _gravity * Time.deltaTime;											// predkosc jako iloczyn grawitacji (przyspieszenia) i czasu
		_gravityMovement = Vector2.down * _velocity * Time.deltaTime;						// wyliczenie wektora przyspieszenia

		_movement = _beeMovement + _gravityMovement;										// suma wektorów ruchu i opadania
		transform.Translate(_movement);													// przesuniecie o sume wektorów
	}
}

/*
 * faktyczne przyspieszenie to suma grawitacji (przyspieszenia ziemskiego) i przyspieszenia pionowego wynikającego z naciśnięcia strzałki
 * delta ruchu (przebytej drogi) to iloczyn prędkości i czasu
 * prędkość naliczana jest jako iloczyn przyspieszenia i czasu
 * 
 * delta ruchu to wektor bedący argumentem dla Translate
 * 
 * (gravity scale in inspector = 0.2)
 * (_player.AddForce(_movement * _speed);)
 */
