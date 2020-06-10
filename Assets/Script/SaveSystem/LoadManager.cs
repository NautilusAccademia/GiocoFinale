using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private int nextScenetoLoad;
    public static LoadManager instance;

    private bool needtoLoad = false;

    // Start is called before the first frame update
    private void Start()
    {
      
        nextScenetoLoad = SceneManager.GetActiveScene().buildIndex + 1;

    }

    void Awake()
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

    }

    public void OnSceneLoad() 
    {

        needtoLoad = true;

        SceneManager.LoadScene(nextScenetoLoad);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex + 1);
        SaveHealth();


    }
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

   /* void DeathHealth()
    {
        if (GameManager.health = 0)

        {
            PlayerPrefs.SetInt("health", GameManager.health.health);
            GameManager.health.health = PlayerPrefs.GetInt("health", 3);
        }
    } */
    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        nextScenetoLoad = SceneManager.GetActiveScene().buildIndex + 1;
        if (needtoLoad )

        {
            GameManager.health.health = PlayerPrefs.GetInt("health",3);
            needtoLoad = false;
           
            Debug.Log("Grazie Gesu");
            GameManager.health.UpdateHUD();


        }

        
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    void SaveHealth()
    {
        PlayerPrefs.SetInt("health", GameManager.health.health);

    
    }
    public void SetneedtoLoad()
    {
        needtoLoad = true;
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}




