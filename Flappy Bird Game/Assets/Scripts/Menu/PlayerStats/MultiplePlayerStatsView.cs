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

	private int _unitStep;
	private int _currentTopEntry;

	private void Start()
	{
		_playerNameLabel.text = "NAME";
		_highscoreLabel.text = "HIGHSCORE";
		_achievementsLabel.text = "ACHIEVEMENTS";

		_playerNameLabelPos = _playerNameLabel.transform.position;
		_highscoreLabelPos = _highscoreLabel.transform.position;
		_achievementsLabelPos = _achievementsLabel.transform.position;

		FillContainersOnStart();

		_currentTopEntry = 0;			// pozycja wyswietlana aktualnie jako PIERWSZA
	}

	private void Update()
	{
		FollowMouse();
	}

	public void CreateEmptyContainers()					// tyle ile kontenerów ma byc w hierarchii, widocznych oraz niewidocznych
	{
		for (int i = 0; i < 7; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);											// tworzy puste obiekty w hierarchii, ktore...
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);
			singlePlayerStatsViewInstance.name = "SinglePlayerViewInstance" + i;
			_listOfContainers.Add(singlePlayerStatsViewInstance);
		}
	}

	public void FillContainersOnStart()				// wypełnia tyle kontenerów, ile znajduje się w hierarchii
	{
		for (int i = 0; i < 7; i++)						//============= sprobuj zmieniac wartosci i wraz z pierwszym wyświetlanym aktualnie kontenerem. i = nr kontenera na szczycie, i < 7 + nr kontenera
		{
			_listOfContainers[i].CreateSinglePlayerStatsView(_projectData.EntireList[i], _playerNameLabelPos, _highscoreLabelPos, _achievementsLabelPos);       // ...nastepnie wypełnia danymi playera

			_playerNameLabelPos.y -= 30;
			_highscoreLabelPos.y -= 30;
			_achievementsLabelPos.y -= 30;
		}
	}

	private void FollowMouse()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_startPos = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0) && Input.mousePosition.x > 0 && Input.mousePosition.x < 800 && Input.mousePosition.y < 400 && Input.mousePosition.y > 0)
		{
			_delta = _startPos - Input.mousePosition;

			for (int i = 0; i < 7; i++)                                                         // przesuwa gorne elementy na dol, a dolne na gore
			{
				MoveDataFilledContainers(i);
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			_startPos = new Vector3(0, 0, 0);
		}
	}

	private void MoveDataFilledContainers(int index)
	{
		_unitStep = 210;

		_movement = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y - _delta.y / 10, 0);          // dziele przez X, żeby skok nie był tak duży
		_listOfContainers[index].transform.position = _movement;                                // przesuniecie kontenera we wskazanym kierunku
																							// sprawdz czy kontenery przekraczaja zadane granice i zareaguj
		if (_listOfContainers[index].PlayerName.transform.position.y > 350)                  // gorna granica listy, przesun pierwszy element na dol
		{
			_listOfContainers[index].transform.position = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y - _unitStep, 0);
			_currentTopEntry++;

			ReplaceProfile(index, (_currentTopEntry + 7 - 1));
		}
		else if (_listOfContainers[index].PlayerName.transform.position.y < 130)             // dolna granica listy, przesun ostatni element na gore
		{
			_listOfContainers[index].transform.position = new Vector3(_listOfContainers[index].transform.position.x, _listOfContainers[index].transform.position.y + _unitStep, 0);
			_currentTopEntry--;

			ReplaceProfile(index, _currentTopEntry);
		}
	}

	private void ReplaceProfile(int index, int currentTopEntry)
	{
		_listOfContainers[index].PlayerName.text = _projectData.EntireList[currentTopEntry].PlayerName;
		_listOfContainers[index].HighScore.text = _projectData.EntireList[currentTopEntry].HighScore.ToString();

		_listOfContainers[index].AchievementSingleEntryViewInstance.Complete10Active.gameObject.SetActive(false);
		_listOfContainers[index].AchievementSingleEntryViewInstance.Complete25Active.gameObject.SetActive(false);
		_listOfContainers[index].AchievementSingleEntryViewInstance.Complete50Active.gameObject.SetActive(false);

		if (_projectData.EntireList[currentTopEntry].Complete10)
			_listOfContainers[index].AchievementSingleEntryViewInstance.Complete10Active.gameObject.SetActive(true);
		if (_projectData.EntireList[currentTopEntry].Complete25)
			_listOfContainers[index].AchievementSingleEntryViewInstance.Complete25Active.gameObject.SetActive(true);
		if (_projectData.EntireList[currentTopEntry].Complete50)
			_listOfContainers[index].AchievementSingleEntryViewInstance.Complete50Active.gameObject.SetActive(true);
	}
}











// jeśli w kontenerze0 znajduje się pierwszy player i kontener0.transform.position.y > 350 to zablokuj modyfikacje jego transform.position.y w dół
// jeśli w kontenerze[index] znajduje się ostatni player i kontener[index].transform.position.y < 250 to zablokuj modyfikacje jego transform.position.y w górę 







// lewy gorny 260, 350
// prawy gorny 655, 355
// lewy dolny 260, 250
// prawy dolny 655, 255


// -210 podczas przesuniecia w dół

//Debug.Log(_delta.y);
//Debug.Log(_listOfSingleEntries[0].transform.position.y + " // " + _listOfSingleEntries[4].transform.position.y);
//Debug.Log(_listOfSingleEntries[0]._playerName.transform.position.y + " // " + _listOfSingleEntries[1]._playerName.transform.position.y + " // " + _listOfSingleEntries[2]._playerName.transform.position.y);
//Debug.Log(Input.mousePosition.x + " // " + Input.mousePosition.y);
