using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminarEnemyesC3 : MonoBehaviour
{
    public static int guardias = 0;
    public GameObject puerta;
    void Update()
    {
        if(guardias == 7)
        {
            Debug.Log(guardias);
            puerta.SetActive(true);
        }
    }
}
