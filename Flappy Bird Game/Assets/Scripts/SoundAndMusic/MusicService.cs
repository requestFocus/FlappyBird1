using UnityEngine;

public class MusicService : MonoBehaviour
{
    private AudioSource _source;

	private void Start ()
    {
        _source = GetComponent<AudioSource>();
        _source.loop = true;
        _source.volume = 0.6f;
	}
}
