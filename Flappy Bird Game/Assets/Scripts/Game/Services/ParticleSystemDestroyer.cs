using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour
{
	private void Update ()
	{
		Destroy(gameObject, 2.0f);	
	}
}
