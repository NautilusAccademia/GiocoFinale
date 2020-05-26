using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Air"))
        {
            anim.SetTrigger("Press");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
