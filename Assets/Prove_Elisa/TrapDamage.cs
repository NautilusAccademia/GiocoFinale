using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private Animator trapAn;
    public float pushRadius = 5.0F;
    public float power = 10.0F;
    Vector3 explosionPos;
    public Rigidbody playerRb;
   





    // Start is called before the first frame update
    void Start()
    {
        trapAn = GetComponent<Animator>();
        Vector3 explosionPos = transform.position;
       
        Physics.OverlapSphere(explosionPos, pushRadius);
        
    }

 void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Player"))
        {
            trapAn.SetTrigger("trapActive");

            playerRb.AddExplosionForce(power, explosionPos, pushRadius, 3.0F);

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
