using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordiGhiaccio : MonoBehaviour
{
    [SerializeField] Transform bordi;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = bordi.position;
            collision.transform.rotation = bordi.rotation;
        }
    }
}
