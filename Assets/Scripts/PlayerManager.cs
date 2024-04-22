using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //barra de sanidad
    //alucionaciones
    //alteracion de movimiento

    int BarSanidad(int sanidadActual, int sanidadPerdida)
    {
        sanidadActual -= sanidadPerdida;
        return sanidadActual;
    }
    int BarSanidad(int sanidadActual, int sanidadRecuperada, int sanidad)
    {
        sanidadActual += sanidadRecuperada;
        sanidad = sanidadActual;
        return sanidad;
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
}
