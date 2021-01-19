﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health = 100;
    public Text healthText;

   
    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH : " + health; 
    }
}
