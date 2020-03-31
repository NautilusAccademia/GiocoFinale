using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioClip takeElementClip;
    [SerializeField] AudioClip useElementClip;
    [SerializeField] AudioClip takeDamageClip;
    [SerializeField] AudioClip musicGameClip;
    [SerializeField] AudioClip openDoorClip;
    [SerializeField] AudioClip portalTransitionClip;

    [SerializeField] AudioMixerGroup musicMixer;

    private AudioSource itemsSource;
    private AudioSource musicSource;

    public void PlayTakeElement()
    {
        itemsSource.clip = takeElementClip;
        itemsSource.Play();
    }

    public void PlayUseElement()
    {
        itemsSource.clip = useElementClip;
        itemsSource.Play();
    }

    public void PlayOpenDoor()
    {
        itemsSource.clip = openDoorClip;
        itemsSource.Play();
    }

    public void PlayTakeDamage()
    {
        itemsSource.clip = takeDamageClip;
        itemsSource.Play();
    }

    public void PlayMusicSource()
    {
        musicSource.clip = musicGameClip;
        musicSource.Play();
    }

    public void PlayPortalTransition()
    {
        itemsSource.clip = portalTransitionClip;
        itemsSource.Play();
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        itemsSource = gameObject.AddComponent<AudioSource>();
        itemsSource.loop = false;

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        musicSource.volume = 0.3f;

        AudioManager.instance.PlayMusicSource();
    }
    public void AddMixerGroup()
    {
        musicSource.outputAudioMixerGroup = musicMixer;
    }

    public void RemoveMixerGroup()
    {
        musicSource.outputAudioMixerGroup = null;
    }
}
