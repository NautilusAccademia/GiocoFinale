using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement3 : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float movementTime;
    [SerializeField] private float waitTime;
    [SerializeField] BoxCollider collider3;

    bool playerInside = false;

    private int index;
    private Vector3 positionA, positionB;

    // Time when the movement started.
    private float startTime;

    private void Start()
    {
        StartCoroutine(Movement());
    }
    public void NextPositions()
    {
        positionA = points[index].position;
        int nextIndex = index + 1 < points.Length ? index + 1 : 0;
        positionB = points[nextIndex].position;
        index = nextIndex;
    }

    IEnumerator Movement()
    {
        while (true)
        {
            NextPositions();
            yield return StartCoroutine(MoveFromPToP(positionA, positionB));
            DisableCollider();
            yield return new WaitForSeconds(waitTime);
            OnEnableCollider();
        }
    }

    private void DisableCollider()
    {
        collider3.enabled = false;
    }

    private void OnEnableCollider()
    {
        if(!playerInside)
        {
            collider3.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerInside = false;
        }
    }

    IEnumerator MoveFromPToP(Vector3 pointA, Vector3 pointB)
    {
        float distCovered = 0;
        float fractionOfJourney = 0;
        startTime = Time.time;

        while (fractionOfJourney < 1)
        {
            // Distance moved equals elapsed time times speed..
            distCovered = (Time.time - startTime);
            // Fraction of journey completed equals current distance divided by total distance.
            fractionOfJourney = distCovered / movementTime;
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(pointA, pointB, fractionOfJourney);
            yield return null;
        }
    }
}
