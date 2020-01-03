using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaFuera : MonoBehaviour
{
    bool puertaprin = false;
    bool puertaSal = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "puerta")
        {
            puertaprin = true;
            Debug.Log("Colision Izq");

        }

        if (collision.name == "PuertaDer")
        {
            puertaSal = true;
            Debug.Log("Colision Der");

        }
    }

    void FixedUpdate()
    {
        if (puertaprin == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(33.08f, -1.57f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaprin = false;
        }
    }
}
