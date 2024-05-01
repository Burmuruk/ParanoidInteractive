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
    static public float timer;
    [SerializeField] private int currentDay;
    public static float time;
    List<IMissionTimer> missionsTime;
    MissionManager missionManager;
    PlayerManager playerManager;
    float oneHour = 0;
    float oneDay = 0;

    public event Action OnDayStarted;
    public event Action OnDayFinished;

    private void Awake()
    {
        missionManager = FindObjectOfType<MissionManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        oneDay = dayDuration * 60;
        oneHour = oneDay / 12;
    }

    void Update() {

        if (gameState == GameState.Play) {
            timer += Time.deltaTime;
            time = timer / oneHour;
        }

        if (timer >= oneDay) {
            if (currentDay == 3) {
                OnDayFinished?.Invoke();
                changeGameState(GameState.GameOver);
            }
            ChangeDay();
        }
        playerManager.Barra(time);
    }

    private void ChangeDay() {
        timer = dayDuration;
        currentDay++;
        OnDayStarted?.Invoke();
    }
   
    void Start() {
        
        timer = 0;
        currentDay = 0;
        changeGameState(GameState.Play);

        OnDayStarted += missionManager.ChangeDay;
    }

    void changeGameState(GameState newState) 
    {
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
