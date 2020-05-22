using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.playerGameObject.transform.position = spawnPoint.transform.position;
            other.gameObject.GetComponent<Health>().DecreaseHealth();
        }
    }
}
