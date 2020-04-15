using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCaida : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    public float speed = 5f;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            float hInput = Input.GetAxis("Horizontal");
            transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0);
            float newx = Mathf.Clamp(transform.position.x, -12.5f, 5f);
            transform.position = new Vector3(newx, transform.position.y, 0);
        }
        

        if (camera.transform.position.y <= -23.8)
        {
            camera.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shit")
        {
            Debug.Log("Uff");
            ShitKnockBack();
        }
        if (collision.gameObject.name == "FINISH")
        {
            Debug.Log("Adioooooos");
            SceneManager.LoadScene("Aterrizaje");   
        }
    }

    public void ShitKnockBack()
    {

        move = false;


        Invoke("EnableMovement", 2f);

        GetComponent<SpriteRenderer>().color = Color.red;
    }
    void EnableMovement()
    {
        move = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
