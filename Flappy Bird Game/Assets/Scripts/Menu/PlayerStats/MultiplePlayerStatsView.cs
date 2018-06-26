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

	private void Update()
	{
		FollowMouse();

		//Debug.Log(Input.mousePosition.x + " // " + Input.mousePosition.y);
	}

	public void ListPlayerWithStats(ProjectData projectData, Vector3 playerNamePos, Vector3 highscorePos, Vector3 achievementsPos)
	{
		FillTheListOfSingleEntries(projectData);

		for (int i = 0; i < 7; i++)
		{
			_listOfSingleEntries[i].CreateSinglePlayerStatsView(projectData.EntireList[i], playerNamePos, highscorePos, achievementsPos);

			playerNamePos.y -= 30;
			highscorePos.y -= 30;
			achievementsPos.y -= 30;
		}
	}

	private void FillTheListOfSingleEntries(ProjectData projectData)
	{
		for (int i = 0; i < projectData.EntireList.Count; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);
			_listOfSingleEntries.Add(singlePlayerStatsViewInstance);
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
			//Debug.Log(_delta.y);

			for (int i = 0; i < 7; i++)
			{
				if (_listOfSingleEntries[0].transform.position.y >= 300 || _listOfSingleEntries[4].transform.position.y <= 300)
				{
					Debug.Log(_listOfSingleEntries[0].transform.position.y + " // " + _listOfSingleEntries[4].transform.position.y);
					_movement = new Vector3(_listOfSingleEntries[i].transform.position.x, _listOfSingleEntries[i].transform.position.y - _delta.y, 0);
					_listOfSingleEntries[i].transform.position = _movement;
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
