using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door2 : MonoBehaviour
{
    Animator anim; //The animation that opens the door
    //Text Explain; //The explaination
    [SerializeField]
    bool isOpen; //check if door is open or not

    [SerializeField]
    public bool PresentBrazierIsOn;
    [SerializeField]
    public bool PastBrazierIsOn;
    [SerializeField]
    public bool PastSecondBrazierIsOn;

    private void Start()
    {
        PresentBrazierIsOn = false;
        PastBrazierIsOn = false;
        PastSecondBrazierIsOn = false;

        isOpen = false;

        anim = GetComponent<Animator>(); //Get the component Animator of the Door
        //Explain = GameObject.Find("Explanation").GetComponent<Text>();//Get the explanation...
        //Explain.enabled = false; //...and disable it           
    }

    private void Update()
    {
        OpenDoor();
    }

    /*private void OnTriggerStay(Collider other)
    {
        //if the door is colliding with the player and if the door isn't open
        if(isOpen == false) 
        {
            OpenDoor();      
        }
    }*/

    void OpenDoor()
    {
        //Explain.enabled = true; //show the explaination
        if (PresentBrazierIsOn == true && PastBrazierIsOn == true && PastSecondBrazierIsOn == true) // if the O button is being pressed
        {
            isOpen = true; //and then consider the door open
            anim.SetBool("isOpen", true); //then the bool "opening" actives the animation which opens the door
            //Explain.enabled = false; //the explaination is disabled once again    
            AudioManager.instance.PlayOpenDoor();
        }
    }

    //Input.GetKey(KeyCode.O)
    //other.gameObject.tag == "Player" 
}
