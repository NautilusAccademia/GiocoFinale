using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementOnPastSecondBrazier : MonoBehaviour
{
    [SerializeField]
    public GameObject objectPos3;
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

    public void SpawnFireOnPastSecondBrazier()
    {
        ElementBrazier.SetActive(true);
        Instantiate(ElementBrazier, objectPos3.transform.position, Quaternion.identity, objectPos3.transform.parent);
    }
}
