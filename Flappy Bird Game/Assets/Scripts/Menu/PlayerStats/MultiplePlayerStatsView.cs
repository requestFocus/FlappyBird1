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

	private void Update()
	{
		FollowMouse();
	}

	public void ListPlayerWithStats(ProjectData projectData, Vector3 playerNamePos, Vector3 highscorePos, Vector3 achievementsPos)
	{
		FillTheListOfSingleEntries(projectData);

		for (int i = 0; i < 4; i++)
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
		if (Input.GetMouseButton(0) && Input.mousePosition.x > 260 && Input.mousePosition.x < 650 && Input.mousePosition.y < 350 && Input.mousePosition.y > 250)
			Debug.Log(Input.mousePosition.y);
	}
}

// lewy gorny 260, 350
// prawy gorny 655, 355
// lewy dolny 260, 250
// prawy dolny 655, 255
