using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public Animator transicion;
    public float transitionTime = 1;
    public GameObject trans, jugador;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trans = GetComponent<GameObject>();
        trans.SetActive(true);

        if (collision.gameObject.tag == "Player" && collision.gameObject.name == "trans")
        {
            jugador.SetActive(false);
        }
        if (collision.gameObject.tag == "Player")
        {
            LoadNextLevel();
        }

        if (collision.gameObject.name == "trans")
        {
            LoadNextLevel2();
        }
    }


    IEnumerator CargarNivel()
    {
        //Reproducir Animacion
        transicion.SetTrigger("inicio");

        //Esperar a que termine
        yield return new WaitForSeconds(transitionTime);
        //Cargar Escena
        SceneManager.LoadScene("LABCUTSCENE");
    }

    IEnumerator CargarNivel2()
    {
        //Reproducir Animacion
        transicion.SetTrigger("inicio");

        //Esperar a que termine
        yield return new WaitForSeconds(transitionTime);
        //Cargar Escena
        SceneManager.LoadScene("Lab");
    }


    public void LoadNextLevel()
    {
        StartCoroutine(CargarNivel());

    }
    public void LoadNextLevel2()
    {
        StartCoroutine(CargarNivel2());

    }
}
   

