using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    [SerializeField] private GameObject vision;

    public float x;
    public float y;
    public float z;
    GameObject Jugador;
    // Start is called before the first frame update
    public float speed = 1f;
    public float maxspeed = 1f;
    private Rigidbody2D rbd2;
    public static bool back, die;
    // Start is called before the first frame update
    private float yaux, xaux;
    public int s;
    static public int side;
    float xd;
    private bool idle;

    void Start()
    {
        die = false;
        back = false;
        side = s;
        idle = false;
        Jugador = GameObject.FindGameObjectWithTag("PlayerInteractionZone");
        rbd2 = GetComponent<Rigidbody2D>();
        speed = -speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (!idle)
        {
            rbd2.AddForce(Vector2.right * speed);
            float limetedSpeed = Mathf.Clamp(rbd2.velocity.x, -maxspeed, maxspeed);
            rbd2.velocity = new Vector2(limetedSpeed, rbd2.velocity.y);

            if (rbd2.velocity.x > -0.4f && rbd2.velocity.x < 0.4f)
            {
                speed = -speed;
                rbd2.velocity = new Vector2(speed, rbd2.velocity.y);
               

            }

            if (speed < 0)
            {
                
                transform.localScale = new Vector3(x, y, 1f);


            }
            else if (speed > 0)
            {
                transform.localScale = new Vector3(-x, y, 1f);

            }
        }
        else
        {
            rbd2.velocity = new Vector2(0, rbd2.velocity.y);
            // transform.position = new Vector3(xaux, yaux);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "EnemyCollider2" && !die)
        {

           StartCoroutine(ExampleCoroutine());
            if (!die)
            {
                speed = -speed;
                rbd2.velocity = new Vector2(speed, rbd2.velocity.y);
            }
            
            

        }

        else if (col.gameObject.tag == "Player" && !PlayerCeldas.jail && !PlayerCeldas.hide && !die && back)
        {

            die = true;
            speed = -speed;
            StartCoroutine(ExampleCoroutines());
            idle = true;
            
            GetComponent<Prueba>().enabled = false;
            rbd2.velocity = new Vector2(speed, rbd2.velocity.y);
    
            rbd2.gravityScale = 1000;

        }
        /*
        if (((side == 1 && PlayerCeldas.s2) || (side == 0 && PlayerCeldas.s1)) && PlayerCeldas.jail == false && col.gameObject.tag == "Player")
        {
            Debug.Log("Ha hecho colision con el jugador");
            
 

                col.SendMessage("RATAKnockBack", transform.position.x);
            

        }
        */
    }
    IEnumerator ExampleCoroutine()
    {

        float sx = transform.localScale.x;
        float rWait = Random.Range(0.5f, 2.5f);
        idle = true;

        //Print the time of when the function is first called.

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(rWait);
        if (!die)
        {
           transform.localScale = new Vector3(-1f * sx, y, 1f);
        }
        yield return new WaitForSeconds(rWait);
        if (!die || !PlayerCeldas.dies)
        {
            idle = false;
            maxspeed = Random.Range(3f, 6f);
            speed = -speed;
        }

    }
    IEnumerator ExampleCoroutines()
    {
        float sx = transform.localScale.x;

        idle = true;
        
        //Print the time of when the function is first called.

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.1f);

        if (back) transform.localScale = new Vector3(-1f * sx, y, 1f);
        else maxspeed = Random.Range(3f, 6f);
        yield return new WaitForSeconds(0.1f);



    }
    
}
