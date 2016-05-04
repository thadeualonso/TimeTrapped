using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    static AudioManager instance = null;

    private AudioSource source;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Duplicated music player self-destructing");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

        source = GetComponent<AudioSource>();
    }

    public void Play(AudioClip audioClip)
    {
        source.clip = audioClip;
        source.Play();
    }

}
