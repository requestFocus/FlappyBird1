using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MultiplePlayerStatsView : MonoBehaviour
{
	[Inject]
	private DiContainer _container;

	[Inject]
	private SinglePlayerStatsView _singlePlayerStatsView;

	public void ListPlayerWithStats(ProjectData projectData, Vector3 playerNamePos, Vector3 highscorePos, Vector3 achievementsPos)
	{
		for (int i = 0; i < projectData.EntireList.Count; i++)
		{
			SinglePlayerStatsView singlePlayerStatsViewInstance = Instantiate(_singlePlayerStatsView);
			_container.Inject(singlePlayerStatsViewInstance);
			singlePlayerStatsViewInstance.transform.SetParent(gameObject.transform);
			singlePlayerStatsViewInstance.name = "Entry" + i;

			singlePlayerStatsViewInstance.CreateSinglePlayerStatsView(projectData.EntireList[i], playerNamePos, highscorePos, achievementsPos);

			playerNamePos.y -= 30;
			highscorePos.y -= 30;
			achievementsPos.y -= 30;
		}
	}
}
