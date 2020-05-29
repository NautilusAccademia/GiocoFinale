using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingElements : MonoBehaviour
{
    [SerializeField] Conditions condition;

    [SerializeField] ParticleSystem air;

    [SerializeField] GameObject airGun;

    private void Start()
    {
        airGun.SetActive(false);
    }

    private void Update()
    {
        ShootingAir();
    }

    void ShootingAir()
    {
        if (Input.GetKeyDown(KeyCode.E) && condition.CheckCondition())
        {
            airGun.SetActive(true);
            air.Play(true);
        }
        if (air.isStopped)
        {
            airGun.SetActive(false);
        }
    }
}
