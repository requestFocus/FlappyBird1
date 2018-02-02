using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int _currentScore;

	public GameObject BranchPrefab;
	public CanvasController CanvasController;

	void Start()
	{
		InvokeRepeating("CreateObstacle", 2.0f, 3.0f);
	}

	void CreateObstacle()
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
}


// jak sprawić, by CanvasController był dostepny tylko z GameManagera