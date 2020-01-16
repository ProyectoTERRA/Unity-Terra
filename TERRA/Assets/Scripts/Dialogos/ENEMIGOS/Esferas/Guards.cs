using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guards : MonoBehaviour
{
    public int life;
    void Start()
    {
        life = 100;
        
    }

    void Update()
    {
        if(life <= 0)
        {
            eliminarEnemyesC3.guardias++;
            Botones.enemigos++;
            Debug.Log("Guardias eliminados " + Botones.enemigos);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ahhh");

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
    IEnumerator lib()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<Watcher>().enabled = true;
    }

    }
