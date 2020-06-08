using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingElements : MonoBehaviour
{
    //[SerializeField] Conditions condition;

    [SerializeField] ParticleSystem air;

    [SerializeField] GameObject airGun;

    [SerializeField] public bool buttonRange;

    public static ShootingElements instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        buttonRange = false;
        airGun.SetActive(false);
    }

    public void ShootingAir()
    {
        airGun.SetActive(true);
        InteractiveElement.instance.DestroyElement();
        HUD.instance.HideAirHUD();
        air.Play(true);
        
        if (air.isStopped)
        {
            airGun.SetActive(false);
        }
    }
}
