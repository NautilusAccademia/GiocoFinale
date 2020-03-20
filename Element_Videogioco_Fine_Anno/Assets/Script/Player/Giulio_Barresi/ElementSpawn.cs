using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject objectPos;
    [SerializeField]
    public GameObject ElementBrazier;

    [SerializeField]
    GameObject Portal;

    // Start is called before the first frame update
    void Start()
    {
        Portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFireOnPresentBrazier()
    {
        Portal.SetActive(true);
        ElementBrazier.SetActive(true);
        Instantiate(ElementBrazier, objectPos.transform.position, Quaternion.identity, objectPos.transform.parent);
    }
}
