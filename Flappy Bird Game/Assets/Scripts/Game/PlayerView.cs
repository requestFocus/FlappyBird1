using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
	[SerializeField] private LevelService LevelService;
	[SerializeField] private ParticleSystem AchievementParticles;


	private void Update()
	{
		LevelService.MovePlayer(this);

		if (LevelService.AchievementToUnlock())
		{
			AchievementParticles = Instantiate(AchievementParticles);
			AchievementParticles.Play();
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)            
	{
		LevelService.PointEarned(collision);
		LevelService.LifeLost(collision);
	}
}
