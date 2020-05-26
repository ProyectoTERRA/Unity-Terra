using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivosMenu : MonoBehaviour
{
    public static bool Pausado = false;
    public GameObject MenuPausa;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Pausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Reanudar()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1f;
        Pausado = false;
    }

    void Pausa()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0f;
        Pausado = true;
    }
}
