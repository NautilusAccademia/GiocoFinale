using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCollider : MonoBehaviour
{

    public GameObject iceCollider;
    // Start is called before the first frame update
    void Start()
    {
        iceCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (WaterShape.blendShape == 100)
        {
            iceCollider.SetActive(true);
        }
    }
}
