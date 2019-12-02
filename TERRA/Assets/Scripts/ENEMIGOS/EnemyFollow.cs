using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3f;
    public float maxspeed = 3f;
    public float DistanciaVision;
    public GameObject matchPanel;

    private Color color;

    GameObject Jugador;

    Vector3 PosicionInicial;

    private Rigidbody2D rbd2;
    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;
    }

    void FixedUpdate()
    {        
        //Funciones para Seguimiento del Jugador
        Vector3 target = PosicionInicial;

        //Si la distancia al jugador es menor que el radio de vision del objetivo, el target pasa a ser el jugador
        float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);
        if (distanciaJugador < DistanciaVision)
        {
            target = Jugador.transform.position;
            float fixedSpeed = speed * Time.deltaTime;
            Debug.Log("FIXEDSPEED " + fixedSpeed);
            Debug.Log("TARGET " + target);
            Debug.Log("TRANSFORM POSITION " + transform.position);
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            //Debug.DrawLine(transform.position, target, Color.red);
        }
        else
        {
            rbd2.AddForce(Vector2.right * speed);
            float limetedSpeed = Mathf.Clamp(rbd2.velocity.x, -maxspeed, maxspeed);
            rbd2.velocity = new Vector2(limetedSpeed, rbd2.velocity.y);

            if (rbd2.velocity.x > -0.01f && rbd2.velocity.x < 0.01f)
            {
                speed = -speed;
                rbd2.velocity = new Vector2(speed, rbd2.velocity.y);
            }

            if (speed > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);

            }
            else if (speed < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
