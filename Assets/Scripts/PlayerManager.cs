using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int m_sanidadActual;
    GameManager gameManager;
    //barra de sanidad
    //alucionaciones
    //alteracion de movimiento
    BarStates barStates;
    float timeActual;
    int barra;
    private void Start()
    {
        barStates = BarStates.Normal;
        gameManager=GetComponent<GameManager>();
    }
    public void Barra(float time)
    {
        if (time %2<=0.1f && time<timeActual)
        {
            timeActual = time;
            barra += 1;
            Debug.Log(barra);
        }
    }
    public void DecisionManager()
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
        else if (barra <= 5)
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
                break;
            case BarStates.Mal:
                break;

        }
    }
    public int BarSanidad(int sanidadPerdida)
    {
        m_sanidadActual -= sanidadPerdida;
        return m_sanidadActual;
    }
    public int BarSanidadMas(int sanidadRecuperada)
    {
        m_sanidadActual += sanidadRecuperada;
        return m_sanidadActual;
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
    private enum BarStates
    {
        None,
        Normal,
        MasomenosNormal,
        Masomenos,
        MasomenosMal,
        Mal,

    }
}
