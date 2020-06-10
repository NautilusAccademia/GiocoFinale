using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntaOpen : MonoBehaviour
{
    Animator anta;
    // Start is called before the first frame update
    void Start()
    {
        anta = GetComponent<Animator>();
        
    }
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Aria"))
        {
            anta.SetTrigger("OpenAnta1");
            anta.SetTrigger("OpenAnta");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
