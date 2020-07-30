using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    public ParticleSystem Coin;

    private void Awake()
    {
        //Coin = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreTextScript.coinAmount += 10;
        Instantiate(Coin, transform.position, Quaternion.identity);
        Destroy(gameObject);
        FindObjectOfType<AudioManage>().Play("Point Collect");
    }
}
