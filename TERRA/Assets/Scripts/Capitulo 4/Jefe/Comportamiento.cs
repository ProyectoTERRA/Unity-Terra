using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Comportamiento : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public float speed = 4f;
    public float maxspeed = 4f;
    public float DistanciaVision;

    public float Jumpower;
    bool jump;
    public float distancia;

    private Color color;
    GameObject Jugador;
    Vector2 PosicionInicial;

    public GameObject sedante;

    int movimiento;

    private Rigidbody2D rbd2;
    void Start()
    {
        movimiento = 1;
        rbd2 = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("EnemyKnockBack", transform.position.x + 1);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            jump = true;
        }
    }
    void FixedUpdate()
    {
        Vector2 target = PosicionInicial;

        float distanciaJugador = Vector2.Distance(Jugador.transform.position, transform.position);
        
        if (movimiento == 1)
        {  
            if (distanciaJugador > DistanciaVision)
            {
                target = Jugador.transform.position;
                float fixedSpeed = speed * Time.deltaTime; Debug.Log("Izquierda");
                transform.position = Vector2.MoveTowards(transform.position, target, fixedSpeed);
            }
            if(distanciaJugador <= DistanciaVision)
            {
                var pl = GameObject.Find("JefeMisterioso");
                Debug.Log("Dispara");
            }
            
            StartCoroutine(espera());
        }
        if (distanciaJugador < distancia)
        {
            Vector2 mover;
            Debug.Log("Retirarse   " + transform.forward);
            if (transform.position.x < Jugador.transform.position.x)
            {
                mover = new Vector2(-transform.position.x + 0.4f, transform.position.y);
                rbd2.AddForce(mover * 1.0f);
            }
            else
            {
                mover = new Vector2(transform.position.x + 0.4f, transform.position.y);
                rbd2.AddForce(mover * 1.0f);
            }
        }
        Debug.Log("DIstanciade jugador " + distanciaJugador);
        if (movimiento == 2) { StartCoroutine(lib()); }
        
        if (jump)
        {
            rbd2.velocity = new Vector2(rbd2.velocity.x, 0);
            rbd2.AddForce(Vector2.up * Jumpower, ForceMode2D.Impulse);
            jump = false;
        }

        Debug.DrawLine(transform.position, target, Color.red);
    }
    IEnumerator lib()
    {
        yield return new WaitForSeconds(2);
        movimiento = 1;
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(3);
        movimiento = 2;
    }
}
