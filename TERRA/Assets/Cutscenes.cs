using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public Animator transicion;
    public float transitionTime = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(CargarNivel());
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
}
