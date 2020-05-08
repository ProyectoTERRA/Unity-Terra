using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjetivosGoal
{
    public TipoObjetivo TipoObj;

    public int MontoRequerido;
    public int MontoActual;
    public bool ObjetivoPers;
    
    public bool isReached()
    {
        
        return (MontoActual >= MontoRequerido);

    }

    public void EnemyKilled()
    {
        if (TipoObj == TipoObjetivo.Derrotar)
        {
            MontoRequerido++;

        }

    }

}

public enum TipoObjetivo
{
    Derrotar,
    Recoger,
    Personalizado

}
