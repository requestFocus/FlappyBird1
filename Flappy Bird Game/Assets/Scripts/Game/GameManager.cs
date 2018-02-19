using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject BranchPrefab;
	public CanvasController CanvasController;

	private int _currentScore;
	private float _decreasingInterval;

	private float[] _intervals;
	private int i;

	private void Start()
	{
		_decreasingInterval = 3.0f;
		_intervals = new float[] { 3.0f, 2.5f, 2.0f, 1.5f, 1.0f, 0.5f };
		i = 0;

		StartCoroutine(CreateObstacle());                                           //InvokeRepeating("CreateObstacle", 3.0f, 3.0f);
	}

	/*
	 * w hierarchy managerze znajduje się prefab Branch, aktualnie jest nieaktywny, 
	 * sluży jako podgląd dla prefaba w przypadku ew. zmian,
	 * z wersji finalnej zostanie USUNIĘTY
	 */

	private IEnumerator CreateObstacle()
	{
		while (true)
		{
			yield return new WaitForSeconds(ObstacleTTL());
			Instantiate(BranchPrefab);
		}
	}


	public void SetScore()
	{
		_currentScore++;
	}



	public int GetScore()
	{
		return _currentScore;
	}



	public float ObstacleTTL()
	{
		if (GetScore() != 0 && GetScore() % 10 == 0 && i < _intervals.Length)
		{
			_decreasingInterval = _intervals[i++];
		}

		return _decreasingInterval;
	}



	public bool AchievementToUnlock()
	{
		if (GetScore() == 10)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete10)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete10 = true;
				return true;
			}
		}
		if (GetScore() == 25)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete25)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete25 = true;
				return true;
			}
		}
		if (GetScore() == 50)
		{
			if (!PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete50)   // nie ma jeszcze achievementu
			{
				PlayersProfiles.Instance.ListOfProfiles[PlayersProfiles.Instance.CurrentProfile].Complete50 = true;
				return true;
			}
		}

		return false;                                                                                       // brak achievementu do odblokowania, już posiada wszystko, co się należy
	}
}


