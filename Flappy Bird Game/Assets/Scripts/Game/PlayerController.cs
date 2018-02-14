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

	public Vector3 OldPosition;

	void Start()
	{
		_player = GetComponent<Rigidbody2D>();

		Sensitivity = 1.0f;
		Velocity = 0.0f;
		Gravity = 0.2f;
		Range = 1.0f;
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

		if (transform.position.y >= OldPosition.y)                                          // jesli player jest aktualnie nad swoją poprzednią pozycją to znaczy, że się wzniosl
		{
			Debug.Log("============================ UP // RESET ACCELERATION ==========================");
			Velocity = 0.0f;                                                                // zatem przyspieszenie jest zerowane
			
		}
		Velocity += Gravity * Time.deltaTime;                                               // przyspieszenie to iloczyn grawitacji i czasu

		movement.y -= Velocity;                                                             // obniz playera wzgledem osi y na bazie wartosci przyspieszenia

		OldPosition.y = transform.position.y;                                               // uaktualnij zawartosc poprzedniej pozycji
		transform.position = movement;                                                      // przemiesc playera o wyliczoną wartosc

		//string biggerthan = transform.position.y > OldPosition.y ? "wznosze sie" : "opadam";
		//Debug.Log("OldPosition.y: " + OldPosition.y + " // transform.position.y: " + transform.position.y + " // Velocity: " + Velocity);
		Debug.Log("transform.position.y: " + transform.position.y + " Velocity: " + Velocity + " // moveVertical: " + moveVertical + " // Time.deltaTime: " + Time.deltaTime);
	}
}



// gravity scale in inspector = 0.2
// instantiate'owanie prefabów Branch wyłączone 
//_player.AddForce(_movement * _speed);