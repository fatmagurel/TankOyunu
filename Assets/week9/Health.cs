using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    float health;
    public Text healthText;

    // Use this for initialization
    void Start () {

        health = 100f;
        healthText.text = health.ToString();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
        healthText.text = health.ToString();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
