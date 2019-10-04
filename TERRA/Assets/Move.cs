using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 20f;
    public float MaxSpeed = 10f;
    public float jumopower = 6.5f;

    private bool jump;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent < Rigidbody2D >();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * Speed * h);



        if (rb2d.velocity.x > MaxSpeed)
        {
            rb2d.velocity = new Vector2(MaxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -MaxSpeed)
        {
            rb2d.velocity = new Vector2(-MaxSpeed, rb2d.velocity.y);
        }

        if (h  > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumopower, ForceMode2D.Impulse);
            jump = false;
        }

 
    }
}
