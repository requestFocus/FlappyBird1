using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	//private Rigidbody2D _player;
	//public PlayerProfileController PlayerProfileController;
	public GameManager GameManager;

	public ParticleSystem PlayerParticles;

	public float Sensitivity;
	public float Velocity;
	public float Gravity;
	public float Range;

	public float Acceleration;
	//public float MoveVertical;

	public Vector2 OldPosition;
	public Vector2 GravityMovement;
	public Vector2 BeeMovement;

	public Vector2 Movement;

	void Start()
	{
		//_player = GetComponent<Rigidbody2D>();

		Sensitivity = 1f;
		Velocity = 0.0f;
		Gravity = 1f;
		Range = 5.0f;

		GravityMovement = new Vector2(0.0f, 0.0f);
		BeeMovement = new Vector2(-5.0f, 0.0f);
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
			if (GameManager.AchievementToUnlock())
			{
				Debug.Log("achievement unlocked");
				PlayerParticles.Play();
			}
		}

		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))     // stracone życie
		{
			GameManager.CanvasController.DisplayCanvasOnSummary();
		}
	}

	//private void MoveBee()
	//{
	//	float MoveVertical = Input.GetAxis("Vertical");

	//	if (transform.position.y > OldPosition.y)                                                // jesli player jest aktualnie nad swoją poprzednią pozycją to znaczy, że się wzniosl
	//	{
	//		Debug.Log("============================ UP => RESET ACCELERATION ==========================");
	//		Velocity = 0.0f;                                                           
	//		GravityMovement.y = 0.0f;                                                           // zatem przyspieszenie (a dokładniej - polozenie playera wzgledem osi y na bazie wartosci przyspieszenia) jest zerowane
	//	}

	//	Velocity = Gravity * Time.deltaTime;                                                   // predkosc to iloczyn grawitacji i czasu trwania klatki
	//	GravityMovement.y -= Velocity;                                                             // wylicz polozenie playera wzgledem osi y na bazie wartosci prędkości

	//	BeeMovement.y = MoveVertical * Range;

	//	OldPosition.y = transform.position.y;                                                    // uaktualnij zawartosc poprzedniej pozycji

	//	transform.position = BeeMovement + GravityMovement;                                     // przemiesc playera o wyliczoną wartosc
	//																							transform.position = BeeMovement;													   // przemiesc playera o wyliczoną wartosc BEZ grawitacji
	//																							transform.position = GravityMovement;													  // przemiesc playera o wyliczoną wartosc WYŁĄCZNIE grawitacja
	//	Debug.Log("odczyt z klawiatury: " + MoveVertical + " // BeeMovement.y: " + BeeMovement.y + " + GravityMovement.y: " + GravityMovement.y + " = finalna pozycja Y: " + transform.position.y);
	//}

	private void MoveBee()
	{
		float MoveVertical = Input.GetAxis("Vertical");




	}
}

/*
 * faktyczne przyspieszenie to suma grawitacji (przyspieszenia ziemskiego) i przyspieszenia pionowego wynikającego z naciśnięcia strzałki
 * delta ruchu (przebytej drogi) to iloczyn prędkości i czasu
 * prędkość naliczana jest jako iloczyn przyspieszenia i czasu
 * 
 * delta ruchu to wektor bedący argumentem dla Translate
 */ 

// gravity scale in inspector = 0.2
// instantiate'owanie prefabów Branch wyłączone 
//_player.AddForce(_movement * _speed);