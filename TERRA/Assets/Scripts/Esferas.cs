using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esferas : MonoBehaviour
{

    private Rigidbody2D rbd2;
    public float JumpPower = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(8f*(-PlayerController.side), 2f);


        rbd2 = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x - (1.5f * PlayerController.side), transform.position.y + 0.6f);

        rbd2.AddForce(Vector2.left * PlayerController.side * JumpPower, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,1f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    }
}
