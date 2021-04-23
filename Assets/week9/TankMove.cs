
using UnityEngine;

public class TankMove : MonoBehaviour {

    public float moveSpeed, turnSpeed;
    Vector3 randomTargetPoint= Vector3.zero;
    float minX, maxX, minZ, maxZ;
    float value = 15;
	// Use this for initialization
	void Start () {

        minX = -value;
        maxX = value;
        minZ = -value;
        maxZ = value;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, randomTargetPoint) <1f)
            FindNewRandomPoint();
        MoveToTarget();
	}

    private void FindNewRandomPoint()
    {
        float xRandom = Random.Range(minX, maxX);
        float zRandom = Random.Range(minZ, maxZ);
        randomTargetPoint = new Vector3(xRandom, transform.position.y, zRandom);
    }

    private void MoveToTarget()
    {
        Vector3 dir = (randomTargetPoint - transform.position).normalized;
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //transform.Rotate()
    }
}
