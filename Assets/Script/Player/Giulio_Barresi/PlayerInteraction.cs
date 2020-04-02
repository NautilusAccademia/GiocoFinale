using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    public bool FireInHand;
    [SerializeField]
    public bool WaterInHand;
    [SerializeField]
    public bool AirInHand;
    [SerializeField]
    public bool EarthInHand;

    public InteractableObjects interactableObjects;

    public static PlayerInteraction instance;

    //Temporary
    [SerializeField] private Image customImage;

    // Start is called before the first frame update
    void Start()
    {
        FireInHand = false;
        WaterInHand = false;
        AirInHand = false;
        EarthInHand = false;

        HUD.instance.HideFireHUD();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowElement();  
    }

    private void Awake()
    {
        instance = this;
    }

    void ThrowElement()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FireInHand = false;
            HUD.instance.HideFireHUD();
            WaterInHand = false;
            AirInHand = false;
            EarthInHand = false;
            GameManager.interactiveElement.DestroyElement();
        }
    }
}
 