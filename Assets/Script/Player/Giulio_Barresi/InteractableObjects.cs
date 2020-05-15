using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class InteractableObjects : MonoBehaviour
{
    void Start()
    {
        Initialize(); 
    }

   public virtual void Initialize()
   {

   }

    public virtual void SpecificInteraction()
    {
       
    }
}
