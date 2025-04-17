using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private AudioClip _coinSound; 
    private AudioSource _audioSource;
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this); 
        }
        else
        {
            instance = this;
        }
        _coinSound = Resources.Load<AudioClip>("Sound/coin01");  
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayCoinSound()
    {
        _audioSource.PlayOneShot(_coinSound);
    }
}
