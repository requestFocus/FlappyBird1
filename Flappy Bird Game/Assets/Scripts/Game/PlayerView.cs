using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
	[SerializeField] private NonGUIService NonGUIService;

	private void Update()
	{
		NonGUIService.MovePlayer(this);
	} 

	private void OnTriggerEnter2D(Collider2D collision)            
	{
		NonGUIService.PointEarned(collision);
		NonGUIService.LifeLost(collision);
	}
}
