using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    //[SerializeField]
    //bool ActionButtonPressed;
    /*[SerializeField]
    bool DestroyButtonPressed;*/

    //InteractiveElement interactiveElement;

    //ElementSpawn elementSpawn;

    //ElementOnPastBrazier PastBrazier;

    //ElementOnPastSecondBrazier PastSecondBrazier;
    //[System.NonSerialized]
    //Door2 door;

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

    [SerializeField]
    bool PresentPortalRange;
    [SerializeField]
    bool PastPortalRange;

    //[SerializeField]
    public Transform PresentPortalPos;
    //[SerializeField]
    public Transform PastPortalPos;

    [SerializeField]
    Image ElementHUDFire;

    [SerializeField]
    Image ElementHUDEmpty;


    //added by Nanni
    [SerializeField]
    Animator Transition; //Animator that takes in reference the Canvas for the transition

    //Temporary
    [SerializeField] private Image customImage;

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

        //ActionButtonPressed = false;

        PresentPortalRange = false;
        PastPortalRange = false;
        //DestroyButtonPressed = false;

        //interactiveElement = FindObjectOfType<InteractiveElement>();
        //elementSpawn = FindObjectOfType<ElementSpawn>();
        //PastBrazier = FindObjectOfType<ElementOnPastBrazier>();
        //PastSecondBrazier = FindObjectOfType<ElementOnPastSecondBrazier>();
        //door = FindObjectOfType<Door2>();

        ElementHUDEmpty.enabled = true;
        ElementHUDFire.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActionOnElements();
        ThrowElement();
        NoActionNeeded();
        TakingPresentPortal();
        TakingPastPortal();
        //DestroyElementInstantiated();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire") && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            FireRange = true;
            customImage.enabled = true;//temporary
        }

        else if (other.gameObject.CompareTag("Water") && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            WaterRange = true;
        }

        else if (other.gameObject.CompareTag("Air") && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            AirRange = true;
        }

        else if (other.gameObject.CompareTag("Earth") && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            EarthRange = true;
        }
        else if (other.gameObject.CompareTag("PresentBrazier") && FireInHand == true && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            BrazierPresentRange = true;
            customImage.enabled = true;//temporary
        }
        else if (other.gameObject.CompareTag("PastBrazier") && FireInHand == true && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            BrazierPastRange = true;
            customImage.enabled = true;//temporary
        }
        else if (other.gameObject.CompareTag("PastSecondBrazier") && FireInHand == true && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            BrazierPastSecondRange = true;
            customImage.enabled = true;//temporary
        }
        else if (other.gameObject.CompareTag("PresentPortal") && PresentPortalRange == false)
        {
            PresentPortalRange = true;
            customImage.enabled = true;
            //TakingPresentPortal();
        }
        else if (other.gameObject.CompareTag("PastPortal") && PastPortalRange == false)
        {
            PastPortalRange = true;
            customImage.enabled = true;
            //TakingPastPortal();
        }
    }    

    private void OnTriggerExit(Collider other)
    {
        FireRange = false;
        customImage.enabled = false;//temporary
        WaterRange = false;
        AirRange = false;
        EarthRange = false;

        BrazierPresentRange = false;
        BrazierPastRange = false;
        BrazierPastSecondRange = false;

        PresentPortalRange = false;
        PastPortalRange = false;
    }

    void ActionOnElements()
    {
        if (Input.GetKeyDown(KeyCode.E) && /*ActionButtonPressed == false &&*/ FireRange == true && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            //ActionButtonPressed = true;
            FireInHand = true;
            ElementHUDEmpty.enabled = false;
            ElementHUDFire.enabled = true;
            GameManager.interactiveElement.SpawnFire();
            AudioManager.instance.PlayTakeElement();
        }
        else if(Input.GetKeyDown(KeyCode.E) && /*ActionButtonPressed == false &&*/ WaterRange == true && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            //ActionButtonPressed = true;
            WaterInHand = true;
            GameManager.interactiveElement.SpawnWater();
        }
        else if (Input.GetKeyDown(KeyCode.E) && /*ActionButtonPressed == false &&*/ AirRange == true && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            //ActionButtonPressed = true;
            AirInHand = true;
            GameManager.interactiveElement.SpawnAir();
        }
        else if (Input.GetKeyDown(KeyCode.E) && /*ActionButtonPressed == false &&*/ EarthRange == true && FireInHand == false && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            //ActionButtonPressed = true;
            EarthInHand = true;
            GameManager.interactiveElement.SpawnEarth();
        }
        else if(Input.GetKeyDown(KeyCode.E) && /*ActionButtonPressed == false &&*/ FireInHand == true && WaterInHand == false && AirInHand == false && EarthInHand == false)
        {
            //ActionButtonPressed = true;
            if (BrazierPresentRange == true && /*ActionButtonPressed == true &&*/ ElementOnPresentBrazier == false)
            {
                ElementOnPresentBrazier = true;
                FireInHand = false;
                ElementHUDFire.enabled = false;
                ElementHUDEmpty.enabled = true;
                GameManager.interactiveElement.DestroyElement();
                GameManager.elementSpawn.SpawnFireOnPresentBrazier();
                GameManager.door2.PresentBrazierIsOn = true;
                AudioManager.instance.PlayUseElement();
            }
            if (BrazierPastRange == true && /*ActionButtonPressed == true &&*/ ElementOnPastBrazier == false)
            {
                ElementOnPastBrazier = true;
                FireInHand = false;
                ElementHUDFire.enabled = false;
                ElementHUDEmpty.enabled = true;
                GameManager.interactiveElement.DestroyElement();
                GameManager.elementOnPastBrazier.SpawnFireOnPastBrazier();
                GameManager.door2.PastBrazierIsOn = true;
                AudioManager.instance.PlayUseElement();
            }
            if (BrazierPastSecondRange == true && /*ActionButtonPressed == true &&*/ ElementOnPastSecondBrazier == false)
            {
                ElementOnPastSecondBrazier = true;
                FireInHand = false;
                ElementHUDFire.enabled = false;
                ElementHUDEmpty.enabled = true;
                GameManager.interactiveElement.DestroyElement();
                GameManager.elementOnPastSecondBrazier.SpawnFireOnPastSecondBrazier();
                GameManager.door2.PastSecondBrazierIsOn = true;
                AudioManager.instance.PlayUseElement();
            }
        }
        else
        {
            //ActionButtonPressed = false;
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
            ElementHUDFire.enabled = false;
            ElementHUDEmpty.enabled = true;
            WaterInHand = false;
            AirInHand = false;
            EarthInHand = false;
            BrazierPresentRange = false;
            BrazierPastRange = false;
            BrazierPastSecondRange = false;
            GameManager.interactiveElement.DestroyElement();
        }
    }

    void TakingPresentPortal()
    {
        if(Input.GetKeyDown(KeyCode.E) /*ActionButtonPressed == false &&*/ && PresentPortalRange == true)
        {
            StartCoroutine(TransitionSet());//Added by Nanni, starts a couroutine which contains the animation
            gameObject.transform.position = PastPortalPos.transform.position;
            AudioManager.instance.PlayPortalTransition();
            AudioManager.instance.PastSnapshot();
        }
    }
    void TakingPastPortal()
    {
        if (Input.GetKeyDown(KeyCode.E) && /*ActionButtonPressed == false &&*/ PastPortalRange == true)
        {
            StartCoroutine(TransitionSet());//Added by Nanni, as above in TakingPresentPortal, so does here
            gameObject.transform.position = PresentPortalPos.transform.position;
            AudioManager.instance.PlayPortalTransition();
            AudioManager.instance.PresentSnapshot();
        }    
    }

    private IEnumerator TransitionSet() //IEnumerator which sets the animation
    {
        Transition.SetBool("ActiveTransition", true); //At the begging, set the bool true and start the animation
        
        yield return new WaitForSeconds(1); //After one second...

        Transition.SetBool("ActiveTransition", false); //Set the bool false, so that the animation is stopped
    }
}