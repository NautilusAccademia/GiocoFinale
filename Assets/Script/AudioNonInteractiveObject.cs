using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioNonInteractiveObject : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioClip()
    {
        if (audioSource != null && audioClip != null)
            audioSource.PlayOneShot(audioClip);
        else
        {
            if (audioSource == null)
                Debug.LogFormat("L'oggetto {0} non ha un AudioSource", gameObject.name);
            if (audioSource == null)
                Debug.LogFormat("L'oggetto {0} non ha un AudioClip", gameObject.name);
        }
    }
}
