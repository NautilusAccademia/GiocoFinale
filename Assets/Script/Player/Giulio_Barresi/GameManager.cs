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
    public static PlayerController3 playerController3;

    public static GameObject playerGameObject;

    public static Rigidbody playerRb;

    public static int Health;

    public static int Chapter;

    public static int Level;

    public static bool YouAreInThePresent;

    public static int[] ElementInHand = new int [4];

    public enum Elements
    {
        Fire, Water, Air, Earth
    }

    public List<InteractableObjects> interactableObjectsList = new List<InteractableObjects>();

    private void Awake()
    {
        instance = this;

        playerController3 = FindObjectOfType<PlayerController3>(); //Find movement script
        playerGameObject = GameObject.Find("Player"); //Find player GameObject
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
        if (interactableObjectsList != null && Input.GetKeyDown(KeyCode.E))
        {
            foreach(InteractableObjects interactableObjects in interactableObjectsList)
            {
                interactableObjects.Interact();
            }            
        }
    }
}
