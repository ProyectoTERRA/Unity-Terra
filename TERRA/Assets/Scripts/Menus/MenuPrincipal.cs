using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
   
        public void CargarJuego(string jugar)
        {
            SceneManager.LoadScene(jugar);
        }

        public void salir()
        {
            Application.Quit();
        }
    // Start is called before the first frame update

}
