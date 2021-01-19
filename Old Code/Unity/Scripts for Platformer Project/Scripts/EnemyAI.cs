using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class EnemyAI : MonoBehaviour
{
    //This code was taken from Brakeys hehe



    public Transform target;
    public float speed;
    public float nextWD = 3f;
    public Transform enemyGFX;

    Path path;
    int currentWP = 0;
    bool ReachedEndofPath;


    Seeker seeker;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(100f, 300f);

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

        
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWP = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        
        }
        if(currentWP >= path.vectorPath.Count)
        {
            ReachedEndofPath = true;
            return;
        }
        else
        {
            ReachedEndofPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWP] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWP]);

        if(distance < nextWD)
        {
            currentWP++;
        }

        if(rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }else if(rb.velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
       
 
    }
}
