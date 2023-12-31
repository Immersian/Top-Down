using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnce : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] AudioClips;

    public float MinVolume = 0.9f;
    public float MaxVolume = 1.1f;

    public float MinPitch = 0.9f;   
    public float MaxPitch = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();    
        if ( _audioSource != null && AudioClips.Length > 0)
        {
            _audioSource.pitch = Random.Range(MinPitch, MaxPitch);
            _audioSource.volume = Random.Range(MinVolume, MaxVolume);
            int randomAudioClip = Random.Range(0, AudioClips.Length - 1);
            _audioSource.PlayOneShot(AudioClips[randomAudioClip]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_audioSource != null && _audioSource.isPlaying)
            return;

        Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
