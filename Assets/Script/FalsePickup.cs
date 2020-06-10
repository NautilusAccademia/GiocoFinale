using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalsePickup : MonoBehaviour
{
    static private int count;
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        
    }

    void SetCountText()
    {
        countText.text = count.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            count++;
            SetCountText();
            AudioManager.instance.PlayCollectible();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
        //transform.position.y
    }
}
