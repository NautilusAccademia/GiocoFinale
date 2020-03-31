using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveElement : MonoBehaviour
{
    [SerializeField]
    public GameObject ElementPos;
    [SerializeField]
    public GameObject[] ElementInstantiated;

    // Start is called before the first frame update
    void Start()
    {

        //ElementInstantiated[0].SetActive(false);
        //ElementInstantiated[1].SetActive(false);
        //ElementInstantiated[2].SetActive(false);
        //ElementInstantiated[3].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFire()
    {
        ElementInstantiated[0].SetActive(true);
        Instantiate(ElementInstantiated[0], ElementPos.transform.position, Quaternion.identity, ElementPos.transform.parent);
    }
    public void SpawnWater()
    {
        ElementInstantiated[1].SetActive(true);
        Instantiate(ElementInstantiated[1], ElementPos.transform.position, Quaternion.identity, ElementPos.transform.parent);
    }
    public void SpawnAir()
    {
        ElementInstantiated[2].SetActive(true);
        Instantiate(ElementInstantiated[2], ElementPos.transform.position, Quaternion.identity, ElementPos.transform.parent);
    }
    public void SpawnEarth()
    {
        ElementInstantiated[3].SetActive(true);
        Instantiate(ElementInstantiated[3], ElementPos.transform.position, Quaternion.identity, ElementPos.transform.parent);
    }

    public void DestroyElement()
    {
        if (transform.childCount > 1)
        {
            Destroy(GetComponent<Transform>().GetChild(1).gameObject); 
        }
        //
        //Destroy(GetComponent<GameObject>().name.Equals("Fire(Clone)");
    }
    public void DestroyWater()
    {

    }
    public void DestroyAir()
    {

    }
    public void DestroyEarth()
    {

    }
}
