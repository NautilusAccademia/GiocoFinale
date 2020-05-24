using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBy : MonoBehaviour
{
    [SerializeField] Conditions[] conditions;

    [SerializeField] InteractableObjects[] interactableObjects;

    // Start is called before the first frame update
    void Start()
    {
        playerAn = GameManager.instance.playerGameObject.GetComponent<Animator>();
    }

    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public bool interacted;

    [SerializeField] bool repeatedMoreTimes;

    private Animator playerAn;

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
        bool conditionsSatisfied = true;
        foreach(Conditions c in conditions)
        {
            if (!c.CheckCondition())
            {
                conditionsSatisfied = false;
            }
        }
        if (conditionsSatisfied)
        {
            if (interacted == false || repeatedMoreTimes == true)
            {
                foreach(InteractableObjects inter in interactableObjects)
                {
                    inter.SpecificInteraction();
                }
                playerAn.SetTrigger("Taken");
                PlayAudioClip();
                interacted = true;
            }
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.interactByList.Contains(this))
        {
            GameManager.instance.interactByList.Add(this);
        }
        if (other.CompareTag("Player"))
        {
            HUD.instance.infoEImage.enabled = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        GameManager.instance.interactByList.Remove(this);
        HUD.instance.infoEImage.enabled = false;
    }
}
