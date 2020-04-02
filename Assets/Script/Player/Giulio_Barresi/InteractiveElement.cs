using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveElement : MonoBehaviour
{
    [SerializeField]
    public GameObject[] ElementInstantiated;

    public static InteractiveElement instance;

    private void Awake()
    {
        instance = this;
    }
    public void SpawnFire()
    {
        ElementInstantiated[0].SetActive(true);
    }
    public void SpawnWater()
    {
        ElementInstantiated[1].SetActive(true);
    }
    public void SpawnAir()
    {
        ElementInstantiated[2].SetActive(true);
    }
    public void SpawnEarth()
    {
        ElementInstantiated[3].SetActive(true);
    }

    public void DestroyElement()
    {
        foreach(GameObject gameObject in ElementInstantiated)
        {
            gameObject.SetActive(false);
        }
    }
}
