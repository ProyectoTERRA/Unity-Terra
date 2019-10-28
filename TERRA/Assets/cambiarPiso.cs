using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarPiso : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Puerta")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado la puerta");
            transform.position = new Vector3(7f, 2.25f, 0);//manda la nueva ubicación del jugador
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (collision.gameObject.tag == "Puerta2")
        {
            Debug.Log("Has tocado la puerta2");
            transform.position = new Vector3(-5.5f, 8f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (collision.gameObject.tag == "Pasar")
        {
            Debug.Log("Has tocado la puerta3");
            transform.position = new Vector3(7f, 13.04f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(collision.name == "escalerasBajar")
        {
            Debug.Log("escalerasBajar");
            transform.position = new Vector3(7f, -3.53f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (collision.name == "escalerasBajar2")
        {
            Debug.Log("escalerasBajar2");
            gameObject.transform.position = new Vector3(-7f, 2.31f, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (collision.name == "escalerasBajar3")
        {
            Debug.Log("escalerasBajar3");
            gameObject.transform.position = new Vector3(7f, 8f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
