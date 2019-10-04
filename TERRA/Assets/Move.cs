using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 20f;
    public float MaxSpeed = 10f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent < Rigidbody2D >();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * Speed * h);

        Debug.Log(rb2d.velocity.x);

        if (rb2d.velocity.x > MaxSpeed)
        {
            rb2d.velocity = new Vector2(MaxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -MaxSpeed)
        {
            rb2d.velocity = new Vector2(-MaxSpeed, rb2d.velocity.y);
        }

        Debug.Log(rb2d.velocity.x);
    }
}
