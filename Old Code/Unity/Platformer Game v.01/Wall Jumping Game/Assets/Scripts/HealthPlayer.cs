using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public float healthCounter = 100f;
    public Text healthText;
   // public ParticleSystem deff;

    
   


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = "HEALTH : " + healthCounter;

        Debug.Log(healthCounter);

        if (healthCounter <= 0)
        {
            DeathUwU();
        }
    }

    void DeathUwU()
    {
        Destroy(this.gameObject);
        FindObjectOfType<AudioManage>().Play("Death");
        //Instantiate(deff, transform.position, Quaternion.identity);
        StartCoroutine(deathCounter());
        SceneManager.LoadScene("Death");

        
       
    }

    private IEnumerator deathCounter()
    {
        yield return new WaitForSeconds(2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            healthCounter -= 20;
            rb.AddForce(new Vector2(-20f, 0f), ForceMode2D.Impulse);
        }

        if (collision.collider.tag == "Bullet")
        {
            healthCounter -= 10;
            rb.AddForce(new Vector2(-15f, 0f), ForceMode2D.Impulse);
        }
    }
}
