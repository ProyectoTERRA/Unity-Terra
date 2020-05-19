using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardsc3 : MonoBehaviour
{
    public int life;
    void Start()
    {
        life = 100;

    }
    string nombre1;
    void Update()
    {
        if (life <= 0)
        {
            eliminarEnemyesC3.guardias++;
            Debug.Log("Guardias eliminados " + eliminarEnemyesC3.guardias);
            Destroy(gameObject);
            nombre1 = gameObject.name;
            codificador();
        }
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Normal")
        {
            life = life - 50;
            string nombre = collision.gameObject.name;
            Destroy(GameObject.Find(nombre));
        }

        if (collision.gameObject.tag == "Tranqui")
        {
            life = life - 100;
            string nombre = collision.gameObject.name;
            Destroy(GameObject.Find(nombre));
        }

        if (collision.gameObject.tag == "Paraliz")
        {
            Debug.Log("ahhh");
            GetComponent<Watcher>().enabled = false;
            string nombre = collision.gameObject.name;
            StartCoroutine(lib());
            Destroy(GameObject.Find(nombre));
        }
    }
    private void codificador()
    {
        if(nombre1 == "e1")
        {
            GameController.e1 = true;
        }
        if (nombre1 == "e2")
        {
            GameController.e2 = true;
        }
        if (nombre1 == "e3")
        {
            GameController.e3 = true;
        }
        if (nombre1 == "e4")
        {
            GameController.e4 = true;
        }
        if (nombre1 == "e5")
        {
            GameController.e5 = true;
        }
        if (nombre1 == "e6")
        {
            GameController.e6 = true;
        }
        if (nombre1 == "e7")
        {
            GameController.e7 = true;
        }
    }

    IEnumerator lib()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<Watcher>().enabled = true;
    }
}
