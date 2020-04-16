using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator buttonAn;
    public Animator doorAn;




    // Start is called before the first frame update
    void Start()
    {
        buttonAn = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {

        //buttonAn.SetTrigger("buttonPushed");
        buttonAn.SetBool("buttonPush", true);
        buttonAn.SetBool("disabled", false);
        doorAn.SetBool("doorIsOpen", true);

    }

    private void OnTriggerExit(Collider other)
    {
        buttonAn.SetBool("buttonPush", false);
        buttonAn.SetBool("disabled", true);
        doorAn.SetBool("doorIsOpen", false);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
