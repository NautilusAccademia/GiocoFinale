using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;
  
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, pos1.position)<0.01)
        {
            nextPos = pos2.position;
        }

        if(Vector3.Distance(transform.position, pos2.position) < 0.01)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
