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

	void Start()
	{
		_player = GetComponent<Rigidbody2D>();
		_speed = 5;

		Sensitivity = 30;
	}

	private void Update()
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
			GameManager.SetScore();
			if (GameManager.AchievementToUnlock())
			{
				Debug.Log("achievement unlocked");
				// tu będzie kod od particli
				PlayerParticles.Play();
			}
		}
	}

	private void MoveBee()
	{
		float _moveVertical = Input.GetAxis("Vertical");
		Vector2 _movement = new Vector2(-5, _moveVertical);

		//_player.transform.position = _movement;
		_player.AddForce(_movement * _speed);
	}
}

/*
 * czy fakt, że używam transform dla mojego rigidbody
 * sprawia, że ten rigidbody musi byc KINEMATIC (DYNAMIC wymaga użycia fizyki)
 * a ew. collider dla innego gameObjectu musi byc opisany skryptem?
 */


// gravity scale in inspector = 0.2
// instantiate'owanie prefabów Branch wyłączone 
