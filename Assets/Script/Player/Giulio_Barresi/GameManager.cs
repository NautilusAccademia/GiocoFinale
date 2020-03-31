using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static PlayerInteraction playerInteraction;
    public static InteractiveElement interactiveElement;
    public static ElementSpawn elementSpawn;
    public static ElementOnPastBrazier elementOnPastBrazier;
    public static ElementOnPastSecondBrazier elementOnPastSecondBrazier;
    public static Health health;
    public static AudioManager audioManager;
    public static Door2 door2;
    public static Damage damage;
    public static PlayerController3 playerController3;

    public static GameObject playerGameObject;

    public static Rigidbody playerRb;

    public static int Health;

    public static float[] Level;

    public static bool YouAreInThePresent;

    public static bool YouAreInThePast;

    public static int[] ElementInHand;

    private void Awake()
    {
        playerController3 = FindObjectOfType<PlayerController3>(); //Find movement script
        playerGameObject = GameObject.Find("Player"); //Find player GameObject
        playerRb = playerGameObject.GetComponent<Rigidbody>(); //Find player Rigidbody

        playerInteraction = FindObjectOfType<PlayerInteraction>();
        interactiveElement = FindObjectOfType<InteractiveElement>();
        elementSpawn = FindObjectOfType<ElementSpawn>();
        elementOnPastBrazier = FindObjectOfType<ElementOnPastBrazier>();
        elementOnPastSecondBrazier = FindObjectOfType<ElementOnPastSecondBrazier>();
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
        
    }
}
