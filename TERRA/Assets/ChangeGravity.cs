using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = this.GetComponent<Rigidbody2D>();
    }

    void AddForceUP()
    {
        myRB.velocity = new Vector2(0, 0);
        myRB.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
    }

    void AddForceDown()
    {
        myRB.velocity = new Vector2(0, 0);
        myRB.AddForce(new Vector2(0, -7), ForceMode2D.Impulse);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GArriba" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Funciona");
            Physics2D.gravity = new Vector2(0, -1.0f);
            AddForceUP();
        }

        if (collision.name == "GAbajo" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Funciona");
            Physics2D.gravity = new Vector2(0, 1.0f);
            AddForceDown();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
