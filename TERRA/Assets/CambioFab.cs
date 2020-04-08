using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioFab : MonoBehaviour
{
    // Start is called before the first frame update
    public void CargarJuego(string jugar)
    {
        SceneManager.LoadScene(jugar);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Jugador")
        {
            Debug.Log("Colision Lab");
            SceneManager.LoadScene("FAB");
        }

    }
}
