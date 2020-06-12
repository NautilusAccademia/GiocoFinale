using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    static public int count;
    public static PlayerInteraction playerInteraction;
    public static InteractiveElement interactiveElement;
    public static FireOnBrazier fireOnBrazier;
    public static Health health;
    public static AudioManager audioManager;
    public static Door2 door2;
    public static Damage damage;
    public static PlayerController4 playerController4;

    public GameObject playerGameObject;

    public GameObject FakePlayer;

    [SerializeField] public GameObject playerCamera;

    public static Rigidbody playerRb;

    public static int Health;

    public static int Chapter;

    public static int Level;

    public bool YouAreInThePresent;

    public static int[] ElementInHand = new int [4];

    private bool playOnce = false;

    public enum Elements
    {
        None, Fire, Water, Air, Earth
    }

    public List<InteractBy> interactByList = new List<InteractBy>();

    private void Awake()
    {
        instance = this;

        playerController4 = FindObjectOfType<PlayerController4>(); //Find movement script
       // playerGameObject = GameObject.Find("Player"); //Find player GameObject
        playerRb = playerGameObject.GetComponent<Rigidbody>(); //Find player Rigidbody

        playerInteraction = FindObjectOfType<PlayerInteraction>();
        interactiveElement = FindObjectOfType<InteractiveElement>();
        fireOnBrazier = FindObjectOfType<FireOnBrazier>();
        health = FindObjectOfType<Health>();
        audioManager = FindObjectOfType<AudioManager>();
        door2 = FindObjectOfType<Door2>();
        damage = FindObjectOfType<Damage>();

        if(YouAreInThePresent)
        {
            AudioManager.instance.PresentSnapshot();
        }
        else
        {
            AudioManager.instance.PastSnapshot();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (interactByList != null && Input.GetKeyDown(KeyCode.E))
        {
            foreach(InteractBy interactBy in interactByList)
            {
                interactBy.Interact();
            }            
        }

        if(health.health == 0)
        {
            playerController4.gameObject.SetActive(false);
            FakePlayer.SetActive(true);
            FakePlayer.transform.position = playerController4.gameObject.transform.position;
        }

        StartCoroutine((PlayerDeath()));
    }
    public IEnumerator WaitASec(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait); // serve per creare il tempo giusto prima di far partire la scena della morte con una quantità di tempo
    }

    IEnumerator PlayerDeath()
    {
        if (health.health == 0 && !playOnce)
        {
            playOnce = true;
            AudioManager.instance.PlayDeath();
            playerController4.gameObject.SetActive(false);
            FakePlayer.SetActive(true);
            FakePlayer.transform.position = playerController4.gameObject.transform.position;
            yield return StartCoroutine(WaitASec(3));
            SceneManager.LoadScene(4);
            PlayerPrefs.SetInt("health",3);
        }
    }
}
