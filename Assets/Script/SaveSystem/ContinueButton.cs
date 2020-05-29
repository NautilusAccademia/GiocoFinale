using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ContinueButton : MonoBehaviour
{
    private int sceneToContinue;

    public static ToNextScene instance;

    private bool needtoLoad = false;

   /* void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        gameObject.transform.parent = null;

        DontDestroyOnLoad(gameObject);

    }*/

    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene"); //apre i dati del salvataggio
      


        if (sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
            Time.timeScale = 1f; //(Nanni) Whenever the start game button is pressed
                                 //The time begins to flow again instead of staying stopped

        }

        else
            return;
    }

   /* void Update()
    {
        if (needtoLoad && nextScenetoLoad == SceneManager.GetActiveScene().buildIndex)

        {
            GameManager.health.health = PlayerPrefs.GetInt("health");
            needtoLoad = false;
            nextScenetoLoad = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log("Grazie Gesu");
            GameManager.health.UpdateHUD();


        }
    }*/

}
