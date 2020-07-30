using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    float dirX, moveSpeed = 2f;
    bool moveRight = true;
    float point;

   
    // Update is called once per frame
    void FixedUpdate()
    {
        
        

      if(transform.position.x > 24f)
        {
            moveRight = false;
        }

      if(transform.position.x < -24f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

    }
}
