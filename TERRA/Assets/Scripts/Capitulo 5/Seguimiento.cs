using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    private float Speed;

    public float speed = 4f;
    public float maxspeed = 4f;
    public float DistanciaVision = 4f;
    Vector3 PosicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        PosicionInicial = transform.position;

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        //Funciones para Seguimiento del Jugador
        Vector3 target = PosicionInicial;
        
  
        //Si la distancia al jugador es menor que el radio de vision del objetivo, el target pasa a ser el jugador
        float distanciaJugador = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.ScreenToWorldPoint(transform.position));
        Debug.Log(distanciaJugador);
        if (distanciaJugador < 10f) target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0f;
        //Movimiento del Enemigo
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, target, Color.red);



    }
}
