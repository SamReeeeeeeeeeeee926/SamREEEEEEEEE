﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 35f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        enemy enemy = hitInfo.GetComponent<enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(30);
        }
        Destroy(gameObject);

    }

}
