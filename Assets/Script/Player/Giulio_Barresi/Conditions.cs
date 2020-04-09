using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Conditions : MonoBehaviour
{
    public bool CheckCondition()
    {
        return SpecificCondition();
    }

    protected abstract bool SpecificCondition();
}
