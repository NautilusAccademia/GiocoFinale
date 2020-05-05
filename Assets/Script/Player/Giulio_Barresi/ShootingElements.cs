using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingElements : MonoBehaviour
{
    [SerializeField] Conditions condition;

    [SerializeField] ParticleSystem air;

    private void Update()
    {
        ShootingAir();
    }

    void ShootingAir()
    {
        if (Input.GetKeyDown(KeyCode.F) && condition.CheckCondition())
        {
            air.Play(true);
        }
    }
}
