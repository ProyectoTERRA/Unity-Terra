using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 5f;
    public float velNormal = 5f;
    public float maxspeed = 8f;
    public float ContHab;
    public float ImpulsoDash = 16f;
    public bool grounded, puertaIzq, puertaDer;
    public float JumpPower = 6.5f;
    public float RunSpeed = 15.0f;
    public bool isRunning = false;
    public GameObject TxtFloat;
    bool puertaprin = false;
    bool puertaSal = false;
    bool agrandar = false;

    private Rigidbody2D rbd2;
    private Animator animacion;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PuertaIzq")
        {
            puertaIzq = true;
            Debug.Log("Colision Izq");

        }

        if (collision.name == "PuertaDer")
        {
            puertaDer = true;
            Debug.Log("Colision Der");

        }

        if(collision.name == "Puerta")
        {
            puertaprin = true;
            Debug.Log("Colision Fuera");
        }
    }


    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();


    }


    // Update is called once per frame
    void Update()
    {
        animacion.SetFloat("Velocidad", Mathf.Abs(rbd2.velocity.x));
        animacion.SetBool("Grounded", grounded);
        /*
        IEnumerator StartCountdownHab(float ContHabT = 10)
        {
            ContHab = ContHabT;
            while (ContHab > 0)
            {
                Debug.Log("Tiempo de Habilidad: " +ContHab);
                yield return new WaitForSeconds(1.0f);
                ContHab--;
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {

            maxspeed = 10.0f;
            rbd2.AddForce(Vector2.right * ImpulsoDash * velocidad, ForceMode2D.Impulse);
            spr.color = Color.white;
        }

    }

    void FixedUpdate()
    {


        //Cruzar la puerta dentro del laboratorio


        if (puertaIzq == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(5.42f, -1.82f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaIzq = false;
            if (TxtFloat)
            {
                MostrarTXT();
            }

        }
        if (puertaDer == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(2.67f, -1.82f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaDer = false;
        }

        //Puerta Principal
        if (puertaprin == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(33.08f, -1.57f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaprin = false;
        }

        if(agrandar == true)
        {
            
        }



        //Movimiento


        Vector3 fixedVelocity = rbd2.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rbd2.velocity = fixedVelocity;
        }


        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;

        rbd2.AddForce(Vector2.right * velocidad * h);
        float limetedSpeed = Mathf.Clamp(rbd2.velocity.x, -maxspeed, maxspeed);
        rbd2.velocity = new Vector2(limetedSpeed, rbd2.velocity.y);
        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        if (jump)
        {
            rbd2.velocity = new Vector2(rbd2.velocity.x, 0);
            rbd2.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        //Función Correr



        if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.LeftControl))
        {
            isRunning = true;
            float x = Input.GetAxis("Horizontal");
            if (!movement) x = 0;

            rbd2.AddForce(Vector2.right * RunSpeed * x);
            float VelRun = Mathf.Clamp(rbd2.velocity.x, -maxspeed, maxspeed);
            rbd2.velocity = new Vector2(VelRun, rbd2.velocity.y);
            //print("Running");
        }
        else if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.LeftControl))
        {
            isRunning = true;
            float x = Input.GetAxis("Horizontal");
            if (!movement) x = 0;

            rbd2.AddForce(Vector2.right * RunSpeed * x);
            float VelRun = Mathf.Clamp(rbd2.velocity.x, -maxspeed, maxspeed);
            rbd2.velocity = new Vector2(VelRun, rbd2.velocity.y);
            //print("Running");
        }
        else
        {
            isRunning = false;
            //print("Not Running");

        }


    }

    public void EnemyJump()
    {
        jump = true;
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;
        Invoke("EnableMovement", 0.7f);

        spr.color = Color.red;
    }

    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }

    public void MostrarTXT()
    {
        GameObject Texto = Instantiate(TxtFloat);
        Texto.transform.position = new Vector3(5.27f, 0, 0);


    }
}


