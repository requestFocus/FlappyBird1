using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _player;
	private float _speed;
	private int _currentScore;

	public PlayerProfileController PlayerProfileController;

	private void Awake()
	{
		//DontDestroyOnLoad((GameObject)PlayersProfiles.Instance.ListOfProfiles);
	}

	void Start()
	{
		_player = GetComponent<Rigidbody2D>();
		_speed = 5;

		//Debug.Log("Name: " + PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].PlayerName + " // " + "Highscore: " + PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore);
	}

	private void FixedUpdate()
	{
		float _moveHorizontal = Input.GetAxis("Horizontal");
		float _moveVertical = Input.GetAxis("Vertical");

		Vector2 _movement = new Vector2(_moveHorizontal, _moveVertical);
		_player.AddForce(_movement * _speed);
	}

	private void OnCollisionEnter2D(Collision2D _collision)
	{
		if (_collision.gameObject.CompareTag("Obstacle"))
		{
			//player.transform.position = new Vector2(-5f, 0.0f);
			//player.transform.localScale = new Vector2(1.0f, 1.0f);
			PlayerProfileController.SaveProfile(PlayersProfiles.Instance);							// zapisz wyniki przed powrotem do sceny MENU
			SceneManager.LoadScene("Menu");
		}
	}

	private void OnTriggerEnter2D(Collider2D _collision)
	{
		if (_collision.gameObject.CompareTag("Obstacle"))
		{
			//player.transform.localScale += new Vector3(0.1f, 0.1f, 0.0f);           // dla += new Vector2 nie kompiluje się
			PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore += 1;
			//Debug.Log("Highscore: " + PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].HighScore);
		}
	}
}


/*
 * na ten moment liczenie highscore'a nie ma sensu, bo 
 * dodaję 1 do aktualnego, a nie zaczynam od 0
 * w finalnej wersji dodam do sceny CurrentScore, który będzie wyświetlany po grze i 
 * zapamiętywany tylko, jeśli będzie większy od HighScore
 */ 