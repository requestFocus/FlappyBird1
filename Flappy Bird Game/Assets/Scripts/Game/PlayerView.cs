using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
	//[SerializeField] private ParticleSystem AchievementParticles;
	[SerializeField] private NonGUIService NonGUIService;

	private bool _achievementUnlocked;

	private void Update()
	{
		NonGUIService.MovePlayer(this);
	} 

	private void OnTriggerEnter2D(Collider2D collision)            
	{
		NonGUIService.PointEarned(collision);
		//_achievementUnlocked = NonGUIService.PointEarned(collision);
		//if (_achievementUnlocked)
		//{
		//	AchievementParticles.Play();
		//	_achievementUnlocked = false;
		//}
		NonGUIService.LifeLost(collision);
	}
}
