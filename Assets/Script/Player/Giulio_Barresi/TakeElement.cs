using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeElement : InteractableObjects
{
    [SerializeField] GameManager.Elements elementToTake;

    void Take()
    {
        PlayerInteraction.instance.elementInHand = elementToTake;           
        if(elementToTake == GameManager.Elements.Fire)
        {
            HUD.instance.ShowFireHUD();
            GameManager.interactiveElement.SpawnFire();
        }
        if (elementToTake == GameManager.Elements.Air)
        {
            HUD.instance.ShowAirHUD();
            GameManager.interactiveElement.SpawnAir();
        }
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        Take();
    }
}
