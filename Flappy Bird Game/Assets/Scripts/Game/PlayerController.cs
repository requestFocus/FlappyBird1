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
}
