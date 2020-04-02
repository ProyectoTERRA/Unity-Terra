using UnityEngine;

public class Esferas : MonoBehaviour
{

    private Rigidbody2D rbd2;
    public float JumpPower = 1.0f;
    public float scale;

    private float x, y;




    // Start is called before the first frame update
    void Start()
    {
       
        scale = PlayerController.scal * 0.5714f;
        transform.localScale = new Vector3(scale, scale);
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(8f * (-PlayerController.side), 2f);


        rbd2 = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(transform.position.x - ((-0.3f * PlayerController.side) * scale), (transform.position.y + (-0.3f * scale)));

        x = transform.position.x - ((1.5f * PlayerController.side) * scale);
        y = (transform.position.y + (0.6f * scale));
        transform.position = new Vector3(x, y);


        rbd2.AddForce(Vector2.left * PlayerController.side * (JumpPower * scale), ForceMode2D.Impulse);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x - (0.01f * scale), transform.localScale.x - (0.01f * scale));
        Destroy(gameObject, 1.5f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    }
}
