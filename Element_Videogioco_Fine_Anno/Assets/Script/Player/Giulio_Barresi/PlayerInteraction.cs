using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    bool ActionButtonPressed;
    /*[SerializeField]
    bool DestroyButtonPressed;*/

    InteractiveElement interactiveElement;

    ElementSpawn elementSpawn;

    ElementOnPastBrazier PastBrazier;

    ElementOnPastSecondBrazier PastSecondBrazier;
    [System.NonSerialized]
    Door2 door;

    [SerializeField]
    bool FireRange;
    [SerializeField]
    bool WaterRange;
    [SerializeField]
    bool AirRange;
    [SerializeField]
    bool EarthRange;

    [SerializeField]
    bool FireInHand;
    [SerializeField]
    bool WaterInHand;
    [SerializeField]
    bool AirInHand;
    [SerializeField]
    bool EarthInHand;

    [SerializeField]
    bool BrazierPresentRange;
    [SerializeField]
    bool BrazierPastRange;
    [SerializeField]
    bool BrazierPastSecondRange;
    [SerializeField]
    bool ElementOnPresentBrazier;
    [SerializeField]
    bool ElementOnPastBrazier;
    [SerializeField]
    bool ElementOnPastSecondBrazier;

    //[SerializeField]
    public Transform PresentPortalPos;
    //[SerializeField]
    public Transform PastPortalPos;

    [SerializeField]
    GameObject FireIcon;

    // Start is called before the first frame update
    void Start()
    {
        FireRange = false;
        WaterRange = false;
        AirRange = false;
        EarthRange = false;

        FireInHand = false;
        WaterInHand = false;
        AirInHand = false;
        EarthInHand = false;

        BrazierPresentRange = false;

        BrazierPastRange = false;

        BrazierPastSecondRange = false;

        ElementOnPresentBrazier = false;

        ElementOnPastBrazier = false;

        ElementOnPastSecondBrazier = false;

        ActionButtonPressed = false;
        //DestroyButtonPressed = false;

        interactiveElement = FindObjectOfType<InteractiveElement>();
        elementSpawn = FindObjectOfType<ElementSpawn>();
        PastBrazier = FindObjectOfType<ElementOnPastBrazier>();
        PastSecondBrazier = FindObjectOfType<ElementOnPastSecondBrazier>();
        door = FindObjectOfType<Door2>();

        FireIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActionOnElements();
        NoActionNeeded();
        ThrowElement();
        //DestroyElementInstantiated();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire") && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            FireRange = true;
        }

        if (other.gameObject.CompareTag("Water") && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            WaterRange = true;
        }

        if (other.gameObject.CompareTag("Air") && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            AirRange = true;
        }

        if (other.gameObject.CompareTag("Earth") && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            EarthRange = true;
        }
        if (other.gameObject.CompareTag("PresentBrazier") && FireInHand == true && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            BrazierPresentRange = true;        
        }
        if (other.gameObject.CompareTag("PastBrazier") && FireInHand == true && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            BrazierPastRange = true;
        }
        if (other.gameObject.CompareTag("PastSecondBrazier") && FireInHand == true && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            BrazierPastSecondRange = true;
        }
        if (other.gameObject.CompareTag("PresentPortal"))
        {
            TakingPresentPortal();
        }
        if (other.gameObject.CompareTag("PastPortal"))
        {
            TakingPastPortal();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FireRange = false;
        WaterRange = false;
        AirRange = false;
        EarthRange = false;

        BrazierPresentRange = false;
        BrazierPastRange = false;
        BrazierPastSecondRange = false;
    }

    void ActionOnElements()
    {
        if (Input.GetKeyDown(KeyCode.E) && ActionButtonPressed == false && FireRange == true && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            ActionButtonPressed = true;
            FireInHand = true;
            FireIcon.SetActive(true);
            interactiveElement.SpawnFire();
        }
        else if(Input.GetKeyDown(KeyCode.E) && ActionButtonPressed == false && WaterRange == true && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            ActionButtonPressed = true;
            WaterInHand = true;
            interactiveElement.SpawnWater();
        }
        else if (Input.GetKeyDown(KeyCode.E) && ActionButtonPressed == false && AirRange == true && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            ActionButtonPressed = true;
            AirInHand = true;
            interactiveElement.SpawnAir();
        }
        else if (Input.GetKeyDown(KeyCode.E) && ActionButtonPressed == false && EarthRange == true && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            ActionButtonPressed = true;
            EarthInHand = true;
            interactiveElement.SpawnEarth();
        }
        else if(Input.GetKeyDown(KeyCode.E) && ActionButtonPressed == false && FireInHand == true && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            ActionButtonPressed = true;
            if (BrazierPresentRange == true && ActionButtonPressed == true && ElementOnPresentBrazier == false)
            {
                ElementOnPresentBrazier = true;
                FireInHand = false;
                FireIcon.SetActive(false);
                interactiveElement.DestroyElement();
                elementSpawn.SpawnFireOnPresentBrazier();
                door.PresentBrazierIsOn = true;
            }
            if (BrazierPastRange == true && ActionButtonPressed == true && ElementOnPastBrazier == false)
            {
                ElementOnPastBrazier = true;
                FireInHand = false;
                FireIcon.SetActive(false);
                interactiveElement.DestroyElement();
                PastBrazier.SpawnFireOnPastBrazier();
                door.PastBrazierIsOn = true;
            }
            if (BrazierPastSecondRange == true && ActionButtonPressed == true && ElementOnPastSecondBrazier == false)
            {
                ElementOnPastSecondBrazier = true;
                FireInHand = false;
                FireIcon.SetActive(false);
                interactiveElement.DestroyElement();
                PastSecondBrazier.SpawnFireOnPastSecondBrazier();
                door.PastSecondBrazierIsOn = true;
            }
        }
        else
        {
            ActionButtonPressed = false;
            /*FireInHand = false;
            WaterInHand = false;
            AirInHand = false;
            EarthInHand = false;
            BrazierRange = false;*/
        }
    }

    void NoActionNeeded()
    {
        if(FireInHand == true || WaterInHand == true || AirInHand == true || EarthInHand == true)
        {
            FireRange = false;
            WaterRange = false;
            AirRange = false;
            EarthRange = false;
        }
    }

    void ThrowElement()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FireInHand = false;
            FireIcon.SetActive(false);
            WaterInHand = false;
            AirInHand = false;
            EarthInHand = false;
            BrazierPresentRange = false;
            BrazierPastRange = false;
            BrazierPastSecondRange = false;
            interactiveElement.DestroyElement();
        }
    }

    void TakingPresentPortal()
    {
        gameObject.transform.position = PastPortalPos.transform.position;
    }
    void TakingPastPortal()
    {
        gameObject.transform.position = PresentPortalPos.transform.position;
    }
}