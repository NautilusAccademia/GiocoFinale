using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementOnPastBrazier : MonoBehaviour
{
    [SerializeField]
    public GameObject objectPos2;
    [SerializeField]
    public GameObject ElementBrazier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnFireOnPastBrazier()
    {
        ElementBrazier.SetActive(true);
        Instantiate(ElementBrazier, objectPos2.transform.position, Quaternion.identity, objectPos2.transform.parent);
    }
}
