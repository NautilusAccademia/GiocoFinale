using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTraps : InteractableObjects
{
    [SerializeField] public GameObject BigStone;

    public override void Initialize()
    {
        BigStone.SetActive(false);
    }

    public void SpawnBigStoneOnTrap()
    {
        BigStone.SetActive(true);
        InteractiveElement.instance.DestroyElement();
        HUD.instance.HideEarthHUD();
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        SpawnBigStoneOnTrap();
    }

}
