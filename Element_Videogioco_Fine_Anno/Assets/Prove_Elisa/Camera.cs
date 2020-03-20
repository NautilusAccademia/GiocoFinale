using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{

    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2;
    private bool mainCameraEnabled;



    // Start is called before the first frame update
    void Start()
    {
        
        mainCameraEnabled = true;
        virtualCamera1.enabled = true;
        virtualCamera2.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Z) && virtualCamera1.enabled == true)
        {
            mainCameraEnabled = false;
            virtualCamera1.enabled = false;
            virtualCamera2.enabled = true;

        }

       else if (mainCameraEnabled == false && Input.GetKeyDown(KeyCode.Z))
        {
            mainCameraEnabled = true;
            virtualCamera1.enabled = true;
            virtualCamera2.enabled = false;

        }

    }
        
    
}
