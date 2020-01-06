using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PuertaLab : MonoBehaviour
{

    public bool puertaIzq, puertaDer;
    GameObject Jugador;
    // Start is called before the first frame update
    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PuertaDer")//compara si hizo la colision con el objeto correcto
        {
            puertaIzq = true;
            Jugador.transform.position = new Vector3(5.42f, -1.82f, 0);
            Jugador.transform.localScale = new Vector3(1f, 1f, 1f);
            puertaIzq = false;
        }
        if (collision.name == "PuertaIzq")
        {
            puertaDer = true;
            Jugador.transform.position = new Vector3(2.67f, -1.82f, 0);
            Jugador.transform.localScale = new Vector3(1f, 1f, 1f);
            puertaDer = false;
        }

    }
        /*
        public void OnTriggerExit2D(Collider2D LabDoor)
        {

            if (LabDoor.gameObject.tag == "Player" && LabDoor.gameObject.tag == "PuertaIzq")
            {

                    puertaIzq = false;

            }

                if (LabDoor.gameObject.tag == "Player" && LabDoor.gameObject.tag == "PuertaDer")
                {
                    puertaDer = false;
                }
        }
        */
        // Update is called once per frame
        
    /*
    void FixedUpdate()
        {
            if (puertaIzq == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
            {
                Jugador.transform.position = new Vector3(5.42f, -1.82f, 0);
                Jugador.transform.localScale = new Vector3(1f, 1f, 1f);
                puertaIzq = false;

            }
            if (puertaDer == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
            {
                Jugador.transform.position = new Vector3(2.67f, -1.82f, 0);
                Jugador.transform.localScale = new Vector3(1f, 1f, 1f);
                puertaDer = false;
            }
        }
        */
    }


