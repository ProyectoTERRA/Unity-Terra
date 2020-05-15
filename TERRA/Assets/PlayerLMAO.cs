using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLMAO : MonoBehaviour
{
    private float X_support;


    private bool healing, cSide, Front;
    // Start is called before the first frame update
    void Start()
    {

        Heart_Bar.Phearts = 6;
        cSide = false;
        Front = true;
        healing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cSide)
        {
            cSide = false;

        }
        if (healing)
        {
            if (X_support <= 0)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * 700f);

            }
            else if (X_support > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * -700f);
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BACK" && !cSide && Front)//compara si hizo la colision con el objeto correcto
        {
            Front = false;
            cSide = true;
            Debug.Log("SSSSSS");
            //NOX.side = NOX.side * -1;

        }
        if (collision.gameObject.name == "FRONT")//compara si hizo la colision con el objeto correcto
        {
            Front = true;

        }

        if (collision.gameObject.name == "PUNCH" && !healing)
        {
            EnemyKnockBack(transform.position.x);
        }
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        Heart_Bar.Phearts -= 4;
        X_support = transform.position.x;
        healing = true;
        PlayerController.jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);


        PlayerController.movement = false;


        Invoke("EnableMovement", 0.7f);



        GetComponent<SpriteRenderer>().color = Color.red;

    }
    void EnableMovement()
    {

        healing = false;
        PlayerController.movement = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
