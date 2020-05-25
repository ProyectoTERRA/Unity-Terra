using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubControler : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D RBS;
    public GameObject bufanda;
    public int life;
    public float tiempo = 15f;
    public float speed;
    public float DistanciaVision;
    GameObject Jugador;
    Vector3 PosicionInicial;
    private Transform MyTransform;
    public int rotationSpeed;
    private bool startT, DamageT, Defeat, halflife;
    public static bool SecondAttack;

    [SerializeField] private GameObject Esf1;
    [SerializeField] private GameObject Esf2;
    [SerializeField] private GameObject Launch;
    [SerializeField] private GameObject LifeView;
    [SerializeField] private GameObject Lock;

    private Slider Life;

    public static bool hiting;
    void Start()
    {
        Life = LifeView.GetComponent<Slider>();
        LifeView.SetActive(false);
        MyTransform = transform;
        RBS = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;
        bufanda.SetActive(false);
        Physics2D.IgnoreLayerCollision(4, 5, true);
        Physics2D.IgnoreLayerCollision(4, 11, true);
        Physics2D.IgnoreLayerCollision(11, 12, true);
    }

    private void Update()
    {
        if (DamageT)
        {
            Life.value--;
            DamageT = false;
        }
        if(Life.value <= 0 && !Defeat)
        {
            Destroy(Lock);
            GetComponent<SpriteRenderer>().color = Color.gray;
            RBS.bodyType = RigidbodyType2D.Static;
            Defeat = true;
        }
        if (Bufanda.AttackSub)
        {
            RBS.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            RBS.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void FixedUpdate()
    {
        if (!Defeat)
        {
            Vector3 target = PosicionInicial;
            float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);
            if (distanciaJugador < DistanciaVision)
            {
                target = Jugador.transform.position;
                //transform.position = new Vector3(transform.position.x, Jugador.transform.position.y);
                if (!startT)
                {
                    LifeView.SetActive(true);
                    startT = true;
                    StartCoroutine(LaunchESF());
                }
            }
            float fixedSpeed = speed * Time.deltaTime;
            if (!hiting) transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);


            if (distanciaJugador < 3 && !hiting)
            {
                StartCoroutine(AtaqueBufanda());
            }
            ///if(System.Math.Abs(DistanciaVision - distanciaJugador) == 4f) Si está a 4 o menos de 4 unidades de distancia ataca
            //{
            //}
            Debug.DrawLine(transform.position, target, Color.red);

            if (Life.value <= 15 && !halflife)
            {
                //Aumentar Velocidad
                halflife = true;
                speed = speed * 1.5f;
            }
            else if (Life.value <= 8)

            {
                //Iniciar Segundo ataque
                SecondAttack = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "BE")
        {
            DistanciaVision = 0;
        }
        else if (col.gameObject.tag == "BEReturn")
        {
            DistanciaVision = 10;
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Paraliz" && !DamageT && !Defeat)
        {
            Destroy(col.gameObject);
            DamageT = true;
        }
    }
    // Update is called once per frame


    IEnumerator AtaqueBufanda()
    {
        hiting = true;
        yield return new WaitForSeconds(0.25f);
        bufanda.SetActive(true);
        if(!Bufanda.AttackSub) yield return new WaitForSeconds(1f);
        else bufanda.SetActive(false);
        bufanda.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        Bufanda.AttackSub = false;
        yield return new WaitForSeconds(0.7f);
        hiting = false;
        Bufanda.hit = false;
    }

    IEnumerator LaunchESF()
    {
        yield return new WaitForSeconds(30f);
        if (!Defeat) {
            Instantiate(Esf2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf2, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf1, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf1, Launch.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            Instantiate(Esf1, Launch.transform.position, Quaternion.identity);
        }
        if (!Defeat) StartCoroutine(LaunchESF());
    }

    /*
    IEnumerator AtaqueBufandaAbajo()
    {

    }
    */

}
