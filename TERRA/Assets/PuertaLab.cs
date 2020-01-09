using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PuertaLab : MonoBehaviour
{

    public bool puertaIzq, puertaDer;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PuertaDer")//compara si hizo la colision con el objeto correcto
        {
            puertaDer = true;
            
        }
        if (collision.name == "PuertaIzq")
        {
            puertaIzq = true;   
        }

    }
       
        public void OnTriggerExit2D(Collider2D LabDoor)
        {
            puertaDer = false;
            puertaIzq = false;
        }
        
        // Update is called once per frame
        
    
    void FixedUpdate()
        {
            if (puertaIzq == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(5.42f, -1.82f, 0);
                transform.localScale = new Vector3(1f, 1f, 1f);
                puertaIzq = false;

            }
            if (puertaDer == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
            {
               transform.position = new Vector3(2.67f, -1.82f, 0);
               transform.localScale = new Vector3(1f, 1f, 1f);
               puertaDer = false;
            }
        }
       
    }


