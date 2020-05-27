using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetThroughInteraction : InteractableObjects
{
    //added by Nanni
    [SerializeField] Animator transition; //Animator that takes in reference the Canvas for the transition

    [SerializeField] Transform pos;

    [SerializeField] Transform lookAt;

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        ChangeMusic();
        PlayerGetThrough();
        
    }

    void PlayerGetThrough()
    {
        StartCoroutine(TransitionSet());//Added by Nanni, starts a couroutine which contains the animation
        GameManager.instance.playerGameObject.transform.position = pos.transform.position;
        GameManager.instance.playerGameObject.transform.LookAt(lookAt);
    }

    private IEnumerator TransitionSet() //IEnumerator which sets the animation
    {
        transition.SetBool("ActiveTransition", true); //At the begging, set the bool true and start the animation

        yield return new WaitForSeconds(1); //After one second...

        transition.SetBool("ActiveTransition", false); //Set the bool false, so that the animation is stopped
    }

    private void ChangeMusic()
    {
       if(GameManager.instance.YouAreInThePresent)
       {
            AudioManager.instance.PastSnapshot();
            GameManager.instance.YouAreInThePresent = false;
       }
        else
        {
            AudioManager.instance.PresentSnapshot();
            GameManager.instance.YouAreInThePresent = true;
        }
    }
}
