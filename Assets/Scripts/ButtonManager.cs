using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    enum State
    {
        None,
        Resume,
        Pause,
        GameOver
    }

    [SerializeField] State state;
    void changeState(State newState)
    {
        if (newState == state)
        {
            return;
        }

        state = newState;

        switch (state)
        {
            case State.None:
                break;
            case State.Resume:
                ButtonResume();
                break;
            case State.Pause:
                ButtonPause();
                break;
            case State.GameOver:
                ButtonPause();
                break;

        }
    }
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
    public void ButtonCredits()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonPause()
    {
        Time.timeScale = 0;
    }
    public void ButtonGoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtonResume()
    {
        Time.timeScale = 1;
    }
    
}
