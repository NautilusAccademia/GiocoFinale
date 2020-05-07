using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    private int nextScenetoLoad;

    // Start is called before the first frame update
    private void Start()
    {
        nextScenetoLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene(nextScenetoLoad);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
