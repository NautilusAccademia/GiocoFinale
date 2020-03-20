using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;

    [SerializeField] GameObject[] healthHUD;

    private int currentHealthIndex;

    private void Awake()
    {
        health = healthHUD.Length;
        currentHealthIndex = healthHUD.Length - 1;
    }

    public void DecreaseHealth()
    {
        if(health==0)
        {
            return;
        }

        health--;

        healthHUD[currentHealthIndex].SetActive(false);
        currentHealthIndex--;
    }

    public void IncreaseHealth()
    {
        if (health == healthHUD.Length)
        {
            return;
        }

        health++;

        currentHealthIndex++;
        healthHUD[currentHealthIndex].SetActive(true);

    }

}
