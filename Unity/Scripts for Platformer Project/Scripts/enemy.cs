using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEff;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Instantiate(deathEff, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
