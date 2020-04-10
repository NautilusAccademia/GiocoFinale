using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireOnBrazier : InteractableObjects
{
    [SerializeField]
    public GameObject Fire;

    public static bool portalActivated; //elisa

    //public GameManager.Elements myElement;

    // Start is called before the first frame update
  

    public override void Initialize()
    {
        portalActivated = false; 
        Fire.SetActive(false);

    }

    public void SpawnFireOnBrazier()
    {
        Fire.SetActive(true);
        portalActivated = true; //elisa
        //PlayerInteraction.instance.elementInHand = myElement;
        InteractiveElement.instance.DestroyElement();
        HUD.instance.HideFireHUD();   
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        SpawnFireOnBrazier();
    }
}
