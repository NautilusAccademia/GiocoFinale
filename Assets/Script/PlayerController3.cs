using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public float speed = 4; //Player's speed
    private Animator playerAn;

    public bool ignoreInput = false;

    private void Start()
    {
        playerAn = GetComponent<Animator>(); //aggiunta elisa
    }

    private void Update()
    {
        if (!ignoreInput)
        {

            if (Input.GetAxis("Horizontal") > 0.0f || Input.GetAxis("Horizontal") < -0.0f
                || Input.GetAxis("Vertical") > 0.0f || Input.GetAxis("Vertical") < -0.0f)
            {
                Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); //Apply the axises to the movement

                transform.rotation = Quaternion.LookRotation(Movement); //The player will rotate according to its movement 
                transform.Translate(Movement * speed * Time.deltaTime, Space.World); //move the player 
                playerAn.SetBool("is_walking", true); //aggiunta elisa
            }

            else
            {
                playerAn.SetBool("is_walking", false); //aggiunta elisa
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //gameObject.GetComponent<Animation>().Play("Taken");

                playerAn.SetTrigger("Taken");
            }

        }

        else
        {
            playerAn.SetBool("is_walking", false); //aggiunta elisa
        }
    }

    public void StartIgnoreInput()
    {
        ignoreInput = true;
    }

    public void EndIgnoreInput()
    {
        ignoreInput = false;
    }

    public IEnumerator EndIgnoreInputAfterCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.playerController3.EndIgnoreInput();
    }
}
