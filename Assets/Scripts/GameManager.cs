using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameState {
        None,
        Play,
        Pause,
        GameOver

    }

    [SerializeField]GameState gameState;
    public float dayDuration;
    private float timer;
    [SerializeField]private int currentDay;


    void Update() {

        if (gameState == GameState.Play) {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f) {
            if (currentDay == 3) {
                changeGameState(GameState.GameOver);
            }
            ChangeDay();
            
        }
    }

    private void ChangeDay() {
        timer = dayDuration;
        currentDay++;
    }

    void Start() {
        
        timer = dayDuration;
        currentDay = 0;
        changeGameState(GameState.Play);
    }

    void changeGameState(GameState newState) {
        if (newState == gameState) {
            return;
        }

        gameState = newState;

        switch (gameState) {
            case GameState.None: 
                break;
            case GameState.Play:
                break;
            case GameState.Pause:
                break;
            case GameState.GameOver:
                break;

        }
    }
}
