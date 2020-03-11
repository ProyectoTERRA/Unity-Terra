using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    Rigidbody2D myRB;
    Player player;
    private bool top;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        myRB = GetComponent<Rigidbody2D>();
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GArriba" && Input.GetKey(KeyCode.E))
        {
            myRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            myRB.velocity = new Vector2(0 , 0);
            Debug.Log("Funciona");
            myRB.gravityScale *= -1;
            Rotation();
            
        }

        if (collision.name == "GAbajo" && Input.GetKey(KeyCode.E))
        {
            myRB.velocity = new Vector2(0, 0);
            Debug.Log("Funciona");
            myRB.gravityScale *= -1;
           
        }
    }


    // Update is called once per frame
    void Rotation()
    {
        if(top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
            transform.localScale = new Vector3(-1, 0, 0);
            
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 360f);
        }
        top = !top;
    }
}
