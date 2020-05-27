using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad;
    public float maxspeed = 5f;
    public float SideVelocity = 10f;

    public float SavedVel;
    public float SavedMax;

    public float RunVelocity;
    public float maxSpeedVel;

    public bool grounded;
    static public bool groundCAP5, DASH, HabilityDJ, ActHabilityLJ, DactHabilityLJ;
    public bool wall;
    public float JumpPower = 6.5f;

    private Rigidbody2D rbd2;
    private Animator animacion;
    private SpriteRenderer spr;
    static public bool jump;
    private bool doubleJump;
    static public bool movement = true;

    public float x;
    public float y;
    public float z;
    public static string Equip;

    public float scale;
    public static float scal;
    public int SIDE;
    public static int side;
    private float Jumpback;
    private bool Machucado;

    [SerializeField] private GameObject list;

    public GameObject[] Esf;

    void Start()
    {
        Jumpback = JumpPower;
        ChangeGravity.VG = 1;
        Heart_Bar.Phearts = GameController.corazones;
        Heart_Bar.life = GameController.vidas;
        //Heart_Bar.Phearts = 3;
        //Heart_Bar.life = 1;
        //GameController.TypeLife = 1;
        Machucado = false;
        groundCAP5 = true;
        transform.localScale = new Vector3(-x, y, z);
        scal = scale;
        side = SIDE;
        rbd2 = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        wall = false;

        SavedVel = velocidad;
        SavedMax = maxspeed;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Equip);

        //animacion.SetFloat("Velocidad",Mathf.Abs(rbd2.velocity.x));
        //animacion.SetBool("Grounded", grounded);

        //Doble Salto

        if (Machucado)
        {
         GetComponent<Rigidbody2D>().AddForce(transform.right * -50f, ForceMode2D.Force);
            
        }

        if (DASH)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * (-500f * scal) * side);

        }

        if (Bufanda.AttackSub)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * -500f);
        }

        if (ActHabilityLJ)
        {
            ActHabilityLJ = false;
            JumpPower = JumpPower + (JumpPower * 0.25f);
        }
        else if(DactHabilityLJ)
        {
            DactHabilityLJ = false;
            JumpPower = Jumpback;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !DASH)
        {
            if (grounded && groundCAP5)
            {
                jump = true;
                doubleJump = true;
            }
            else if (HabilityDJ) {
            if (doubleJump)
                {
                    jump = true;
                    doubleJump = false;
                }
            }
            
        }
        #region Esferas
        //Esferas
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            var pl = GameObject.Find("Jugador");

            if (Equip == "Esfera Normal")
            {
                if (pl != null)
                {
                    Instantiate(Esf[0], pl.transform.position, Quaternion.identity);


                    radial.esfera[0]--;
                    GameController.normal--;
                    string normal = "normal";
                    if (radial.esfera[0] <= 0) list.SendMessage("remove", normal);

                }
            }

            if (Equip == "Esfera Paraliz")
            {
                if (pl != null)
                {
                    Instantiate(Esf[1], pl.transform.position, Quaternion.identity);

                }
            }

            if (Equip == "Esfera Desac")
            {
                if (pl != null)
                {
                    Instantiate(Esf[2], pl.transform.position, Quaternion.identity);
                }
            }

            if (Equip == "Esfera Tranqui")
            {
                if (pl != null)
                {
                    Instantiate(Esf[3], pl.transform.position, Quaternion.identity);
                }
            }

            if (Equip == "Especiales_1")
            {
                if (!Heart_Bar.FULL)
                {
                    Heart_Bar.Phearts += 2;
                    radial.especiales[1]--;
                    GameController.curacion--;
                    string normal = "health";
                    if (radial.especiales[1] <= 0) list.SendMessage("remove", normal);
                }
            }



        }
        #endregion
        //Physics2D.IgnoreLayerCollision(8, 10);
    }

    void FixedUpdate()
    {
        //Movimiento
        Vector3 fixedVelocity = rbd2.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded)
        {
            rbd2.velocity = fixedVelocity;
        }

        if (!DASH)
        {
            float h = Input.GetAxis("Horizontal");
            if (!movement) h = 0;

            rbd2.AddForce(Vector2.right * velocidad * h);

            float limetedSpeed = Mathf.Clamp(rbd2.velocity.x, -maxspeed, maxspeed);
            rbd2.velocity = new Vector2(limetedSpeed, rbd2.velocity.y);
            if (h > 0.1f)
            {

                transform.localScale = new Vector3(-x * ChangeGravity.VG, y, z);
                side = ChangeGravity.VG * -1;
            }
            if (h < -0.1f)
            {
                transform.localScale = new Vector3(x * ChangeGravity.VG, y, z);
                side = ChangeGravity.VG * 1;
            }
            //Correr
            if (Input.GetKey(KeyCode.LeftControl))
            {
                velocidad = RunVelocity;
                maxspeed = maxSpeedVel;
            }
            else
            {
                velocidad = SavedVel;
                maxspeed = SavedMax;
            }

            if (jump)
            {
                rbd2.velocity = new Vector2(rbd2.velocity.x, 0);
                rbd2.AddForce(Vector2.up * JumpPower * ChangeGravity.VG, ForceMode2D.Impulse);
                jump = false;
            }
        }
        //Habilidades

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "life" && movement)
        {
            Debug.Log("Atrrrr");
            //GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            //Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            //heart_Bar.hearts--;
            //Heart_Bar.Phearts--;
            MedioCorazon(collision.transform.position.x);
        }
        //Animacion de Vida
        if (collision.gameObject.tag == "Car" && movement)
        {
            //GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            //Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            //heart_Bar.hearts--;
            //Heart_Bar.Phearts--;
            MedioCorazonCar(collision.transform.position.x);
        }
        if (collision.gameObject.tag == "enemigo1" && movement)
        {
            //GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            //Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            //heart_Bar.hearts--;
            //Heart_Bar.Phearts--;
            MedioCorazon(collision.transform.position.x);
        }
        if (collision.gameObject.tag == "enemigo2" && movement)
        {
            //GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            //Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            //heart_Bar.hearts-=2;
            //Heart_Bar.Phearts-=2;
            UnCorazon(collision.transform.position.x);
        }
        if (collision.gameObject.tag == "BadLata" && movement)
        {
            //GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            //Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            //heart_Bar.hearts--;
            //Heart_Bar.Phearts--;
            PlayerLMAO.Press = false;
            MedioCorazon(collision.transform.position.x);
        }
        GameController.vidas = Heart_Bar.life;
        GameController.corazones = Heart_Bar.Phearts;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "life")
        {
            //  GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            //Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            //heart_Bar.hearts--;
            //Heart_Bar.Phearts--;
            MedioCorazon(collision.transform.position.x);
        }
    }

    private void OnBecameInvisible()
    {

        //transform.position = new Vector3(129.79f, 14f, 0);

    }

    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.tag == "Wall" && !grounded)
        {
            wall = true;
        }


    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            wall = false;
        }
    }
    public void EnemyJump() { jump = true; }

    public void EnemyKnockBack(float enemyPosX)
    {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 0.7f);



        spr.color = Color.red;
    }

    public void RATAKnockBack(float enemyPosX)
    {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 2f);



        spr.color = Color.red;
    }
    public void MedioCorazonCar(float enemyPosX)
    {
        movement = false;
        jump = true;
        Heart_Bar.Phearts--;
        float side = Mathf.Sign(enemyPosX - transform.position.x);

        Machucado = true;

        //rbd2.AddForce(Vector2.left * side * (2 * JumpPower), ForceMode2D.Impulse);
        //myrb.velocity += Vector2.up * Physics2D.gravity.y * (5 - 1) * Time.deltaTime;
        //rbd2.AddForce(Vector2.up *JumpPower, ForceMode2D.Impulse);


        Invoke("EnableMovement", 0.5f);



        spr.color = Color.red;
    }

    public void MedioCorazon(float enemyPosX)
    {

        movement = false;
        jump = true;
        Heart_Bar.Phearts--;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);



        Invoke("EnableMovement", 1.5f);



        spr.color = Color.red;
    }

    public void UnCorazon(float enemyPosX)
    {
        Debug.Log("Ptup");
        jump = true;
        Heart_Bar.Phearts = Heart_Bar.Phearts - 2;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 1.5f);



        spr.color = Color.red;
    }

    public void UnCorazonYMedio(float enemyPosX)
    {
        jump = true;
        Heart_Bar.Phearts = Heart_Bar.Phearts - 3;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 1.5f);



        spr.color = Color.red;
    }

    public void DosCorazones(float enemyPosX)
    {
        jump = true;
        Heart_Bar.Phearts = Heart_Bar.Phearts - 4;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 1.5f);



        spr.color = Color.red;
    }

    public void TresCorazones(float enemyPosX)
    {
        jump = true;
        Heart_Bar.Phearts = Heart_Bar.Phearts - 6;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 1.5f);



        spr.color = Color.red;
    }


    public void BiriBiriBanBan(float enemyPosX)
    {
        jump = true;
        Heart_Bar.Phearts = 0;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 1.5f);



        spr.color = Color.red;
    }

    

    public void Turret_1Corazon(float enemyPosX)
    {
        jump = true;
        Heart_Bar.Phearts = Heart_Bar.Phearts - 2;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 0.5f);



        spr.color = Color.red;
    }

    public void RATA_1Corazon(float enemyPosX)
    {
        jump = true;
        Heart_Bar.Phearts = Heart_Bar.Phearts-2;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rbd2.AddForce(Vector2.left * side * JumpPower, ForceMode2D.Impulse);

        movement = false;


        Invoke("EnableMovement", 2f);



        spr.color = Color.red;
    }


    void EnableMovement()
    {
        Machucado = false;
        movement = true;
        spr.color = Color.white;
    }

}
