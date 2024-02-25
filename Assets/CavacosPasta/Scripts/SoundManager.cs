using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource SFXSource;
    public AudioSource musicSource;

    public void PlayAudio(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
    public void PlayMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
    
}
