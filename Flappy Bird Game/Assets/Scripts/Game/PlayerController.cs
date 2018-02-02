using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _player;
	private float _speed;
	private int _currentScore;

	public PlayerProfileController PlayerProfileController;
	public CanvasController CanvasController;
	//public GameManager GameManager;

	void Start()
	{
		_player = GetComponent<Rigidbody2D>();
		_speed = 5;

		CanvasController.gameObject.SetActive(false);
	}

	private void FixedUpdate()
	{
		MoveBee();
	}

	private void OnCollisionEnter2D(Collision2D _collision)
	{
		if (_collision.gameObject.CompareTag("Obstacle"))
		{
			CanvasController.DisplayCanvas();
			//SceneManager.LoadScene("Menu");
		}
	}

	private void OnTriggerEnter2D(Collider2D _collision)
	{
		if (_collision.gameObject.CompareTag("Obstacle"))
		{
			PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore += 1;
		}
	}

	private void MoveBee()
	{
		float _moveHorizontal = Input.GetAxis("Horizontal");
		float _moveVertical = Input.GetAxis("Vertical");

		Vector2 _movement = new Vector2(_moveHorizontal, _moveVertical);
		_player.AddForce(_movement * _speed);
	}
}


/*
 * na ten moment liczenie highscore'a nie ma sensu, bo 
 * dodaję 1 do aktualnego, a nie zaczynam od 0
 * w finalnej wersji dodam do sceny CurrentScore, który będzie wyświetlany po grze i 
 * zapamiętywany tylko, jeśli będzie większy od HighScore
 * 
 * jak zmieniać widoki? czy użyć tego samego mechanizmu, co w menu? 
 * jak to pogodzić z funkcjami Update(), FixedUpdate()?
 * 
 */ 

