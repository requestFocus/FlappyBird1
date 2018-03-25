using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoBehaviour
{
	// PLAYER
	private float _sensitivity;
	private float _velocity;
	private float _gravity;
	private float _moveVertical;
	private Vector2 _gravityMovement;
	private Vector2 _playerMovement;
	private Vector2 _mergedMovement;

	private int _currentScore;
	public int CurrentScore
	{
		get { return _currentScore; }
		set
		{
			_currentScore = value;
			IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Locked;
		}
	}
	private float _timeIntervalForCoroutine;                              
	private const float _intervalStep = 0.3f;

	// COLUMN
	public GameObject ColumnPrefab;

	private const float _startXPosition = 8.0f;
	private const float _endXPosition = -8.0f;
	private const float _acceleration = 5.0f;
	private const float _minRange = -3.0f;
	private const float _maxRange = 3.0f;
	private float _yPosition;

	// BACKGROUND
	private const float _horizontalMove = 0.05f;
	private const float _speed = 3.0f;
	private const float _rightEdge1 = -11.723f;
	private const float _rightEdge2 = 6.68f;

	[SerializeField] private ParticleSystem AchievementParticles;
	[SerializeField] private GUIGamePlayView GUIGamePlayView;
	[SerializeField] private GUISummaryView GUISummaryView;

	[SerializeField] private GUIService GUIService;

	private void Start()
	{
		_sensitivity = 12f;
		_velocity = 0.0f;
		_gravity = 3f;

		_playerMovement = new Vector2(0.0f, 0.0f);

		_timeIntervalForCoroutine = 3.0f;                                            // 3.0f jako wartosc startowa
		StartCoroutine(CreateObstacle());                                           //InvokeRepeating("CreateObstacle", 3.0f, 3.0f);
	}



	public void MovePlayer(PlayerView player)                                                   // wyniesienie tego do serwisu bedzie wymagało monobehaviour, co będzie problemem przy prefabach                            
	{
		_moveVertical = Input.GetAxis("Vertical");

		if (Input.GetKeyUp("s") || Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			Input.ResetInputAxes();                                                     // reset wartosci getinputaxis, player moze podskoczyc po osiagnieciu wartosci 1
			_velocity = 0;                                                              // reset predkosci po wzbiciu sie w gore, player znow zaczyna opadać z predkoscia poczatkowa 0
		}

		_playerMovement = Vector2.up * _moveVertical * Time.deltaTime * _sensitivity;           // wyliczenie wektora ruchu playera na bazie Input.GetAxis()

		_velocity += _gravity * Time.deltaTime;                                         // predkosc jako iloczyn grawitacji (przyspieszenia) i czasu
		_gravityMovement = Vector2.down * _velocity * Time.deltaTime;                       // wyliczenie wektora przyspieszenia

		_mergedMovement = _playerMovement + _gravityMovement;                                       // suma wektorów ruchu i opadania
		player.transform.Translate(_mergedMovement);                                                   // przesuniecie o sume wektorów
	}



	public void PointEarned(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Score"))                                                       // zdobyty punkt
		{
			CurrentScore += 1;
			if (AchievementToUnlock())
			{
				AchievementParticles.Play();
				StartCoroutine(GUIGamePlayView.AchievementUnlockedNotification());
			}
		}
	}



	public void LifeLost(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))          // stracone życie
		{
			CurrentGameStateService.CurrentGameState = CurrentGameStateService.GameStates.Summary;
		}
	}



	public bool AchievementToUnlock()                                   // weryfikuje i przyznaje achievementy, musi miec dane z modelu
	{
		if (CurrentScore == 10)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete10)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete10 = true;
				return true;
			}
		}
		if (CurrentScore == 25)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete25)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete25 = true;
				return true;
			}
		}
		if (CurrentScore == 50)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete50)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete50 = true;
				return true;
			}
		}

		return false;                                                                                       // brak achievementu do odblokowania, już posiada wszystko, co się należy
	}



	public float CalculateTimeIntervalForObstacles()                    // SERWIS COLUMNY+PLAYERA, wylicza (skraca) czas między pojawianiem się kolejnych przeszkód
	{
		if (CurrentScore != 0 && CurrentScore % 10 == 0 && _timeIntervalForCoroutine > 1.0f && IntervalAvailabilityStatesService.IntervalLock == IntervalAvailabilityStatesService.IntervalLockStates.Locked)
		{
			_timeIntervalForCoroutine = _timeIntervalForCoroutine - _intervalStep;
		}
		IntervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Unlocked;
		return _timeIntervalForCoroutine;
	}



	public IEnumerator CreateObstacle()
	{
		while (true)
		{
			yield return new WaitForSeconds(CalculateTimeIntervalForObstacles());
			Instantiate(ColumnPrefab);
		}
	}



	public bool MoveColumn(ColumnView column)                                       // SERWIS COLUMNY+PLAYERA									
	{
		if (column.transform.position.x <= _startXPosition && column.transform.position.x >= _endXPosition)
		{
			column.transform.position += (Vector3.left * Time.deltaTime * _acceleration);
			return false;
		}
		else
		{
			return true;
		}
	}


	public void InitializeColumn(ColumnView column)
	{
		_yPosition = Random.Range(_minRange, _maxRange);

		column.transform.position = new Vector3(_startXPosition, _yPosition);
	}



	public void MoveBackground(BackgroundGameView background)
	{
		if (background.transform.position.x >= _rightEdge1 && background.transform.position.x < _rightEdge2)
		{
			background.transform.position += (new Vector3(_horizontalMove, 0.0f, 0.0f) * Time.deltaTime * _speed);
		}
		else
		{
			background.transform.position = new Vector2(_rightEdge1, 0.0f);
		}
	}
}
