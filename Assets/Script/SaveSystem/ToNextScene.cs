using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    private int nextScenetoLoad;

    public static ToNextScene instance;

    private bool needtoLoad = false;

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


    private void Start()
    {
        Debug.Log(needtoLoad);

        nextScenetoLoad = SceneManager.GetActiveScene().buildIndex + 1;


    }

    private void OnTriggerEnter(Collider collision)
    {
        needtoLoad = true;

        Debug.Log("needtoLoad_settato");

        SceneManager.LoadScene(nextScenetoLoad);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex + 1);


    }

    // Update is called once per frame
    void Update()
    {
        if (needtoLoad && nextScenetoLoad == SceneManager.GetActiveScene().buildIndex)

        {
            GameManager.health.health = PlayerPrefs.GetInt("health");
            needtoLoad = false;
            nextScenetoLoad = SceneManager.GetActiveScene().buildIndex + 1;
            Debug.Log("Grazie Gesu");
            GameManager.health.UpdateHUD();


        }
    }
}
