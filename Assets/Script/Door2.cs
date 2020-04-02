using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door2 : MonoBehaviour
{
    Animator anim; //The animation that opens the door
    //Text Explain; //The explaination
    [SerializeField] bool isOpen; //check if door is open or not

    [SerializeField] GameObject[] conditionToOpenDoors;

    private void Start()
    {
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
        foreach (GameObject gameObject in conditionToOpenDoors)
        {
            if (gameObject.activeInHierarchy == false)
            {
                return;
            }
        }      
       
        isOpen = true; //and then consider the door open
        anim.SetBool("isOpen", true); //then the bool "opening" actives the animation which opens the door
        //Explain.enabled = false; //the explaination is disabled once again    
        AudioManager.instance.PlayOpenDoor();
        //Explain.enabled = true; //show the explaination
    }

    //Input.GetKey(KeyCode.O)
    //other.gameObject.tag == "Player" 
}
