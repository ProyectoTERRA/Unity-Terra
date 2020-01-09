using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntartidaPantallas : MonoBehaviour
{
    GameObject Jugador;
    
    void Start()
    {
            Jugador = GameObject.Find("Player");
        }

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "BE_2-3")
        {
            transform.position = new Vector3(473.64f, 18.2f,  1f);
        }

        if (collision.name == "BE_Final")
        {
            transform.position = new Vector3(576, 20.84f, 1f);
        }

        if (collision.name == "A_3-4")
        {
            transform.position = new Vector3(278.5f, 14.37f, 1f);
        }

        if (collision.name == "A_4-5")
        {
            transform.position = new Vector3(353.9f, 14.37f, 1f);
        }

        if (collision.name == "A_5-6")
        {
            transform.position = new Vector3(467.8f, 17.77f, 1f);
        }

        if (collision.name == "BE_1-2")
        {
            transform.position = new Vector3(534.2f, 19.2f, 1f);
        }


    }

    void FixedUpdate()
    {
        
    }
}
