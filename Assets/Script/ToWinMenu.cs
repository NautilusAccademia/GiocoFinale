using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToWinMenu : MonoBehaviour
{
    //Nanni
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(5);
    }
}
