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
	}


	private void OnTriggerEnter2D(Collider2D collision)            
	{
		LevelService.PointEarned(collision);
		LevelService.LifeLost(collision);

		if (LevelService.AchievementToUnlock())
		{
			AchievementParticles = Instantiate(AchievementParticles, gameObject.transform);
			AchievementParticles.Play();
			//Destroy(AchievementParticles.GetComponent<ParticleSystem>(), 2.0f);		//========================jak usunąć ParticleSystem, żeby nie znikał bezpowrotnie??
		}
	}
}
