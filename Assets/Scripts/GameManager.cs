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
    public static float timer;
    [SerializeField] private int currentDay;
    public float tiempo;
    List<IMissionTimer> missionsTime;

    void Update() {

        if (gameState == GameState.Play) {
            timer += Time.deltaTime;
            tiempo = timer;
        }

        if (timer >= dayDuration * 3600) {
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
        
        timer = 0;
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
