using System.Collections;
using UnityEngine;
using Zenject;

public class ColumnManager : MonoBehaviour
{
	[Inject]
	private ColumnView _column;                 // powstało jako FromInstance, jest to tylko prefab, a nie INSTANCJA, dopiero w CreateColumn() następuje instantiate'owanie tego prefaba

	[Inject]
	private DiContainer _container;

	[Inject]
	private IntervalAvailabilityStatesService _intervalAvailabilityStatesService;

    private float _timeIntervalForCoroutine;
	private float _yPosition;

	private const float _intervalStep = 0.3f;                                 // o ile zmniejszany jest interwał czasowy między kolejnymi kolumnami
	private const float _startXPosition = 10.5f;                                // tutaj następuje instantiate kolumny
	private const float _minRange = -3.0f;
	private const float _maxRange = 3.0f;

	private int _columnsSoFar;

    private GUIGamePlayView GUIGamePlayView;

    private void Start()
	{
		_timeIntervalForCoroutine = 4.0f;                                     // 3.0f jako wartosc startowa, wartość ta jest systematycznie zmniejszana, az osiągnie minimalną grywalną wartość 1.0f
        StartCoroutine(CreateColumn());

        GUIGamePlayView = FindObjectOfType<GUIGamePlayView>();
        GUIGamePlayView.OnLifeLostDel += DeleteColumnManager;
}

	private float CalculateTimeIntervalForObstacles()
	{
		if (_columnsSoFar != 0 && _columnsSoFar % 10 == 0 && _timeIntervalForCoroutine > 1.0f && _intervalAvailabilityStatesService.IntervalLock == IntervalAvailabilityStatesService.IntervalLockStates.Locked)
		{
			_timeIntervalForCoroutine = _timeIntervalForCoroutine - _intervalStep;
		}
		_intervalAvailabilityStatesService.IntervalLock = IntervalAvailabilityStatesService.IntervalLockStates.Unlocked;
		return _timeIntervalForCoroutine;
	}

	private IEnumerator CreateColumn()
	{
        while (true)
		{
            yield return new WaitForSeconds(CalculateTimeIntervalForObstacles());
            ColumnView column = Instantiate<ColumnView>(_column);
            _container.Inject(column);
            InitializeColumn(column);
            _columnsSoFar++;
        }
    }   

	private void InitializeColumn(ColumnView column)
	{
		column.gameObject.SetActive(true);
		_yPosition = Random.Range(_minRange, _maxRange);
		column.transform.position = new Vector3(_startXPosition, _yPosition);
	}

    private void DeleteColumnManager()
    {
        Destroy(gameObject);
    }
}

