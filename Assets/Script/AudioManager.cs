using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioClip musicGameClip;
    [SerializeField] AudioClip collectibleClip;
    [SerializeField] AudioClip deathClip;

    [SerializeField] AudioMixerSnapshot present;
    [SerializeField] AudioMixerSnapshot past;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effect2DSource;

    string prevSceneName;


    public void PlayMusicSource()
    {
        musicSource.clip = musicGameClip;
        musicSource.Play();
    }

    public void PlayCollectible()
    {
        effect2DSource.PlayOneShot(collectibleClip);
    }

    public void PlayDeath()
    {
        effect2DSource.PlayOneShot(deathClip, 0.7f);
    }


    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                if(scene.name == "GameOver" || scene.name == "MenùStart" || instance.prevSceneName == "MenùStart")
                {
                    Destroy(instance.gameObject);
                    instance = this;
                    DontDestroyOnLoad(gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
                
            }
        }

        prevSceneName = scene.name;
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
