using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeElement : InteractableObjects
{
    void Take()
    {
        PlayerInteraction.instance.FireInHand = true;
        HUD.instance.ShowFireHUD();
        GameManager.interactiveElement.SpawnFire();
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        Take();
    }
}
