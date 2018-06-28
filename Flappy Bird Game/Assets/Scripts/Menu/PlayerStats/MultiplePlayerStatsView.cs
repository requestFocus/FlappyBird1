using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MultiplePlayerStatsView : MonoBehaviour
{
	[Inject]
	private DiContainer _container;

	[Inject]
	private SinglePlayerStatsView _singlePlayerStatsView;

	private List<SinglePlayerStatsView> _listOfSingleEntries = new List<SinglePlayerStatsView>();

	private Vector3 _startPos;
	private Vector3 _delta;
	private Vector3 _movement;

	private int _unitStep;

	private void Update()
	{
		FollowMouse();
	}

	public void ListPlayerWithStats(ProjectData projectData, Vector3 playerNamePos, Vector3 highscorePos, Vector3 achievementsPos) 
	{
		for (int i = 0; i < 7; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);											// tworzy puste obiekty w hierarchii, ktore...
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);
			singlePlayerStatsViewInstance.name = "SinglePlayerViewInstance" + i;
			_listOfSingleEntries.Add(singlePlayerStatsViewInstance);

			_listOfSingleEntries[i].CreateSinglePlayerStatsView(projectData.EntireList[i], playerNamePos, highscorePos, achievementsPos);		// ...nastepnie wypełnia danymi playera

			playerNamePos.y -= 30;
			highscorePos.y -= 30;
			achievementsPos.y -= 30;
		}
	}

	private void FollowMouse()
	{
		_unitStep = 210;

		if (Input.GetMouseButtonDown(0))
		{
			_startPos = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0) && Input.mousePosition.x > 260 && Input.mousePosition.x < 650 && Input.mousePosition.y < 350 && Input.mousePosition.y > 250)
		{
			_delta = _startPos - Input.mousePosition;

			for (int i = 0; i < 7; i++)																// przesuwa gorne elementy na dol, a dolne na gore
			{
				_movement = new Vector3(_listOfSingleEntries[i].transform.position.x, _listOfSingleEntries[i].transform.position.y - _delta.y / 10, 0);          // dziele przez X, żeby skok nie był tak duży
				_listOfSingleEntries[i].transform.position = _movement;

				if (_listOfSingleEntries[i].playerName.transform.position.y > 350)					// gorna granica listy
				{
					_listOfSingleEntries[i].transform.position = new Vector3(_listOfSingleEntries[i].transform.position.x, _listOfSingleEntries[i].transform.position.y - _unitStep, 0);
					Debug.Log("myszka w gore, lista w dol, pokazuje nizsze pozycje");
					// każdy obiekt singleEntry przesuniety na dol, pobiera z listy dane kolejnego playera
				}
				else if (_listOfSingleEntries[i].playerName.transform.position.y < 130)			// dolna granica listy
				{
					_listOfSingleEntries[i].transform.position = new Vector3(_listOfSingleEntries[i].transform.position.x, _listOfSingleEntries[i].transform.position.y + _unitStep, 0);
					Debug.Log("myszka w dół, lista w gore, pokazuje wyzsze pozycje");
					// każdy obiekt singleEntry przesuniety na gore, pobiera z listy dane poprzedniego playera
				}
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			_startPos = new Vector3(0, 0, 0);
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
