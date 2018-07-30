using UnityEngine;

public class PlayerView : MonoBehaviour
{
	private float _sensitivity;
	private float _velocity;
	private float _gravity;
	private float _moveVertical;
	private Vector2 _gravityMovement;
	private Vector2 _playerMovement;
	private Vector2 _mergedMovement;

    private Vector3 _startPos;
    private Vector3 _delta;

    private GUIGamePlayView GUIGamePlayView;

	private void Start()
	{
		GUIGamePlayView = FindObjectOfType<GUIGamePlayView>();
		GUIGamePlayView.OnLifeLostDel += DeletePlayerView;
	}

	private void Update()
	{
        MovePlayer();
        //MovePlayerWithMouse();
    }

	private void OnTriggerEnter2D(Collider2D collision)            
	{
		GUIGamePlayView.PointEarned(collision);
		GUIGamePlayView.LifeLost(collision);
	}

	private void DeletePlayerView()
	{
		Destroy(gameObject);
	}

    private void MovePlayer()                                                   // PLAYER SERVICE                         
    {
        _sensitivity = 12f;
        _gravity = 3f;

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
        transform.Translate(_mergedMovement);                                                   // przesuniecie o sume wektorów
    }

    private void MovePlayerWithMouse()                                                               
    {
        _sensitivity = 0.05f;
        _gravity = 5f;

        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Input.mousePosition;
            //_velocity = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            _delta = _startPos - Input.mousePosition;

            _playerMovement = Vector2.up * _delta.y * Time.deltaTime * _sensitivity;           // wyliczenie wektora ruchu playera na bazie Input.mousePosition
            transform.Translate(_playerMovement);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _startPos = Vector3.zero;
            _velocity = 0;
        }

        _velocity += _gravity * Time.deltaTime;                                         // predkosc opadania jako iloczyn grawitacji (przyspieszenia) i czasu
        _gravityMovement = Vector2.down * _velocity * Time.deltaTime;                       // wyliczenie wektora przyspieszenia

        _mergedMovement = _playerMovement + _gravityMovement;                                       // suma wektorów ruchu i opadania
        transform.Translate(_mergedMovement);                                                   // przesuniecie o sume wektorów

        Debug.Log(_delta.y + " // " + _playerMovement.y + " // " + _gravityMovement.y + " // " + _mergedMovement.y);
    }
}
