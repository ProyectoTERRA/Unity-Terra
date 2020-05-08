using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    Rigidbody2D myRB;
    Player player;
    private bool top, Cgravity, TTrigger, DTrigger;
    public static int VG;
    // Start is called before the first frame update
    void Start()
    {
        TTrigger = false;
        DTrigger = false;
        player = GetComponent<Player>();
        myRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.Log(myRB.gravityScale);

        if (TTrigger)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
            transform.localScale = new Vector3(PlayerController.side*-1, 1, 0);
            myRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            myRB.velocity = new Vector2(0, 0);
            Debug.Log("Funciona");
            
            Cgravity = true;
            TTrigger = false;
        }
        if (DTrigger)
        {
            transform.eulerAngles = new Vector3(0, 0, 360f);
            transform.localScale = new Vector3(PlayerController.side * -1, 1, 0);
            myRB.velocity = new Vector2(0, 0);
            Debug.Log("Funciona");
           
            Cgravity = false;
            DTrigger = false;
        }

        if (Cgravity)
        {
            VG = -1;
            myRB.gravityScale = -0.5f;
        }
        else
        {
            VG = 1;
            myRB.gravityScale = 1f;
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "GArriba" && Input.GetKey(KeyCode.E))
        {
            TTrigger = true;
        }

        if (collision.name == "GAbajo" && Input.GetKey(KeyCode.E))
        {
            DTrigger = true;
        }
    }


    // Update is called once per frame
    void Rotation()
    {
        if(top == false)
        {
            
            
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 360f);
        }
        top = !top;
    }
}
