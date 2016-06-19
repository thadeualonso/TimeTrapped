using UnityEngine;
using System.Collections;

public class AudioManager : Singleton<AudioManager> {

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip audioClip)
    {
        source.clip = audioClip;
        source.Play();
    }

}
