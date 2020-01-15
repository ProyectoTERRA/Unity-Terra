using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatImpulso : MonoBehaviour
{
    Rigidbody2D myRB;
    void Start()
    {
        myRB = this.GetComponent<Rigidbody2D>();
    }

    void AddForceSide()
    {
        myRB.velocity = new Vector2(0, 0);
        myRB.AddForce(new Vector2(8000, 0), ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "PlataformaImpulso")
        {
            Debug.Log("Colision");
            AddForceSide();
        }
    }
}
