using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class MultiplePlayerStatsView : MonoBehaviour
{
	[Inject]
	private DiContainer _container;

	[Inject]
	private SinglePlayerStatsView _singlePlayerStatsView;

	[Inject]
	private ProjectData _projectData;

	private List<SinglePlayerStatsView> _listOfContainers = new List<SinglePlayerStatsView>();

	[SerializeField] private Text _playerNameLabel;
	[SerializeField] private Text _highscoreLabel;
	[SerializeField] private Text _achievementsLabel;

	private Vector3 _playerNameLabelPos;
	private Vector3 _highscoreLabelPos;
	private Vector3 _achievementsLabelPos;

	private Vector3 _startPos;
	private Vector3 _delta;
	private Vector3 _movement;

	private int _containerGap;
	private int _currentTopEntry;
	private const int _scope = 7;
	private int _elementsToDisplayOnStart;											// playerów w pamięci może być mniej niż _scope, dlatego to jest ostateczna ilość playerów do wyswietlenia

	private void Start()
	{
		_playerNameLabel.text = "NAME";
		_highscoreLabel.text = "HIGHSCORE";
		_achievementsLabel.text = "ACHIEVEMENTS";

		_playerNameLabelPos = _playerNameLabel.transform.position;
		_highscoreLabelPos = _highscoreLabel.transform.position;
		_achievementsLabelPos = _achievementsLabel.transform.position;

		FillContainersOnStart();

		// initialize(LISTPREFAB);
		// LISTPREFAB.fillcontainersonstart(_projectData, _playerNameLabelPos, _highscoreLabelPos, _achievementsLabelPos);

		_currentTopEntry = 0;           // pozycja wyswietlana aktualnie jako PIERWSZA
	}

	private void Update()
	{
		FollowMouse();
	}

	// LISTPREFAB
	public void CreateEmptyContainers()					// tyle ile kontenerów ma byc w hierarchii, widocznych oraz niewidocznych
	{
		for (int i = 0; i < _scope; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);											// tworzy puste obiekty w hierarchii, ktore...
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);
			singlePlayerStatsViewInstance.name = "SinglePlayerViewInstance" + i;
			_listOfContainers.Add(singlePlayerStatsViewInstance);
		}
	}

	// LISTPREFAB
	public void FillContainersOnStart()				// wypełnia tyle kontenerów, ile znajduje się w hierarchii
	{
		if (_projectData.EntireList.Count < _scope)
			_elementsToDisplayOnStart = _projectData.EntireList.Count;
		else
			_elementsToDisplayOnStart = _scope;

		for (int i = 0; i < _elementsToDisplayOnStart; i++)						
		{
			_listOfContainers[i].CreateSinglePlayerStatsView(_projectData.EntireList[i], _playerNameLabelPos, _highscoreLabelPos, _achievementsLabelPos);       // ...nastepnie wypełnia danymi playera

			_playerNameLabelPos.y -= 30;
			_highscoreLabelPos.y -= 30;
			_achievementsLabelPos.y -= 30;
		}
	}

	// LISTPREFAB
	private void FollowMouse()
	{
		if (_projectData.EntireList.Count > _scope)						// jeśli playerów na liście jest mniej niż kontenerów to nie ma sensu w ogóle odpalać Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				_startPos = Input.mousePosition;
			}
			else if (Input.GetMouseButton(0) && Input.mousePosition.x > 0 && Input.mousePosition.x < 800 && Input.mousePosition.y < 400 && Input.mousePosition.y > 0)
			{
				_delta = _startPos - Input.mousePosition;

				for (int i = 0; i < _scope; i++)                                                         
				{
					MoveDataFilledContainers(i);
				}
			}
			else if (Input.GetMouseButtonUp(0))
			{
				_startPos = new Vector3(0, 0, 0);
			}
		}
	}

	// LISTPREFAB
	// zamiast przerzucać tylko te elementy, ktore przekraczają krawędzie, zrobic to tak, ze jesli kontener zostaje przesuniety na gore/dol, CAŁA lista jest nadpisywana wg zakresu
	// np. 0-6, 1-7, 2-8, 3-9, wczytanie nowego zakresu nalezy sprawdzac przed ruchem myszki i przesunieciem kontenera
	private void MoveDataFilledContainers(int index)
	{
		_containerGap = 210;

		_movement = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y - _delta.y / 10, 0);          // dziele przez X, żeby skok nie był tak duży
		_listOfContainers[index].transform.position = _movement;                             // przesuniecie kontenera we wskazanym kierunku

		if (_listOfContainers[index].PlayerName.transform.position.y > 350)                  // gorna granica listy, przesun pierwszy element na dol
		{
			_listOfContainers[index].transform.position = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y - _containerGap, 0);
			ReplaceProfile(index, (_currentTopEntry + _scope));
			_currentTopEntry++;
		}
		else if (_listOfContainers[index].PlayerName.transform.position.y < 140)             // dolna granica listy, przesun ostatni element na gore
		{
			_currentTopEntry--;
			ReplaceProfile(index, _currentTopEntry);
			_listOfContainers[index].transform.position = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y + _containerGap, 0);
		}
	}

	// LISTPREFAB
	private void ReplaceProfile(int index, int entryToReplace)
	{
		entryToReplace = LoopListIndex(entryToReplace);

		_listOfContainers[index].PlayerName.text = _projectData.EntireList[entryToReplace].PlayerName;

		_listOfContainers[index].HighScore.text = _projectData.EntireList[entryToReplace].HighScore.ToString();

		_listOfContainers[index].AchievementSingleEntryViewInstance.Complete10Active.gameObject.SetActive(false);
		_listOfContainers[index].AchievementSingleEntryViewInstance.Complete25Active.gameObject.SetActive(false);
		_listOfContainers[index].AchievementSingleEntryViewInstance.Complete50Active.gameObject.SetActive(false);

		if (_projectData.EntireList[entryToReplace].Complete10)
		{
			_listOfContainers[index].AchievementSingleEntryViewInstance.Complete10Active.gameObject.SetActive(true);

			if (_projectData.EntireList[entryToReplace].Complete25)
			{
				_listOfContainers[index].AchievementSingleEntryViewInstance.Complete25Active.gameObject.SetActive(true);

				if (_projectData.EntireList[entryToReplace].Complete50)
				{
					_listOfContainers[index].AchievementSingleEntryViewInstance.Complete50Active.gameObject.SetActive(true);
				}
			}

		}
	}

	// LISTPREFAB
	private int LoopListIndex(int entryToReplace)
	{
		if (entryToReplace >= _projectData.EntireList.Count)
		{
			entryToReplace = entryToReplace % _projectData.EntireList.Count;
		}
		else if (entryToReplace < 0)
		{
			entryToReplace = _projectData.EntireList.Count - Mathf.Abs(entryToReplace % _projectData.EntireList.Count);

			if (entryToReplace == _projectData.EntireList.Count)
				entryToReplace = 0;
		}

		return entryToReplace;
	}
}
