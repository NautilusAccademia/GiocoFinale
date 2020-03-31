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

    public static bool portalActivated; //elisa

    // Start is called before the first frame update
    void Start()
    {
        Portal.SetActive(false);
        portalActivated = false; //elisa
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
        portalActivated = true; //elisa
    }
}
