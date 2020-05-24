using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : InteractBy
{
    [SerializeField] GameObject gameObject;

    private void Update()
    {
        if(interacted == true)
        {
            gameObject.SetActive(false);
            HUD.instance.infoEImage.enabled = false;
        }
    }
}
