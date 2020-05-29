using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMAO_Controller : MonoBehaviour
{

    [SerializeField] private GameObject Back;
    [SerializeField] private GameObject Matamoscas;

    [SerializeField] private GameObject Lata1;
    [SerializeField] private GameObject Lata2;
    [SerializeField] private GameObject Launch;

    public GameObject DialogoMuerte;

    public float x;
    public float y;
    public float z;

    public float speed;
    public float maxspeed = 4f;
    public float DistanciaVision;
    public GameObject matchPanel;

    static public float side;
    private Color color;

    GameObject Jugador;

    Vector3 PosicionInicial;
    Vector3 target;
    private bool boost;
    private bool hiting;
    private Rigidbody2D rbd2;
    public static bool AT2, AT3, TDrill, Returning, TReturn, MT, Defeat, act1, act2, act1T, act2T, hit;
    private int Damage;
    float distanciaJugador;

    private GameObject GroundDrilled;

    // Start is called before the first frame update
    void Start()
    {
        Damage = 0;
        Matamoscas.SetActive(false);
        boost = false;
        PosicionInicial = transform.position;
        hiting = false;
        side = 1;
        rbd2 = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;
        StartCoroutine(INI());
        StartCoroutine(Ataque1());
        //StartCoroutine(Ataque2());
        //StartCoroutine(Ataque3());
        Physics2D.IgnoreLayerCollision(11, 0, true);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Ground" && TDrill)
        {
            GroundDrilled = col.gameObject;
            GroundDrilled.SetActive(false);
            TDrill = false;
            Physics2D.IgnoreLayerCollision(8, 12, false);

        }
        if (col.gameObject.tag == "Pesada" && !Defeat)
        {
            Destroy(col.gameObject);
            hit = true;
        }


    }
    private void Update()
    {

        if (TReturn)
        {

            target = new Vector3(Random.Range(190.0f, 225.0f), transform.position.y);
            Returning = true;
            TReturn = false;
        }

        if(Damage == 1 && !act1T)
        {
            act1 = true;
        }
        if (Damage == 2 && !act2T)
        {
            act2 = true;
        }
        if (Damage == 3)
        {
            boost = true;
        }
        if (Damage == 4)
        {
            StopAllCoroutines();
            AT2 = false;
            AT3 = false;
            Defeat = true;
            DialogoMuerte.SetActive(true);
            GetComponent<SpriteRenderer>().color = Color.gray;
        }

        if (act1)
        {

            StartCoroutine(Ataque2());
            Returning = false;
            act1T = true;
            act1 = false;
        }
        if (act2)
        {
            StartCoroutine(Ataque3());
            act2T = true;
            act2 = false;
        }
        if (hit)
        {
            Damage++;
            hit = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (EnemigosEsferas.effecting || hiting)
        {
            Back.SetActive(false);
        }
        if (!EnemigosEsferas.effecting && !hiting)
        {
            Back.SetActive(true);
        }


        //Funciones para Seguimiento del Jugador
        //target = PosicionInicial;
        //Debug.Log(PlayerCarga.countPL);
        //Si la distancia al jugador es menor que el radio de vision del objetivo, el target pasa a ser el jugador

        // if (distanciaJugador < DistanciaVision) 

        //Movimiento del Enemigo

        if (!Defeat) transform.localScale = new Vector3(side, 1);
        if (!EnemigosEsferas.effecting && !hiting && (AT2||AT3))
        {
            target = Jugador.transform.position;
            float fixedSpeed = speed * Time.deltaTime;
            if (!MT)
            {
                if (boost)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target, (fixedSpeed * 1.5f));
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
                }
                
            } 
                
            transform.position = new Vector3(transform.position.x, 16.5f);

            Debug.DrawLine(transform.position, target, Color.red);
            distanciaJugador = Vector3.Distance(target, transform.position);
            
            if (distanciaJugador < 0.5f && !hiting)
            {
                if (AT2)
                {
                    AT2 = false;
                    TDrill = true;
                    TReturn = true;
                    StartCoroutine(Ataque2());
                    StartCoroutine(HealGround());
                }
                if (AT3)
                {
                    StartCoroutine(WaitPunch());
                }
               
                
               
                
            }
            
        }

        if (Returning)
        {
            float fixedSpeed = speed * Time.deltaTime;
            if (boost)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, (fixedSpeed / 2.5f));
            }
            else
            {

                transform.position = Vector3.MoveTowards(transform.position, target, (fixedSpeed / 4f));
            }
            
            transform.position = new Vector3(transform.position.x, 16.5f);


            Debug.DrawLine(transform.position, target, Color.red);
            distanciaJugador = Vector3.Distance(target, transform.position);

            if (distanciaJugador < 0.5f && Damage == 0)
            {
                Returning = false;
                StartCoroutine(INI());

            }

        }





    }

    IEnumerator Ataque1()
    {
        yield return new WaitForSeconds(40f);
        if (!Defeat)
        {
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata1, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata1, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata1, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata1, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Lata1, Launch.transform.position, Quaternion.identity);

        }
        if (!Defeat) StartCoroutine(Ataque1());
    }

    public IEnumerator INI()
    {
        yield return new WaitForSeconds(4f);
        TReturn = true;
    }

    public IEnumerator HealGround()
    {
        yield return new WaitForSeconds(4f);
        GroundDrilled.SetActive(true);

    }
    public IEnumerator WaitPunch()
    {
        MT = true;
        yield return new WaitForSeconds(0.2f);
        Matamoscas.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Matamoscas.SetActive(false);
        MT = false;
        AT3 = false;
        TReturn = true;
        StartCoroutine(Ataque3());

    }
    public IEnumerator Ataque2()
    {
        yield return new WaitForSeconds(6f);
        Returning = false;
        target = Jugador.transform.position;
        AT2 = true;
        Physics2D.IgnoreLayerCollision(8, 12, true);
        
    }

    public IEnumerator Ataque3()
    {
        yield return new WaitForSeconds(10f);
        Returning = false;
        target = Jugador.transform.position;
        AT3 = true;
        Physics2D.IgnoreLayerCollision(8, 12, true);

    }

    /*
    public IEnumerator push()
    {
        hiting = true;
        Back.SetActive(false);
        yield return new WaitForSeconds(.25f);
        Punch.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Punch.SetActive(false);
        hiting = false;
        Back.SetActive(true);

    }
    */
}
