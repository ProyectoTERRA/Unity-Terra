using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPLay : MonoBehaviour
{
    public void CargarJuego(string jugar)
    {
        SceneManager.LoadScene(jugar);
    }

    public void salir()
    {
        Application.Quit();
    }
}
