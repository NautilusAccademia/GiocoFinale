using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipOnObject : MonoBehaviour
{
    [SerializeField]
    GameObject ParticleTip;

    // Start is called before the first frame update
    void Start()
    {
        ParticleTip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ParticleTip.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ParticleTip.SetActive(false);
    }

}
