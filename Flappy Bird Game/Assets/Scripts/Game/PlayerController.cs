using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _player;
	private float _speed;

	public PlayerProfileController PlayerProfileController;
	public GameManager GameManager;

	public ParticleSystem PlayerParticles;

	public float Sensitivity;
	public float Velocity;
	public float Gravity;
	public float Range;

	public Vector2 OldPosition;

	void Start()
	{
		_player = GetComponent<Rigidbody2D>();

		Sensitivity = 2;
		Velocity = 0;
		Gravity = 0.8f;
		Range = 4;
	}

	private void Update()
	{
		MoveBee();
	}

	//private void OnCollisionEnter2D(Collision2D _collision)
	//{
	//	if (_collision.gameObject.CompareTag("Obstacle"))
	//	{
	//		GameManager.CanvasController.DisplayCanvasOnSummary();
	//	}
	//}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Score"))														// zdobyty punkt
		{
			GameManager.SetScore();
			if (GameManager.AchievementToUnlock())
			{
				Debug.Log("achievement unlocked");
				PlayerParticles.Play();
			}
		}

		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))		// stracone życie
		{
			GameManager.CanvasController.DisplayCanvasOnSummary();
		}
	}

	private void MoveBee()
	{
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(-5.0f, moveVertical * Sensitivity * Range);

		if (transform.position.y > OldPosition.y)											// jesli player jest aktualnie nad swoją poprzednią pozycją to znaczy, że się wzniosl
		{
			Debug.Log("====================== UP ==========================");	
			Velocity = 0.0f;																// zatem przyspieszenie jest zerowane
		}
		Velocity += Gravity * Time.deltaTime;												// przyspieszenie to iloczyn grawitacji i czasu
		movement.y -= Velocity;																// obniz playera wzgledem osi y na bazie wartosci przyspieszenia

		OldPosition.y = transform.position.y;												// uaktualnij zawartosc poprzedniej pozycji

		transform.position = movement;														// przemiesc playera o wyliczoną wartosc

		Debug.Log("OldPosition.y: " + OldPosition.y + " // transform.position.y: " + transform.position.y + " // Velocity: " + Velocity);

		//_player.AddForce(_movement * _speed);
	}
}



// gravity scale in inspector = 0.2
// instantiate'owanie prefabów Branch wyłączone 
