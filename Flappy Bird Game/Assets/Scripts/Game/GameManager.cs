using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject BranchPrefab;
	public CanvasController CanvasController;

	private int _currentScore;

	private void Start()
	{
		InvokeRepeating("CreateObstacle", 3.0f, 3.0f);
	}

	/*
	 * w hierarchy managerze znajduje się prefab Branch, aktualnie jest nieaktywny, 
	 * sluży jako podgląd dla prefaba w przypadku ew. zmian,
	 * z wersji finalnej zostanie USUNIĘTY
	 */



	private void CreateObstacle()
	{
		Instantiate(BranchPrefab);
	}



	public void SetScore()
	{
		_currentScore++;
	}



	public int GetScore()
	{
		return _currentScore;
	}



	//public float AccelerateBranch()
	//{
	//	if (GetScore() % 5 == 0)
	//	{
	//		BranchAcceleration += 50;
	//		Debug.Log("przyspieszamy");
	//	}

	//	return BranchAcceleration;
	//}



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


// jak sprawić, by CanvasController był dostepny tylko z GameManagera