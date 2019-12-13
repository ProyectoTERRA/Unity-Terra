using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esferas : MonoBehaviour
{

    private Rigidbody2D rbd2;
    public float JumpPower = 6.5f;
    private int side;


    // Start is called before the first frame update
    void Start()
    {
     


        rbd2 = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x - (1.5f * PlayerController.side), transform.position.y + 0.6f);

        rbd2.AddForce(((Vector2.left * PlayerController.side)+ Vector2.up)  * JumpPower, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
       


        
    }
}
