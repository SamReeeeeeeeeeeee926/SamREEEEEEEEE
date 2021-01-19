using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   

    //Floats

        //Public
    public float moveSpeed = 28f;
    public float jumpF = 30f;
    public float deathCounter;
    public float fallMulti = 10f;
    public float lowJumpMulti = .5f;
    public float jumpT;
    public float faceR = -1;

        //Private
    private float horizontal;

    //Bools
    public bool canJump = false;
    private bool isWallT= false;
    private bool isWallJ = false;
    private bool isJumping;
    
    
    //Mechanics
    Rigidbody2D player;

    //Other
    // public ParticleSystem dust1;
    // public ParticleSystem deff;
    public Animator animator;
    



    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
      
    }
    
    void FixedUpdate()
    {

        //Functions
        Jump();
       
       
        //Movement
        float movement = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(movement * moveSpeed, player.velocity.y);
        animator.SetFloat("velocity", Mathf.Abs(movement));
  
        
    }

    void Update()
    {
        //Functions
        Death();
        Flip();
        Debug.Log(canJump);
        Debug.Log(isWallT); 

    }

    void Jump()
    {
        //Normal Jump
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            
           // CreateDust1();
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpF), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);

        }

        //Wall Jumping
        if (Input.GetButtonDown("Jump") && isWallJ == true && canJump == true)
        {
            
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(faceR, 4f), ForceMode2D.Impulse);
            isJumping = true;
            isWallT = false;
            animator.SetBool("isJumping", true);
        }


        //Wall Sliding
        if (isWallT == true)
        {
            
            player.velocity = new Vector2(player.velocity.x, -0.7f);
            isWallJ = true;
            animator.SetBool("isWallJumping", true);
           
        }
        
        //Jump "Feel"
        if(player.velocity.y < 0)
        {
            player.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }else if( player.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            player.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMulti - 1) * Time.deltaTime;
        }


    }

    void Death()
    {

        //Fall Damage
        if (canJump == false)
        {
            deathCounter++;
       
        }else
        {
            deathCounter = 0;
        }

        
    }

    void Flip()
    {
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0)
        {
            Debug.Log("Right");
            characterScale.x = -4;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {

            Debug.Log("Left");
            characterScale.x = 4;
        }
        transform.localScale = characterScale;
        
    }

    //Feet Dust?
    void CreateDust1()
    {
      // dust1.Play();
    }

   
    //COLLISIONS/OTHER STUFF I DON'T UNDERSTAND
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if(collision.collider.tag == "Back")
        {
            canJump = true;
            animator.SetBool("isJumping", false);
            animator.SetBool("isWallJumping", false);



            if (deathCounter >= 500)
            {

                Destroy(this.gameObject);
                FindObjectOfType<AudioManage>().Play("Death");
                //Instantiate(deff, transform.position, Quaternion.identity);
                StartCoroutine(deathCount());
                SceneManager.LoadScene("Death");
            }

        }

       

        if (collision.collider.tag == "Wall")
        {
            canJump = true;
            isWallT = true;

            animator.SetBool("isJumping", false);
            animator.SetBool("isWallJumping", true);



        }

        
    }

    private IEnumerator deathCount()
    {
        yield return new WaitForSeconds(4);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Back")
        {
            canJump = false;
            isWallJ = false;
        }

        if (collision.collider.tag == "Wall")
        {
            isWallT = false;
            canJump = false;
        }

        
    }

}

