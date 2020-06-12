using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalsePickup : MonoBehaviour
{
    
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        
    }

    void SetCountText()
    {
        countText.text = GameManager.count.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.count++;
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
