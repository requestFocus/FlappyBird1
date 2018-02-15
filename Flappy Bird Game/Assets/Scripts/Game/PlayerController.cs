using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public GameManager GameManager;
	public ParticleSystem PlayerParticles;

	public float Sensitivity;
	public float Velocity;
	public float Gravity;
	public float Range;

	public float Acceleration;
	public float MoveVertical;

	public Vector2 OldPosition;
	public Vector2 GravityMovement;
	public Vector2 BeeMovement;

	public Vector2 Movement;
	public int Flag;

	void Start()
	{
		Sensitivity = 22f;
		Velocity = 0.0f;
		Gravity = 20f;
		Flag = 0;

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
		MoveVertical = Input.GetAxis("Vertical");

		if (Input.GetKeyUp("s") || (Input.GetKeyUp("w")))
		{
			Input.ResetInputAxes();
		}

		BeeMovement = Vector2.up * MoveVertical * Time.deltaTime * Sensitivity;

		Velocity = Gravity * Time.deltaTime;
		GravityMovement = Vector2.down * Velocity * Time.deltaTime;

		Debug.Log("MoveVertical: " + MoveVertical + " // Velocity: " + Velocity + " // Time.deltaTime: " + Time.deltaTime + " //// " + "BeeMovement.y: " + BeeMovement.y + " + GravityMovement.y: " + GravityMovement.y + " = Movement.y: " + Movement.y);

		Movement = BeeMovement + GravityMovement;
		transform.Translate(Movement);
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