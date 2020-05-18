using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTrap : MonoBehaviour
{
    public Animator trapAn;

    [SerializeField] GameObject stoneToDeactive;

    [SerializeField] Collider collider;


    // Start is called before the first frame update
    void Start()
    {
        // trapAn = GetComponent<Animator>();

        stoneToDeactive.SetActive(false);
        collider.enabled = true;
        Damage.instance.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            trapAn.SetTrigger("active");



            other.gameObject.GetComponent<Health>().DecreaseHealth();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        trapAn.SetTrigger("inactive");


    }










    // Update is called once per frame
    void Update()
    {
        if (stoneToDeactive.activeInHierarchy)
        {
            trapAn.SetTrigger("inactive");
            collider.enabled = false;
            Damage.instance.enabled = false;
        }
    }
}
