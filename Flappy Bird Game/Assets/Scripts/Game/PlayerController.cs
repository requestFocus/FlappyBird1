using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D player;
	private float speed;

	void Start () {
		player = GetComponent<Rigidbody2D>();
		speed = 5;
	}

	private void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		player.AddForce(movement * speed);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			player.transform.position = new Vector2(-5.5f, 0.0f);
			player.transform.localScale += new Vector3(0.1f, 0.1f, 0.0f);		
			//Debug.Log("you lose");														// czemu to nie działa?
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			//player.transform.position = new Vector2(-5.5f, 0.0f);	
			player.transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);					// dla += Vector2 nie kompiluje się
			//Debug.Log("great!");															// czemu to nie działa?
		}

	}
}
