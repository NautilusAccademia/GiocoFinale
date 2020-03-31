using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu1 : MonoBehaviour
{
    public bool GameIsPaused = false;//bool that consider if the game is paused
    public GameObject PauseMenuUI;//The menù as a GameObject

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))//if the P button is pressed
        {
            if(GameIsPaused == false)//and if the game is considered paused
            {
                GameIsPaused = true;
                PauseGame();//then pause it
            }
            else//or else
            {
                GameIsPaused = false;
                ResumeGame();//Resume the game
            }
        }
    }

    public void PauseGame()//method that pauses the game
    {
        PauseMenuUI.SetActive(true);//active the menù
        Time.timeScale = 0f;//stop time
        Debug.Log("Sono in pausa");
    }

    public void ResumeGame()//method that resumes the game
    {
        PauseMenuUI.SetActive(false);//disactive the menù
        Time.timeScale = 1f;//resume time
        Debug.Log("Non sono in pausa");
    }

    public void DeactivatePause()
    {
        GameIsPaused = false;
    }

    public void QuitGame()//method that quits the game
    {
        Application.Quit();//Quit the game
    }
}
