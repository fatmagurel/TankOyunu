using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //yapay zeka kütüphanesi

public class TankAI : MonoBehaviour {

    //public Transform target; //gideceği hedef
    public Transform p1, p2;
    Vector3[] points;
    public Transform player; //playertankın bilgisi
    int currentIndex;
    float maxCheckDistance = 20;
    NavMeshAgent agent; //yapay zeka kütüphanesi lazım.Navigasyon özelliği var, ajan. nav mesh nesnesine ulaşır.
    Animator fsmAI; //animatorden fsmAI alınır unity den.
    float rotSpeed = 5f;
    public Transform RayOrigin;
    // Use this for initialization

    void Start () {
        points = new Vector3[] { p1.position, p2.position };//noktaların pozisyonları
        fsmAI = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();//nesne alınır.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentIndex = 0;
        agent.SetDestination(points[currentIndex]);//ajanın gideceği yeri set eder.
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!player) return;
        float distance = Vector3.Distance(player.position, transform.position);//(player.position - transform.position).magnitude;
        //playerla enemy arasındaki mesafe
        fsmAI.SetFloat("distance", distance);//unitydeki distance ı alır.

        Vector3 dir = (player.position - RayOrigin.position).normalized;  //yön vektörü. birim vektor olacak.

        

        float disFromWayPoint = Vector3.Distance(transform.position, points[currentIndex]);//enemytank ile o an ki nokta arasındaki uzaklık. 
        fsmAI.SetFloat("distanceFromWayPoint", disFromWayPoint);

        //set visibilty
        Debug.DrawRay(RayOrigin.position, dir * maxCheckDistance, Color.red);//ışın çizilir,görsel.
        RaycastHit hitInfo;//ateş edildiğinde canı azalacak o yüzden hitınfo lazım

        Ray ray = new Ray(transform.position, dir);
        
        

        if (Physics.Raycast(RayOrigin.position, dir, out hitInfo, maxCheckDistance))//tankın merkezinden dire doğru 20 birimlik ışın.
        {
            if (hitInfo.transform.tag == "Player")//çarptığı nesne tagı playersa
            {
                fsmAI.SetBool("isVisible", true);
            }
            else
                fsmAI.SetBool("isVisible", false);
        }
        else
            fsmAI.SetBool("isVisible", false);
        if (!player) return;
    }
        
       
        //points[0] = waypointsTransform[0].position;
        //points[1] = waypointsTransform[1].position;
        //agent.SetDestination(target.position);//sürekli yeni yolu hesaplamak için destination kullanılır.

        //Vector3 dir = (playerTank.position - transform.position).normalized;//tanktan playera gönderilcek.yön vektörü 
        ////fark kadar büyük bir vektör.normalized dersek birim vektöre çevirir.yönü aynı kalmak şartı ile.

        //float distance = Vector3.Distance(playerTank.position, transform.position);//ikisinin arasındaki mesafe
        //fsmAI.SetFloat("distance", distance);

        //float distanceFromWayPoint = Vector3.Distance(points[currentIndex], transform.position);
        //fsmAI.SetFloat("distanceFromWayPoint", distanceFromWayPoint);
        //Ray ray = new Ray(transform.position, dir);
        //RaycastHit hitInfo; //çarptığı nesne hakkında bilgi verir.
        //Debug.DrawRay(ray.origin, ray.direction * maxCheckDistance, Color.red);//ışın çizilir.
        //if (Physics.Raycast(ray,out hitInfo, maxCheckDistance))
        //{
        //    if (hitInfo.transform.tag == "Player")
        //    {
        //        fsmAI.SetBool("isVisible", true);//ışın kesiyorsa visible true olcak.değer bool olduğu için setbool.
        //    }
        //    else
        //        fsmAI.SetBool("isVisible", false);

        //}
        //else
        //    fsmAI.SetBool("isVisible", false);


    //}

        

    public void SetLookRotation()//bir noktaya geldiğinde hedefi değiştirir.FSM de kullanılcak.
    {
        if (!player) return;

        switch (currentIndex)
        {
            case 0:
                currentIndex = 1;
                break;
            case 1:
                currentIndex = 0;
                break;
        }
        agent.SetDestination(points[currentIndex]);

        
    }

    public void Shoot()
    {
        if (!player) return;
        Quaternion rot = new Quaternion();
        Vector3 dir = (player.position - transform.position).normalized;
        rot.SetLookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotSpeed * Time.deltaTime);

        gameObject.GetComponent<Shooting>().Shoot();
        if (!player) return;
    }

    public void Patrol()
    {
        Debug.Log("Patrolling");
    }

    public void Chase()
    {
        if (!player) return;
        agent.SetDestination(player.position);
    }
}
