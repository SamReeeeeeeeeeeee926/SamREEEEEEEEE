using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dullstar : MonoBehaviour
{
    public bool gotIt = false;
    public AudioSource emiting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreTextScript.coinAmount += 1000;
        gotIt = true;
        gameObject.SetActive(false);
     
        FindObjectOfType<AudioManage>().Play("Point Collect Dull");
    }
}
