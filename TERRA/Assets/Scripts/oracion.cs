﻿using System.Collections;
using UnityEngine;

public class oracion : MonoBehaviour
{
    public GameObject llave;
    public static string frase;
    public static int contador;
    public GameObject hoja, mensaje, mensaje1;
    int i = 0;

    void Update()
    {
        if (GameController.llave > 1)
        {
            llave.SetActive(false);
        }
        if (contador == 15)
        {
            Debug.Log(frase + " " + contador);
            if (frase == "bbcddcbaggabbaa")
            {
                
                if (i == 0)
                {
                    hoja.SetActive(true);                    
                    i++;
                }
                Debug.Log("Logrado");
            }
            else
            {
                Debug.Log("Fail");
                frase = "";
                contador = 0;
                mensaje.SetActive(true);
                StartCoroutine(test());
            }
        }
    }
    public IEnumerator test()
    {
        yield return new WaitForSeconds(3);
        mensaje.SetActive(false);
    }
    public IEnumerator test1()
    {
        yield return new WaitForSeconds(5);
        mensaje1.SetActive(false);
    }
}
