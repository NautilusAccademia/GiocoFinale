using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTraps : InteractableObjects
{
    [SerializeField] public GameObject BigStone;

    [SerializeField] Collider collider;

    private void Start()
    {
        collider.enabled = true;
    }

    public override void Initialize()
    {
        BigStone.SetActive(false);
    }

    public void SpawnBigStoneOnTrap()
    {
        collider.enabled = false;
        BigStone.SetActive(true);
        InteractiveElement.instance.DestroyElement();
        HUD.instance.HideEarthHUD();
        HUD.instance.infoEImage.enabled = false;
        HUD.instance.infoEarthEimage.enabled = false;
    }

    public override void SpecificInteraction()
    {     
        base.SpecificInteraction();
        SpawnBigStoneOnTrap();
    }

}
