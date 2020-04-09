using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] Transform objectToPan;

    bool panIsActive;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        panIsActive = false;
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
