using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnteOpen : InteractableObjects
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

   private void OpenAnte()
    {
        ShootingElements.instance.ShootingAir();

        anim.SetTrigger("Open_Ante");
        anim.SetTrigger("Open_Ante2");
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        OpenAnte();
        ShootingElements.instance.ShootingAir();
    }
}
