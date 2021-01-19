using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootshoot;
    int damage = 20;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(shootshoot.position, shootshoot.right);

        if (hitInfo)
        {
            enemy enemy = hitInfo.transform.GetComponent<enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
