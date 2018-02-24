using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public GameManager GameManager;
	public ParticleSystem PlayerParticles;
	public CanvasController CanvasController;

	public float Sensitivity;
	public float Velocity;
	public float Gravity;

	public float MoveVertical;
	public Vector2 GravityMovement;
	public Vector2 BeeMovement;
	public Vector2 Movement;

	void Start()
	{
		Sensitivity = 12f;
		Velocity = 0.0f;
		Gravity = 3f;

		BeeMovement = new Vector2(0.0f, 0.0f);
	}



	private void Update()
	{
		MoveBee();
	}



	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Score"))                                                       // zdobyty punkt
		{
			GameManager.SetScore();
			//Debug.Log("OnTriggerEnter2D Score: " + GameManager.GetScore());
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



	private void MoveBee()
	{
		MoveVertical = Input.GetAxis("Vertical");

		if (Input.GetKeyUp("s") || Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			Input.ResetInputAxes();														// reset wartosci getinputaxis, player moze podskoczyc po osiagnieciu wartosci 1
			Velocity = 0;																// reset predkosci po wzbiciu sie w gore, player znow zaczyna opadać z predkoscia poczatkowa 0
		}

		BeeMovement = Vector2.up * MoveVertical * Time.deltaTime * Sensitivity;			// wyliczenie wektora ruchu playera na bazie Input.GetAxis()

		Velocity += Gravity * Time.deltaTime;											// predkosc jako iloczyn grawitacji (przyspieszenia) i czasu
		GravityMovement = Vector2.down * Velocity * Time.deltaTime;						// wyliczenie wektora przyspieszenia

		//Debug.Log("MoveVertical: " + MoveVertical + " // Velocity: " + Velocity + " // Time.deltaTime: " + Time.deltaTime + " //// " + "BeeMovement.y: " + BeeMovement.y + " + GravityMovement.y: " + GravityMovement.y + " = Movement.y: " + Movement.y);

		Movement = BeeMovement + GravityMovement;										// suma wektorów ruchu i opadania
		transform.Translate(Movement);													// przesuniecie o sume wektorów
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
