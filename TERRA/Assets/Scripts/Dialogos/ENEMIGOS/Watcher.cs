using UnityEngine;

public class Watcher : MonoBehaviour
{

    public float x;
    public float y;
    public float z;

    public float speed = 4f;
    public float maxspeed = 4f;
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
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("EnemyKnockBack", transform.position.x+1);/*
            Debug.Log("Ha hecho colision con el jugador");
            float yOffset = 0.04f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            }
            else
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }*/

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Funciones para Seguimiento del Jugador
        Vector3 target = PosicionInicial;

        //Si la distancia al jugador es menor que el radio de vision del objetivo, el target pasa a ser el jugador
        float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);
        if (distanciaJugador < DistanciaVision) target = Jugador.transform.position;
        /*
        {
            target = Jugador.transform.position;
            if(ColorUtility.TryParseHtmlString("#C2C2C2",out color))
            {
                matchPanel.GetComponent<Watcher>().color = color;
            }
            
        }
        */
        //Movimiento del Enemigo
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, target, Color.red);


        /*
        if(transform.position.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }else if(transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    
        /*
        if (rbd2.velocity.x > -0.01f && rbd2.velocity.x < 0.01f)
        {
            speed = -speed;
            rbd2.velocity = new Vector2(speed, rbd2.velocity.y);
        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
   */

    }
}
