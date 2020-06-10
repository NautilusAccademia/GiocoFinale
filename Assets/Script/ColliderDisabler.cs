using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisabler : MonoBehaviour
{
    [SerializeField] float offset;
    Collider myCollider;
    Collider playerCollider;
    Vector3 colliderSize;
    Vector3 colliderCenter;

    private void Awake()
    {
        myCollider = GetComponent<Collider>();
        colliderSize = (myCollider.bounds.extents)*2.0f;
        colliderCenter =  myCollider.bounds.center - transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerCollider = collision.collider;
            bool fromDown = collision.transform.position.y - transform.position.y < offset;
            if (fromDown)
            {
                myCollider.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (!myCollider.enabled)
        {
            Bounds colliderArea = new Bounds(transform.position + colliderCenter, colliderSize);
            if (!playerCollider.bounds.Intersects(colliderArea))
            {
                myCollider.enabled = true;
            }
        }

    }
}
