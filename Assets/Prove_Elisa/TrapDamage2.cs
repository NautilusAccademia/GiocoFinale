using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage2 : MonoBehaviour
{
    public Animator trapAn;
    
   





    // Start is called before the first frame update
    void Start()
    {
       // trapAn = GetComponent<Animator>();
        

    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            trapAn.SetTrigger("trapActive");

          

            other.gameObject.GetComponent<Health>().DecreaseHealth();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        trapAn.SetTrigger("trapInactive");


    }










    // Update is called once per frame
    void Update()
    {

    }
}
