using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class InteractableObjects : MonoBehaviour
{
   
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    bool interacted;

    [SerializeField] bool repeatedMoreTimes;

    [SerializeField] Conditions condition;

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

    public void Interact()
    {
        if (condition == null || condition.CheckCondition())
        {
            if (interacted == false || repeatedMoreTimes == true)
            {
                SpecificInteraction();
                PlayAudioClip();
                interacted = true;
            }
        }  
    }

    public virtual void SpecificInteraction()
    {
       
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(!GameManager.instance.interactableObjectsList.Contains(this))
        {
            GameManager.instance.interactableObjectsList.Add(this);
        }
        if (other.CompareTag("Player"))
        {
            HUD.instance.infoEImage.enabled = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        GameManager.instance.interactableObjectsList.Remove(this);
        HUD.instance.infoEImage.enabled = false;
    }
}
