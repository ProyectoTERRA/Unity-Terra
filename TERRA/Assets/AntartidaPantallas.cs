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
        if(collision.name == "A_1-2")
        {
            transform.position = new Vector3(30.56f, 17.83f,  1f);
        }

        if (collision.name == "A_2-3")
        {

        }

        if (collision.name == "A_3-4")
        {

        }

        if (collision.name == "A_4-5")
        {

        }

        if (collision.name == "A_5-6")
        {

        }

        if (collision.name == "BE_1-2")
        {

        }

        if (collision.name == "BE_2-3")
        {

        }

        if (collision.name == "BE_Final")
        {

        }
    }

    void FixedUpdate()
    {
        
    }
}
