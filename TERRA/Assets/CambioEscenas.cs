using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    public string Cambio;
    public void CargarJuego(string Cambio)
    {
        SceneManager.LoadScene(Cambio);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Jugador")
        {
            Debug.Log("Colision Puerta");
            SceneManager.LoadScene("CalleLab");
        }
        
    }

}