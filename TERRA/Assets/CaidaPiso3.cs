using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaPiso3 : MonoBehaviour
{
    public GameObject Jugador;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Jugador = GetComponent<GameObject>();
        if(collision.name == "Player")
        {
            //Hacer Daño
            Jugador.transform.position = new Vector3(196.8f, 66f, 0f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
