using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera cameraPlayerFollow;

    float startingSize;

    float zoomedSize;

    bool zoomed = false;

    float zoomTime = 0.8f;

    private void Start()
    {
        startingSize = 3.5f;
        zoomedSize = 2f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!zoomed)
            {
                zoomed = true;
                StartCoroutine(ZoomIn());
            }
            else
            {
                zoomed = false;
                StartCoroutine(ZoomOut());
            }         
        }
    }

    IEnumerator ZoomIn()
    {
        float time = 0;
        while(time < zoomTime)
        {          
            time += Time.deltaTime;
            cameraPlayerFollow.m_Lens.OrthographicSize = Mathf.Lerp(startingSize, zoomedSize, time/zoomTime);
            yield return null;
        }
    }
    IEnumerator ZoomOut()
    {
        float time = 0;
        while (time < zoomTime)
        {
            time += Time.deltaTime;
            cameraPlayerFollow.m_Lens.OrthographicSize = Mathf.Lerp(zoomedSize, startingSize, time / zoomTime);
            yield return null;
        }
    }
}
