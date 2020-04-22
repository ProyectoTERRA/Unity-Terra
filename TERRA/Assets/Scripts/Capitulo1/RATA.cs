using UnityEngine;

public class RATA : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    GameObject Jugador;
    // Start is called before the first frame update
    public float speed = 1f;
    public float maxspeed = 1f;
    private Rigidbody2D rbd2;


    // Start is called before the first frame update
    void Start()
    {//target the player
        Jugador = GameObject.FindGameObjectWithTag("PlayerInteractionZone");
        rbd2 = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "EnemyCollider1")
        {
            speed = -speed;
            rbd2.velocity = new Vector2(speed, rbd2.velocity.y);
            Debug.Log("RATA");


        }
        if (col.gameObject.name == "EnemyCollider2")
        {
            speed = -speed;
            rbd2.velocity = new Vector2(speed, rbd2.velocity.y);
            Debug.Log("RATA");


        }
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Ha hecho colision con el jugador");
            float yOffset = y+(y*(y*.8f));
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            }
            else
            {

                col.SendMessage("RATAKnockBack", transform.position.x);
            }

        }
    }
}
