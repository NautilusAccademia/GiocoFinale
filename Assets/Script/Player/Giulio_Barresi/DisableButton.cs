using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButton : InteractableObjects
{
    [SerializeField] GameObject BigStone;

    [SerializeField] GameObject colliderGO;

    private void Start()
    {
        colliderGO.SetActive(false);
    }

    public override void Initialize()
    {
        BigStone.SetActive(false);
    }

    public void SpawnBigStoneOnTrap()
    {
        BigStone.SetActive(true);
        colliderGO.SetActive(true);
        InteractiveElement.instance.DestroyElement();
        HUD.instance.HideEarthHUD();
        HUD.instance.infoEImage.enabled = false;
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        SpawnBigStoneOnTrap();
    }

}