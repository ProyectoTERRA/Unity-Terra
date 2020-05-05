using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CUTSCENEBACK : MonoBehaviour
{
    public Animator transicion;
    public float transitionTime = 1;
    public GameObject jugador;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Esto se personaliza
        if (collision.gameObject.tag == "Player")
        {
          LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(CargarNivel2(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator CargarNivel2(int levelIndex)
    {
        //Reproducir Animacion
        transicion.SetTrigger("Start");
        //Esperar a que termine
        yield return new WaitForSeconds(transitionTime);
        //Cargar Escena
        Debug.Log("CARGANDO ESCENA...");
        SceneManager.LoadScene(levelIndex);
    }

}
