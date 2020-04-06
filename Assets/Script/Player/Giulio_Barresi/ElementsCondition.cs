using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsCondition : Conditions
{
    [SerializeField] GameManager.Elements elementofCondition;

    protected override bool SpecificCondition()
    {
        return elementofCondition == PlayerInteraction.instance.elementInHand;
    }
}
