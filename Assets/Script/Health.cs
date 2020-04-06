using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;

    [SerializeField] GameObject[] healthHUD;

    [SerializeField] float invincibilityTime; // tempo durata invincibilitá
    private float currentTime;	// tempo trascorso dall'ultima volta che hai subito danno

    private int currentHealthIndex;
    private Animator playerAn;

    private void Awake()
    {
        health = healthHUD.Length;
        currentHealthIndex = healthHUD.Length - 1;
        currentTime = invincibilityTime;
        playerAn = GetComponent<Animator>();
    }

    public void DecreaseHealth()
    {
        if (currentTime > invincibilityTime)
        {
            currentTime = 0;

            if (health == 0)
            {
                return;

                playerAn.SetBool("is_dying", true);
            }

            health--;

       

            healthHUD[currentHealthIndex].SetActive(false);
            currentHealthIndex--;

        }
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

    private void Update()
    {
        currentTime += Time.deltaTime; // Incrementa il timer ogni frame del tempo trascorso nel frame, quindi semplicemente il tempo trascorso
    }

}
