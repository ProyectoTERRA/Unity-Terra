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
    public float disparar;

    public float scale;
    public static float scal;
    public float SIDE;
    public static float side;

    private Color color;
    GameObject Jugador;
    Vector2 PosicionInicial;

    public GameObject sedante;
    GameObject sedanteClone;

    int movimiento;

    private Rigidbody2D rbd2;
    void Start()
    {
        //transform.localScale = new Vector3(-x, y, z);
        scal = scale;
        side = SIDE;
        movimiento = 1;
        rbd2 = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Normal")
        {
            Debug.Log("Me diooooooooo");
            GameObject vida = GameObject.Find("bossLive");
            VidaBoss corazon = vida.GetComponent<VidaBoss>();
            corazon.hearts--;
        }
        if (col.gameObject.tag == "Tranqui")
        {
            Debug.Log("Me diooooooooo");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            jump = true;
        }
        GameObject vida = GameObject.Find("bossLive");
        VidaBoss corazon = vida.GetComponent<VidaBoss>();
        if (corazon.hearts == 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector2 target = PosicionInicial;

        float distanciaJugador = Vector2.Distance(Jugador.transform.position, transform.position);
        if (Jugador.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-x, y, z);
            side = 1;
        }
        if (Jugador.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(x, y, z);
            side = -1;
        }
        if (movimiento == 1)
        {  
            if (distanciaJugador > DistanciaVision)
            {
                target = Jugador.transform.position;
                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target, fixedSpeed);                
            }
            
            StartCoroutine(espera());
        }
        if (distanciaJugador <= DistanciaVision)
        {
            var pl = GameObject.Find("JefeMisterioso");
            if (pl != null)
            {
                if (!sedanteClone)
                {
                    sedanteClone = Instantiate(sedante, pl.transform.position, Quaternion.identity);
                }
            }
        }
        if (distanciaJugador < distancia)
        {
            Vector2 mover;
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
