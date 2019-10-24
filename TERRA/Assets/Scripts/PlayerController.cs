using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 2f;
    public float maxspeed = 5f;
   
    public bool grounded;
    public float JumpPower = 6.5f;

    private Rigidbody2D rbd2;
    private Animator animacion;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;
    
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        animacion.SetFloat("Velocidad",Mathf.Abs(rbd2.velocity.x));
        animacion.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            } else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }
    }

    void FixedUpdate()
    {

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
        if(h> 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if(h < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(jump)
        {
            rbd2.velocity = new Vector2(rbd2.velocity.x, 0);
            rbd2.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            jump = false;
        }

    }

    /*private void OnBecameInvisible()
    {
        transform.position = new Vector3(-7, 2, 0);
    }*/

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
}
