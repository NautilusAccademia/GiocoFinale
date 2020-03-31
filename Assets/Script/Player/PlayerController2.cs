using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 4; //Player's speed
    private Animator playerAn;

    private void Start()
    {
        playerAn = GetComponent<Animator>(); //aggiunta elisa
    }

    private void Update()
    {
        if (Input.anyKey) { PlayerMovement(); }//Only execute the movement when any key is pressed 

        else
        {
            playerAn.SetBool("is_walking", false); //aggiunta elisa
        }

    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Vertical"); //Get the Horizontal Axis 
        float ver = Input.GetAxis("Horizontal"); //Get the Vertical Axis
        
        Vector3 Movement = new Vector3(ver, 0f, hor); //Apply the axises to the movement

        transform.rotation = Quaternion.LookRotation(Movement); //The player will rotate according to its movement 
        transform.Translate(Movement * speed * Time.deltaTime, Space.World); //move the player 
        playerAn.SetBool("is_walking", true); //aggiunta elisa
    }
}
