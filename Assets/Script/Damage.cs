using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float pushPower;
    [SerializeField] float pushDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().DecreaseHealth();
            StartCoroutine(PushAwayCoroutine(other.gameObject.GetComponent<Rigidbody>()));
        }
    }

    private IEnumerator PushAwayCoroutine(Rigidbody rigidbody)
    {
        yield return new WaitForSeconds(pushDelay);
        PushAway(rigidbody);
    }

    public void PushAway(Rigidbody rigidbody)
    {
        Vector3 direction = (rigidbody.transform.position - transform.position);
        direction = new Vector3(direction.x, 0, direction.z).normalized;
        rigidbody.gameObject.GetComponent<PlayerController3>().StartIgnoreInput(); //riga per ignorare i controlli
        rigidbody.AddForce(direction * pushPower, ForceMode.Impulse);
        StartCoroutine(rigidbody.gameObject.GetComponent<PlayerController3>().EndIgnoreInputAfterCoroutine(
            rigidbody.gameObject.GetComponent<Health>().invincibilityTime));
    }

}
