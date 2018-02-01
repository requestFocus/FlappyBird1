using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject BranchPrefab;
	
	void Start()
	{
		InvokeRepeating("CreateObstacle", 2.0f, 3.0f);
	}

	void CreateObstacle()
	{
		Instantiate(BranchPrefab);
	}
}
