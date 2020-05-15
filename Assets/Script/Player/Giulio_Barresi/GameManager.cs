using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static PlayerInteraction playerInteraction;
    public static InteractiveElement interactiveElement;
    public static FireOnBrazier fireOnBrazier;
    public static Health health;
    public static AudioManager audioManager;
    public static Door2 door2;
    public static Damage damage;
    public static PlayerController4 playerController4;

    public GameObject playerGameObject;

    [SerializeField] public GameObject playerCamera;

    public static Rigidbody playerRb;

    public static int Health;

    public static int Chapter;

    public static int Level;

    public bool YouAreInThePresent;

    public static int[] ElementInHand = new int [4];

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

    }
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
