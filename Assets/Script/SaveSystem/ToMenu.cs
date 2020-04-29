using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToMenu : MonoBehaviour
{
    private int currentSceneIndex;

   public void LoadMainMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);
    }

    //Nanni
    public void ExitGame()//Method that quits the game
    {
        Application.Quit();//Quits the player from application
    }

  
}
