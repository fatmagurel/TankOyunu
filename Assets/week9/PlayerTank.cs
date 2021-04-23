using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour {

    float movementAxis, turnAxis;
    public float moveSpeed=5, rotSpeed=5;
    //public Transform targetPoint; //tank tıklanan yere gitsin.
	
	// Update is called once per frame
	void Update () {

        //if(Vector3.Distance(transform.position, targetPoint.position) > 3)//tankla hedef noktası arasındaki mesafe 3 ten büyükse hedefe gototarget fonksiyonuna gitsin.
        //{
        //    GoToTarget();
        //}

        movementAxis = Input.GetAxisRaw("Vertical");
        turnAxis = Input.GetAxisRaw("Horizontal");
        transform.position += transform.forward * movementAxis * moveSpeed * Time.deltaTime;//mevcut pozisyonda ileri yönde gidecek.
        Vector3 rotVector = new Vector3(0, 1, 0) * turnAxis * rotSpeed * Time.deltaTime;//y ekseni etrafında döndürülür.
        transform.Rotate(rotVector);
        //transform.Translate(Vector3.forward * movementAxis * moveSpeed * Time.deltaTime);

    }

    //private void GoToTarget()
    //{
    //    Vector3 dir = (targetPoint.position - transform.position).normalized;   direction lazım.playerdan targetpointe 
    //    Quaternion lookRotation = Quaternion.LookRotation(dir);   o yöne doğru baksın.
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotSpeed * Time.deltaTime);
    //    transform.position += transform.forward * moveSpeed * Time.deltaTime;    ileri doğru gitsin.
    //}
}
