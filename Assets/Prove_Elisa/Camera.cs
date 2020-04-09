using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera1;
    public CinemachineVirtualCamera virtualCamera2;
    private bool activePortal;
    private bool mainCameraEnabled;
 
    public Animator cameraAn;
    public float currentTime = 0f;
    public float startingTime = 2f;

    [SerializeField] bool panCamIsActive;

    [SerializeField] private GameObject ObjectToActive;

    [SerializeField] private Transform objectToPan;

    private float panCamDurationTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    { 
        mainCameraEnabled = true;
        virtualCamera1.enabled = true;
        virtualCamera2.enabled = false;

        panCamIsActive = false;

        
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (FireOnBrazier.portalActivated == true)
        {
            currentTime -= 1 * Time.deltaTime;
            activePortal = true;
            cameraAn.SetTrigger("cameraPan");
            

            if (activePortal == true && currentTime <= 0)
            {
                currentTime = 0;
               
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && mainCameraEnabled == true)
        {
            mainCameraEnabled = false;
            virtualCamera1.enabled = false;
            virtualCamera2.enabled = true;
        }

        else if (Input.GetKeyDown(KeyCode.Z) && mainCameraEnabled == false)
        {
            mainCameraEnabled = true;
            virtualCamera1.enabled = true;
            virtualCamera2.enabled = false;
        }
    }
}















