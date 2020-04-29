using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioClip musicGameClip;

    [SerializeField] AudioMixerSnapshot present;
    [SerializeField] AudioMixerSnapshot past;

    [SerializeField]
    private AudioSource musicSource;


    public void PlayMusicSource()
    {
        musicSource.clip = musicGameClip;
        musicSource.Play();
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Start()
    {
        AudioManager.instance.PlayMusicSource();
    }
    public void PastSnapshot()
    {
        past.TransitionTo(0.1f);

    }
    
    public void PresentSnapshot()
    {
        present.TransitionTo(0.1f);
    }
}
