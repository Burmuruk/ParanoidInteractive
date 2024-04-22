using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int m_sanidadActual;
    //barra de sanidad
    //alucionaciones
    //alteracion de movimiento
    BarStates barStates;
    private void Start()
    {
        barStates = BarStates.Normal;
    }
    private void FixedUpdate()
    {
        DecisionManager();
    }
    void DecisionManager()
    {
        if (m_sanidadActual == 5)
        {
            barStates=BarStates.Normal;
        }
        else if (m_sanidadActual == 4)
        {
            barStates = BarStates.MasomenosNormal;
        }
        else if (m_sanidadActual == 3)
        {
            barStates = BarStates.Masomenos;
        }
        else if (m_sanidadActual == 2)
        {
            barStates = BarStates.MasomenosMal;
        }
        else if (m_sanidadActual == 1)
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
    int BarSanidad(int sanidadPerdida)
    {
        m_sanidadActual -= sanidadPerdida;
        return m_sanidadActual;
    }
    int BarSanidadMas(int sanidadRecuperada)
    {
        m_sanidadActual += sanidadRecuperada;
        return m_sanidadActual;
    }
    bool imInteractive()
    {
        return true;
    }
    void Alucionaciones()
    {

    }
    void ChangeController()
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
