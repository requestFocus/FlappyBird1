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

	private List<SinglePlayerStatsView> _listOfSingleEntries = new List<SinglePlayerStatsView>();

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

	private void Start()
	{
		_playerNameLabel.text = "NAME";
		_highscoreLabel.text = "HIGHSCORE";
		_achievementsLabel.text = "ACHIEVEMENTS";

		_playerNameLabelPos = _playerNameLabel.transform.position;
		_highscoreLabelPos = _highscoreLabel.transform.position;
		_achievementsLabelPos = _achievementsLabel.transform.position;

		FillContainersWithData();
	}

	private void Update()
	{
		FollowMouse();
	}

	public void CreateEmptyContainers() 
	{
		for (int i = 0; i < 7; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);											// tworzy puste obiekty w hierarchii, ktore...
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);
			singlePlayerStatsViewInstance.name = "SinglePlayerViewInstance" + i;
			_listOfSingleEntries.Add(singlePlayerStatsViewInstance);
		}
	}

	public void FillContainersWithData()
	{
		for (int i = 0; i < 7; i++)						//============= sprobuj zmieniac wartosci i wraz z pierwszym wyświetlanym aktualnie kontenerem. i = nr kontenera na szczycie, i < 7 + nr kontenera
		{
			_listOfSingleEntries[i].CreateSinglePlayerStatsView(_projectData.EntireList[i], _playerNameLabelPos, _highscoreLabelPos, _achievementsLabelPos);       // ...nastepnie wypełnia danymi playera

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
		else if (Input.GetMouseButton(0) && Input.mousePosition.x > 260 && Input.mousePosition.x < 650 && Input.mousePosition.y < 350 && Input.mousePosition.y > 250)
		{
			_delta = _startPos - Input.mousePosition;

			for (int i = 0; i < 7; i++)																// przesuwa gorne elementy na dol, a dolne na gore
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

		_movement = new Vector3(_listOfSingleEntries[index].transform.position.x, _listOfSingleEntries[index].transform.position.y - _delta.y / 10, 0);          // dziele przez X, żeby skok nie był tak duży
		_listOfSingleEntries[index].transform.position = _movement;

		if (_listOfSingleEntries[index].playerName.transform.position.y > 350)                  // gorna granica listy
		{
			_listOfSingleEntries[index].transform.position = new Vector3(_listOfSingleEntries[index].transform.position.x, _listOfSingleEntries[index].transform.position.y - _unitStep, 0);
		}
		else if (_listOfSingleEntries[index].playerName.transform.position.y < 130)         // dolna granica listy
		{
			_listOfSingleEntries[index].transform.position = new Vector3(_listOfSingleEntries[index].transform.position.x, _listOfSingleEntries[index].transform.position.y + _unitStep, 0);
		}
	}
}








// lewy gorny 260, 350
// prawy gorny 655, 355
// lewy dolny 260, 250
// prawy dolny 655, 255


// -210 podczas przesuniecia w dół

//Debug.Log(_delta.y);
//Debug.Log(_listOfSingleEntries[0].transform.position.y + " // " + _listOfSingleEntries[4].transform.position.y);
//Debug.Log(_listOfSingleEntries[0]._playerName.transform.position.y + " // " + _listOfSingleEntries[1]._playerName.transform.position.y + " // " + _listOfSingleEntries[2]._playerName.transform.position.y);
//Debug.Log(Input.mousePosition.x + " // " + Input.mousePosition.y);
