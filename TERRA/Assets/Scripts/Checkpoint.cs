using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    SistemaGuardado sistemaGuardado;
    void Start()
    {
        sistemaGuardado = new SistemaGuardado();
        Debug.Log("Nombre de la partida en Start" + sistemaGuardado.nombrePartida);


    }
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Checkpoint")
        {
            Debug.Log("Nombre partida antes "+sistemaGuardado.nombrePartida);
            sistemaGuardado.nombreEscena = SceneManager.GetActiveScene().name;
            Debug.Log("Nombre escena antes " + sistemaGuardado.nombreEscena);
            sistemaGuardado.guardar();
            Debug.Log("Nombre partida despues " + sistemaGuardado.nombrePartida);
            Debug.Log("Nombre escena despues "  + sistemaGuardado.nombreEscena);

        }
    }
}
