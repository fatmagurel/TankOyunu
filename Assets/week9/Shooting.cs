using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Transform shellSpawn;
    public GameObject shellPrefab;
    float moveSpeed=1500f;
    public bool isAI;

    private void FixedUpdate()
    {
        if (isAI) return;
        if(Input.GetKey(KeyCode.Mouse0))
            Shoot();
    }
    float nextShoot = 0f;
    float elapsedTime;

    public void Shoot()
    {
        elapsedTime = Time.time;
        if (elapsedTime > nextShoot)
        {
            GameObject shell = Instantiate(shellPrefab, shellSpawn.position, Quaternion.identity);
            Rigidbody rb = shell.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
            nextShoot = elapsedTime + 0.5f;
        }
    }

    
}
