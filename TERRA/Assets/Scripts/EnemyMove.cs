﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float maxspeed;
    public float DistanciaVision;

    GameObject Jugador;

    Vector3 PosicionInicial;
    Vector3 target;
    private Rigidbody2D rbd2;
    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;
        target = PosicionInicial;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Funciones para Seguimiento del Jugador
        Vector3 target = PosicionInicial;
        //Si la distancia al jugador es menor que el radio de vision del objetivo, el target pasa a ser el jugador
        float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);
        if (distanciaJugador < DistanciaVision) target = Jugador.transform.position;
        //Movimiento del Enemigo
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, target, Color.red);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DistanciaVision = 5;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        /*if (col.gameObject.tag == "Player" && PlayerController.movement)
        {
            col.SendMessage("EnemyKnockBack", transform.position.x + 1);

        }*/
        if (col.gameObject.tag == "BE")
        {
            DistanciaVision = 0;
        }


    }
}
