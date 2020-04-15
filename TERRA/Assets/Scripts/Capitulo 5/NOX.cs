using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOX : MonoBehaviour
{
    [SerializeField] private GameObject Punch;
    [SerializeField] private GameObject Back;
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
    private bool boost;
    private bool hiting;
    private Rigidbody2D rbd2;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.666667f;
        boost = false;
        Punch.SetActive(false);
        hiting = false;
        side = 1;
        rbd2 = GetComponent<Rigidbody2D>();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        PosicionInicial = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("EnemyKnockBack", transform.position.x);

        }
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(PlayerCarga.countPL >= 2 && !boost)
        {
            Debug.Log("Boost!");
            speed = speed + (speed * 0.5f);
            boost = true;
        }
        //Funciones para Seguimiento del Jugador
        Vector3 target = PosicionInicial;
        //Debug.Log(PlayerCarga.countPL);
        //Si la distancia al jugador es menor que el radio de vision del objetivo, el target pasa a ser el jugador
        float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);
        if (distanciaJugador < DistanciaVision) target = Jugador.transform.position;

        //Movimiento del Enemigo
        if (!hiting){
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            transform.position = new Vector3(transform.position.x, -2.73f);
            transform.localScale = new Vector3(side, 1);
            Debug.DrawLine(transform.position, target, Color.red);

            if (distanciaJugador < 1)
            {
                StartCoroutine(push());
            }
        }
        




    }
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
}
