using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
	[SerializeField] private LevelService LevelService;

	private void Update()
	{
		LevelService.MovePlayer(this);
	} 

	private void OnTriggerEnter2D(Collider2D collision)            
	{
		LevelService.PointEarned(collision);
		LevelService.LifeLost(collision);
	}
}
