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
    // Update is called once per frame
    void FixedUpdate()
    {
        //Funciones para Seguimiento del Jugador
        Vector3 target = PosicionInicial;

        if(Esconderse.hide == true)
        {
            DistanciaVision = 0;
        }
        else
        {
            DistanciaVision = 5;
        }
        //Si la distancia al jugador es menor que el radio de vision del objetivo, el target pasa a ser el jugador
        float distanciaJugador = Vector3.Distance(Jugador.transform.position, transform.position);
        if (distanciaJugador < DistanciaVision) target = Jugador.transform.position;
        //Movimiento del Enemigo
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, target, Color.red);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" && PlayerController.movement)
        {
            col.SendMessage("EnemyKnockBack", transform.position.x + 1);
            col.SendMessage("BiriBiriBanBan", transform.position.x);

        }
        if (col.gameObject.tag == "BE")
        {
            DistanciaVision = 0;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DistanciaVision = 5;
    }


}
