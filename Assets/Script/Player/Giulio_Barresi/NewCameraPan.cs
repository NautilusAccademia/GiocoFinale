using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraPan : MonoBehaviour
{
    [SerializeField] GameObject objectCamera;

    [SerializeField] float WaitOnInteraction = 0.2f;
    [SerializeField] float WaitOnObject = 3;

    [SerializeField] GameObject[] objectToBeActive;

    bool once = true;

    private void Update()
    {
        LookAtPortal();
    }

    void CameraOnObject()
    {
        HUD.instance.infoEImage.enabled = false;
        objectCamera.SetActive(true);
        GameManager.instance.playerCamera.SetActive(false);
        GameManager.playerController4.StartIgnoreInput();
    }

    void CameraOnPlayer()
    {
        objectCamera.SetActive(false);
        GameManager.instance.playerCamera.SetActive(true);
        GameManager.playerController4.EndIgnoreInput();
    }

    IEnumerator Pan()
    {
        {
            yield return new WaitForSeconds(WaitOnInteraction);
            CameraOnObject();
            yield return new WaitForSeconds(WaitOnObject);
            CameraOnPlayer();
        }
    }

    void LookAtPortal()
    {
        bool actives = true; 

        foreach(GameObject gameObject in objectToBeActive)
        {
            if (!gameObject.activeInHierarchy)
            {
                actives = false;
            }
        }

        if(actives == true && once == true)
        {
            once = false;
            StartCoroutine(Pan());
        }
    }

    
}
