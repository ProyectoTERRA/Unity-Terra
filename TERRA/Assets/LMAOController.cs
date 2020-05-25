using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMAOController : MonoBehaviour
{
    Rigidbody2D RBLM;
    GameObject Jugador;
    public float SavedDV;
    Vector3 PosicionInicial;
    Vector3 targetRet;
    float THoyo = 6;
    float Cooldown = 6;
    public float speed;
    bool AtHoyo = false;
    bool Hiting;
    bool Return;
    static public float side;
    public bool hiting;

    public float DistanciaVision;
    void Start()
    {
        RBLM = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;
        targetRet = transform.position;
        SavedDV = DistanciaVision;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        /*
        if (EnemigosEsferas.effecting || hiting)
        {
            Back.SetActive(false);
        }
        if (!EnemigosEsferas.effecting && !hiting)
        {
            Back.SetActive(true);
        }
        */

        #region SEGUIMIENTO
        /*
        Vector3 target = PosicionInicial;
        float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);
        if (distanciaJugador < DistanciaVision)
        {
            target = Jugador.transform.position;
        }
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        */
        #endregion

        THoyo -= Time.deltaTime;

        Debug.Log("T -: " + THoyo + " Para el Putazo");
        if (THoyo <= 0)
        {
            Debug.Log("Acabo La cuenta");
            // StartCoroutine(AtaqueHoyo());
            DistanciaVision = 100;
            AtHoyo = true;
        }

        if (AtHoyo == true)
        {
            Vector3 target = PosicionInicial;
            float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);

            if (distanciaJugador < DistanciaVision)
            {
                target = Jugador.transform.position;
            }
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            //transform.position = Vector3.MoveTowards(transform.position, PosicionInicial, fixedSpeed);
            AtHoyo = false;
            Return = true;
        }

        if(Return == true)
        {
            DistanciaVision = 0;
            Return = false;
            AtHoyo = true;
        }
        else
        {
            DistanciaVision = SavedDV;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.SendMessage("EnemyKnockBack", transform.position.x + 1);
        }
    }

    IEnumerator AtaqueHoyo()
    {
        AtHoyo = true;
        Debug.Log("COMENZANDO PUTAZO");
        THoyo = 6f;
        yield return new WaitForSeconds(2);
        StopAllCoroutines();
    }


}
//3310064114