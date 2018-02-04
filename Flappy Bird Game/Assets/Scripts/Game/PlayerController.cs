using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _player;
	private float _speed;

	public PlayerProfileController PlayerProfileController;
	public GameManager GameManager;

	void Start()
	{
		_player = GetComponent<Rigidbody2D>();
		_speed = 5;
	}

	private void FixedUpdate()
	{
		MoveBee();
	}

	private void OnCollisionEnter2D(Collision2D _collision)
	{
		if (_collision.gameObject.CompareTag("Obstacle"))
		{
			GameManager.CanvasController.DisplayCanvasOnSummary();
		}
	}

	private void OnTriggerEnter2D(Collider2D _collision)
	{
		if (_collision.gameObject.CompareTag("Obstacle"))
		{
			//PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore += 1;
			GameManager.SetScore();
			if (GameManager.AchievementToUnlock())
			{
				Debug.Log("achievement COMPLETE10 unlocked!");
			}
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



