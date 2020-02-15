using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float velocidad = 2f;
    public float maxspeed = 5f;

    private Rigidbody2D rbd2;
    private Animator animacion;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;

    public float x;
    public float y;
    public float z;

    void Start()
    {
        Debug.Log("Nombre escena: " + SceneManager.GetActiveScene().name);
        rbd2 = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rbd2.AddForce(Vector3.left * 10f);

    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime, Space.World);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pared")
        {
            transform.position = new Vector2(19.43f, -4.3f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rbd2.velocity;
        fixedVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        rbd2.AddForce(Vector2.right * velocidad * h);
        float limetedSpeed = Mathf.Clamp(rbd2.velocity.x, -maxspeed, maxspeed);
        rbd2.velocity = new Vector2(limetedSpeed, rbd2.velocity.y);
        transform.localScale = new Vector3(x, y, z);
    }
}
