using UnityEngine;

public class SoundService : MonoBehaviour {

    private AudioSource _source;
    [SerializeField] private AudioClip _okSound;
    [SerializeField] private AudioClip _errorSound;
    [SerializeField] private AudioClip _achievement;
    [SerializeField] private AudioClip _columnPassed;
    [SerializeField] private AudioClip _crash;

	private void Awake ()
    {
        _source = GetComponent<AudioSource>();
	}

    public void PlayOkSound()
    {
        _source.PlayOneShot(_okSound);
    }

    public void PlayErrorSound()
    {
        _source.PlayOneShot(_errorSound);
    }

    public void PlayPointEarnedSound()
    {
        _source.PlayOneShot(_columnPassed);
    }

    public void PlayCrashSound()
    {
        _source.PlayOneShot(_crash);
    }

    public void PlayAchievementSound()
    {
        _source.PlayOneShot(_achievement);
    }
}
