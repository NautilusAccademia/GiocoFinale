using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ContinueButton : MonoBehaviour
{
    private int sceneToContinue;

    public static ToNextScene instance;

    private bool needtoLoad = false;

    private void Start()
    {
       
        
            GetComponent<CanvasGroup>().interactable = PlayerPrefs.HasKey("SavedScene");
            
        
    }

    public void ContinueGame()
    {
        
        sceneToContinue = PlayerPrefs.GetInt("SavedScene"); //apre i dati del salvataggio

        

        if (sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
            Time.timeScale = 1f; //(Nanni) Whenever the start game button is pressed
                                 //The time begins to flow again instead of staying stopped
            LoadManager.instance.SetneedtoLoad();

        }

       

        else
            return;
    }

   

}
