
using UnityEngine;

public class Shell : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
