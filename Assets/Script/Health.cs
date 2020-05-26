using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;

    [SerializeField] GameObject[] healthHUD;

    [SerializeField] public float invincibilityTime; // tempo durata invincibilitá
    private float currentTime;	// tempo trascorso dall'ultima volta che hai subito danno

    private int currentHealthIndex;

    [SerializeField] private float nBlink = 3;    // Numero di lampeggi assegnato nell'Inspector per vedere l'effetto grafico
    private float blinkTime; // tempo per ogni lampeggio calcolato nello start

    [SerializeField] private SkinnedMeshRenderer meshRenderer; // Salviamo il meshRendere per i futuri utilizzi
    [SerializeField] private Color colorEnd;

    private Animator playerAn;

    private void Awake()
    {
        health = healthHUD.Length;
        currentHealthIndex = healthHUD.Length - 1;
        currentTime = invincibilityTime;
    }

    public void DecreaseHealth()
    {
        if (currentTime > invincibilityTime)
        {
            currentTime = 0;

           
           

            health--;

            healthHUD[currentHealthIndex].SetActive(false);
            currentHealthIndex--;

            StartCoroutine(DamageGraphicEffect());
        }

        if (health == 0)
        {
            GameManager.playerController4.StartIgnoreInput();
            AudioManager.instance.PlayDeath();
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

        if (health <= 0)
        {
            playerAn.SetTrigger("Death");
            GameManager.playerController4.StartIgnoreInput(); //ignora l'input del giocatore
            yield return StartCoroutine(WaitASec(2)); //aspetta 5 secondi prima di far aprire la scena successiva.
            SceneManager.LoadScene(4);

            /*if (health == 0)
            {
                
            }*/


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

}
