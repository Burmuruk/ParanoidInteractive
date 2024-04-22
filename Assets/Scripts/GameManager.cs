using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float dayDuration; 
    private float timer;
    
    

    void Update() {

        timer -= Time.deltaTime;

   
        if (timer <= 0f) {
                
            Debug.Log("¡Tiempo fuera!");


            ChangeDay();
        }
    }

    private void ChangeDay() {
        
    }

    void Start() {
        
        timer = dayDuration;
    }
    
}
