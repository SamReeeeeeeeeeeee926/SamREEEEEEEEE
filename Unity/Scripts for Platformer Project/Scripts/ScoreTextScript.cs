﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text text;
    public static int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        coinAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "POINTS:" + " " + coinAmount.ToString();
    }
}