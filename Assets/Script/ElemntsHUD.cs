using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElemntsHUD : MonoBehaviour
{
    public GameObject fire;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            fire.SetActive(!fire.activeInHierarchy);
        }
    }
}
