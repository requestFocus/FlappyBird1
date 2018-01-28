﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D player;
	private float speed;

	void Start () {
		player = GetComponent<Rigidbody2D>();
		speed = 5;

		//Debug.Log(PlayersProfiles.Instance.ListOfProfiles[0].PlayerName + " // " + PlayersProfiles.Instance.ListOfProfiles[0].HighScore);
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
			player.transform.position = new Vector2(-5f, 0.0f);
			player.transform.localScale = new Vector2(1.0f, 1.0f);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Obstacle"))
		{
			player.transform.localScale += new Vector3(0.1f, 0.1f, 0.0f);           // dla += new Vector2 nie kompiluje się
		}
	}
}
