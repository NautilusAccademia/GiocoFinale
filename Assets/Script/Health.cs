using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 3;

    [SerializeField] GameObject[] healthHUD;

    [SerializeField] public float invincibilityTime = 2; // tempo durata invincibilitá
    private float currentTime;	// tempo trascorso dall'ultima volta che hai subito danno

    private int currentHealthIndex;

    [SerializeField] private float nBlink = 3;    // Numero di lampeggi assegnato nell'Inspector per vedere l'effetto grafico
    private float blinkTime; // tempo per ogni lampeggio calcolato nello start

    [SerializeField] private SkinnedMeshRenderer meshRenderer; // Salviamo il meshRendere per i futuri utilizzi
    [SerializeField] private Color colorEnd;

    private Animator playerAn;



    private void Awake()
    {


        currentHealthIndex = healthHUD.Length - 1;
        currentTime = invincibilityTime;

        if (health <= 0)
        {
            health = 1;

        }

        for (int i = 2; i >= health; i--)
        {
            healthHUD[currentHealthIndex].SetActive(false);
            currentHealthIndex--;


        }


    }

    public void DecreaseHealth()
    {
        if (health <= 0)
        {
            return;
        }
        if (currentTime > invincibilityTime)
        {
            currentTime = 0;


            health--;

            healthHUD[currentHealthIndex].SetActive(false);
            currentHealthIndex--;

            StartCoroutine(DamageGraphicEffect());
        }



    }

    public IEnumerator WaitASec(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait); // serve per creare il tempo giusto prima di far partire la scena della morte con una quantità di tempo
    }

    IEnumerator DamageGraphicEffect()
    {
        float t = 0;
        //Colore iniziale
        Color[] colorStart = new Color[meshRenderer.materials.Length];

        for (int i = 0; i < meshRenderer.materials.Length; i++)
        {
            colorStart[i] = meshRenderer.materials[i].color;
        }

        //Cicla per il numero di blink
        for (int i = 0; i < nBlink; i++)
        {
            // I due cicli while formano un blink
            while (t < blinkTime / 2)
            {
                t += Time.deltaTime;

                for (int c = 0; c < meshRenderer.materials.Length; c++)
                {
                    meshRenderer.materials[c].color = Color.Lerp(colorStart[c], colorEnd, t / (blinkTime / 2));
                }

                yield return null;
            }
            while (t > 0)
            {
                t -= Time.deltaTime;

                for (int c = 0; c < meshRenderer.materials.Length; c++)
                {
                    meshRenderer.materials[c].color = Color.Lerp(colorStart[c], colorEnd, t / (blinkTime / 2));
                }

                yield return null;
            }
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


    private void Start()
    {
        //meshRenderer = GetComponent<MeshRenderer>(); // Inizializiamo il meshRenderer
        blinkTime = invincibilityTime / nBlink; // Calcola il tempo di un blik basandosi sul tempo in cui resti invicibile e il numero di blink che vogliamo moastare
        playerAn = GetComponent<Animator>();



    }

    private void Update()
    {
       
        currentTime += Time.deltaTime; // Incrementa il timer ogni frame del tempo trascorso nel frame, quindi semplicemente il tempo trascorso
    }

    public void UpdateHUD()
    {
        for (int i = 2; i >= health; i--)
        {
            healthHUD[currentHealthIndex].SetActive(false);
            currentHealthIndex--;


        }
    }
   
}

