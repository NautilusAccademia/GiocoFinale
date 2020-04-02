using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireOnBrazier : InteractableObjects
{
    [SerializeField]
    public GameObject Fire;

    public static bool portalActivated; //elisa

    public GameManager.Elements myElement;

    // Start is called before the first frame update
    void Start()
    {
        portalActivated = false; //elisa
        Fire.SetActive(false);
    }

    public void SpawnFireOnBrazier()
    {
        Fire.SetActive(true);
        portalActivated = true; //elisa
        PlayerInteraction.instance.FireInHand = false;
        InteractiveElement.instance.DestroyElement();
        HUD.instance.HideFireHUD();
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        SpawnFireOnBrazier();
    }
}
