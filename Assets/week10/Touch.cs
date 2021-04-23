using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : Sense
{
    Aspect aspect;

    public override void Initialize()//ilk bu çalışır.
    {
        
    }

    public override void UpdateSense()//sürekli çalışır.
    {
        if (aspect != null)
        {
            if (aType == aspect.aType)
            {
                Debug.Log(aspect + " Çok yakın");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        aspect = other.GetComponent<Aspect>();
    }

    private void OnTriggerExit(Collider other)
    {
        aspect = null;
    }
}
