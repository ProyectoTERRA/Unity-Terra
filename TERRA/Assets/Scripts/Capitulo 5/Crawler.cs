﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
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

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && PlayerController.movement)
        {

            Debug.Log("Ha hecho colision con el jugador");
            col.SendMessage("MedioCorazon", transform.position.x);
        }
    }
    
}
