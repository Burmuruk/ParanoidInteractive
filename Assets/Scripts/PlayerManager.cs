using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameManager gameManager;
    WalkiesManager walkiesManager;
    //barra de sanidad
    //alucionaciones
    //alteracion de movimiento
    public BarStates barStates;
    float timeActual;
    int barra;
    HallucinationManager hallucinationManager;

    private void Start()
    {
        barStates = BarStates.Normal;
        gameManager=GetComponent<GameManager>();
        walkiesManager = GetComponent<WalkiesManager>();
        hallucinationManager = FindObjectOfType<HallucinationManager>();
    }
    private void Update()
    {
        
    }
    public void BarraTime(float time)
    {
        if (time > 0 && time % 2<=0.01f && time > timeActual * 2 - .1)
        {
            timeActual = time;
            barra += 1;
            DecisionManager(barra);
        }
    }
    public void DecisionManager(int barra)
    {
        if (barra == 1)
        {
            barStates=BarStates.Normal;
        }
        else if (barra == 2)
        {
            barStates = BarStates.MasomenosNormal;
        }
        else if (barra == 3)
        {
            barStates = BarStates.Masomenos;
        }
        else if (barra == 4)
        {
            barStates = BarStates.MasomenosMal;
        }
        else if (barra > 4)
        {
            barStates = BarStates.Mal;
        }
       
        ActionManager();
    }
    void ActionManager()
    {
        switch (barStates)
        {
            case BarStates.None:
                break;
            case BarStates.Normal:
                break;
            case BarStates.MasomenosNormal:
                break;
            case BarStates.Masomenos:
                break;
            case BarStates.MasomenosMal:
                (hallucinationManager ??= FindObjectOfType<HallucinationManager>()).ShowHallucination();
                break;
            case BarStates.Mal:
                (hallucinationManager??= FindObjectOfType<HallucinationManager>()).ShowHallucination();
                break;
        }
    }
    public int BarSanidad(int sanidadPerdida)
    {
        barra -= sanidadPerdida;
        DecisionManager(barra);
        return barra;
    }
    public int BarSanidadMas(int sanidadRecuperada)
    {
        barra += sanidadRecuperada;
        DecisionManager(barra);
        return barra;
    }
    public bool imInteractive()
    {
        return true;
    }
    public void Alucionaciones()
    {

    }
    public void ChangeController()
    {

    }
    public enum BarStates
    {
        None,
        Normal,
        MasomenosNormal,
        Masomenos,
        MasomenosMal,
        Mal,

    }
}
