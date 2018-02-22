using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject BranchPrefab;
	public CanvasController CanvasController;

	private int _currentScore;
	private float _timeIntervalForCoroutine;
	private float _intervalStep;

	private enum _intervalLockItems
	{
		Locked,
		Unlocked
	};
	private _intervalLockItems _intervalLock;

	private void Start()
	{
		_intervalLock = _intervalLockItems.Unlocked;
		_intervalStep = 0.3f;
		SetTimeIntervalForCoroutine(3.0f);

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
			yield return new WaitForSeconds(CalculateTimeIntervalForObstacles());
			//Debug.Log("PREFAB");
			Instantiate(BranchPrefab);
		}
	}


	public void SetScore()
	{
		_currentScore++;
		_intervalLock = _intervalLockItems.Locked;
	}



	public int GetScore()
	{
		return _currentScore;
	}



	public float CalculateTimeIntervalForObstacles()
	{
		if (GetScore() != 0 && GetScore() % 10 == 0 && GetTimeIntervalForCoroutine() > 1.0f && _intervalLock == _intervalLockItems.Locked)
		{
			SetTimeIntervalForCoroutine(GetTimeIntervalForCoroutine() - _intervalStep);

			//Debug.Log("GetScore(): " + GetScore() + " // GetTimeIntervalForCoroutine(): " + GetTimeIntervalForCoroutine() + " // lockInterval: " + _lockInterval);
		}
		_intervalLock = _intervalLockItems.Unlocked;
		return _timeIntervalForCoroutine;
	}



	public float GetTimeIntervalForCoroutine()
	{
		return _timeIntervalForCoroutine;
	}


	public void SetTimeIntervalForCoroutine(float interval)
	{
		_timeIntervalForCoroutine = interval;
	}

	//private float[] _intervals;
	//private int _i;
	//_intervals = new float[] { 2.7f, 2.4f, 2.1f, 1.8f, 1.5f, 1.2f, 0.9f, 0.6f };
	//i = 0;
	//if (GetScore() != 0 && GetScore() % 3 == 0 && i < _intervals.Length && _timeIntervalForCoroutine >= 1.0f)
	//_decreasingInterval = _intervals[i++];


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


