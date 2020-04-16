using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : InteractableObjects
{
    [SerializeField] GameObject objectCamera;

    [SerializeField] float WaitOnInteraction = 0.2f;
    [SerializeField] float WaitOnObject = 3;

   

    void CameraOnObject()
    {
        objectCamera.SetActive(true);
        GameManager.instance.playerCamera.SetActive(false);
    }

    void CameraOnPlayer()
    {
        objectCamera.SetActive(false);
        GameManager.instance.playerCamera.SetActive(true);
    }

    IEnumerator Pan()
    {
        yield return new WaitForSeconds(WaitOnInteraction);
        CameraOnObject();
        yield return new WaitForSeconds(WaitOnObject);
        CameraOnPlayer();
    }

    public override void SpecificInteraction()
    {
        base.SpecificInteraction();
        StartCoroutine(Pan());
    }
}
