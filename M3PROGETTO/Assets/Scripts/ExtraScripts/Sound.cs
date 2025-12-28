using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _deathClip;

    [SerializeField] AudioSource _musicSource;
    

    public void DeathClip()
    {
        if (_audioSource != null && _deathClip != null)
        {
            _audioSource.PlayOneShot(_deathClip);
        }
        if (_musicSource != null)
        {
            _musicSource.Stop();
        }

                
    }
   
}
