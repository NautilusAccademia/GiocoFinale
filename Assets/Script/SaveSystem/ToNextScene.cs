using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        LoadManager.instance.OnSceneLoad();

    }
  
}
