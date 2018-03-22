using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
	[SerializeField] private GameManager GameManager;
	[SerializeField] private ParticleSystem PlayerParticles;
	[SerializeField] private GUIGamePlayView GUIGamePlayView;
	[SerializeField] private GUISummaryView GUISummaryView;

	private float _sensitivity;
	private float _velocity;
	private float _gravity;

	private float _moveVertical;
	private Vector2 _gravityMovement;
	private Vector2 _playerMovement;
	private Vector2 _mergedMovement;

	void Start()
	{
		_sensitivity = 12f;
		_velocity = 0.0f;
		_gravity = 3f;

		_playerMovement = new Vector2(0.0f, 0.0f);
	}



	private void FixedUpdate()
	{
		MovePlayer();
	} 



	private void OnTriggerEnter2D(Collider2D collision)            
	{
		if (collision.gameObject.CompareTag("Score"))                                                       // zdobyty punkt
		{
			GameManager.CurrentScore = 1;
			if (GameManager.AchievementToUnlock())
			{
				PlayerParticles.Play();
				StartCoroutine(GUIGamePlayView.AchievementUnlockedNotification());
			}
		}

		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))			 // stracone życie
		{
			GUISummaryView.DisplayGUISummaryView();
		}
	}



	private void MovePlayer()                                          
	{
		_moveVertical = Input.GetAxis("Vertical");

		if (Input.GetKeyUp("s") || Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			Input.ResetInputAxes();                                                     // reset wartosci getinputaxis, player moze podskoczyc po osiagnieciu wartosci 1
			_velocity = 0;                                                              // reset predkosci po wzbiciu sie w gore, player znow zaczyna opadać z predkoscia poczatkowa 0
		}

		_playerMovement = Vector2.up * _moveVertical * Time.deltaTime * _sensitivity;			// wyliczenie wektora ruchu playera na bazie Input.GetAxis()

		_velocity += _gravity * Time.deltaTime;											// predkosc jako iloczyn grawitacji (przyspieszenia) i czasu
		_gravityMovement = Vector2.down * _velocity * Time.deltaTime;						// wyliczenie wektora przyspieszenia

		_mergedMovement = _playerMovement + _gravityMovement;										// suma wektorów ruchu i opadania
		transform.Translate(_mergedMovement);													// przesuniecie o sume wektorów
	}
}
