using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense {

    public Transform player;
    float viewDistance;//görebileceği max uzaklık
    float fieldOfView;//tankın görme alanının açısı
    public Transform rayOrigin;

    public override void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewDistance = 20;
        fieldOfView = 60;
    }

    public override void UpdateSense()
    {
        Vector3 dir = (player.position - rayOrigin.position).normalized;//birim vektör
        
        if(Vector3.Angle(dir, transform.forward) < fieldOfView/2f)//angle iki vektör arasındaki açıyı hesaplar.
        {
            Debug.DrawRay(rayOrigin.position, dir * viewDistance, Color.black);
            RaycastHit hitInfo;
            if(Physics.Raycast(rayOrigin.position, dir, out hitInfo, viewDistance))//tankın göründüğü alana doğru ışın göndersin.
            {
                Aspect aspect = hitInfo.transform.GetComponent<Aspect>();//aspectine bak dost mu düşman mı

                if(aspect)//aspect null değilse, aspect varsa
                {
                    if (aspect.aType == aType)//düşmansa
                    {
                        Debug.Log(aType + "göründü");
                    }

                }
            }
        }
    }
    
}
