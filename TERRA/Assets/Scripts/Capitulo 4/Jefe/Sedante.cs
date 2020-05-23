using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sedante : MonoBehaviour
{
    private Rigidbody2D rbd2;
    public float JumpPower = 1.0f;
    public float scale;

    private float x, y;




    // Start is called before the first frame update
    void Start()
    {
        //scale = Comportamiento.scal * 0.5714f;
        float SL = .7f;
        transform.localScale = new Vector3(SL, SL);
        if(Comportamiento.side > 0)
        {
            transform.localScale = new Vector3(-SL, SL);
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector3(2f * (-Comportamiento.side), 2f);
        rbd2 = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(transform.position.x - (-0.3f * Comportamiento.side * SL), transform.position.y + (-0.3f * SL));

        x = transform.position.x - (1f * Comportamiento.side * SL);
        y = transform.position.y + (0.6f * SL);
        transform.position = new Vector3(x, y);

        rbd2.AddForce(Vector2.left * Comportamiento.side * 1, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x - (5f * scale), transform.localScale.x - (5f * scale));
        Destroy(gameObject, 1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "PlayerInteractionZone" || collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
