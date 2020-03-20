using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private Animator trapAn;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        trapAn = GetComponent<Animator>();
    }

 void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trapAn.SetBool("trapActive", true);
            trapAn.SetBool("trapInactive", false);

            other.gameObject.GetComponent<Health>().DecreaseHealth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        trapAn.SetBool("trapInactive", true);
        trapAn.SetBool("trapActive", false);

    }








    // Update is called once per frame
    void Update()
    {
        
    }
}
