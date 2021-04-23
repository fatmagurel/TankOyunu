using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    // Use this for initialization

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateRayAndCast();
        }

    }

    private void CreateRayAndCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//ekranda basılan yere ışın gönderir.

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
        {
            transform.position = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z);//y sini değiştirmeyecek şekilde x i ve z yi oraya götürecek.
        }
    }
}
