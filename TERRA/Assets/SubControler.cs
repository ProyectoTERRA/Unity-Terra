﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubControler : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D RBS;
    public GameObject Bufanda;
    public int life;
    public float tiempo = 15f;
    public float speed;
    public float DistanciaVision;
    GameObject Jugador;
    Vector3 PosicionInicial;
    private Transform MyTransform;
    public int rotationSpeed;
    void Start()
    {
        MyTransform = transform;
        RBS = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;

    }
    private void FixedUpdate()
    {
        Vector3 target = PosicionInicial;
        float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);
        if (distanciaJugador < DistanciaVision)
        {
            target = Jugador.transform.position;
            StopAllCoroutines();
        }
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);


        if ((distanciaJugador - DistanciaVision) < 6)
        {
            StartCoroutine(AtaqueBufanda());
        } else if (distanciaJugador > 10)
        {
            StopAllCoroutines();
        }
        ///if(System.Math.Abs(DistanciaVision - distanciaJugador) == 4f) Si está a 4 o menos de 4 unidades de distancia ataca
        //{
        //}
        Debug.DrawLine(transform.position, target, Color.red);

        if (life <= 15)
        {
            //Aumentar Velocidad
            speed = speed * 1.5f;
        }
        else if (life <= 8)

        {
            //Iniciar Segundo ataque

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("UnCorazon", transform.position.x);

        }
        else if (col.gameObject.tag == "BE")
        {
            DistanciaVision = 0;
        }
        else if (col.gameObject.tag == "BEReturn")
        {
            DistanciaVision = 20;
        }

    }
    // Update is called once per frame


    IEnumerator AtaqueBufanda()
    {
        Bufanda.SetActive(true);
        yield return new WaitForSeconds(2f);
        Bufanda.SetActive(false);
        yield return new WaitForSeconds(2f);
        StopAllCoroutines();
    }

    /*
    IEnumerator AtaqueBufandaAbajo()
    {

    }
    */

}
