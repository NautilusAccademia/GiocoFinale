﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex + 1);

        Time.timeScale = 1f; //(Nanni) Whenever the start game button it's pressed
                             //The time begins to flow again instead of staying stopped
    }


}
