using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_Turret : MonoBehaviour
{
    private float beam_speed;
    // Start is called before the first frame update
    void Start()
    {
        beam_speed = Random.Range(8f, 18f);
        GetComponent<Rigidbody2D>().velocity = new Vector3(-beam_speed, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" && PlayerController.movement)
        {
            
            collision.SendMessage("Turret_1Corazon", transform.position.x);
            Destroy(gameObject);
        }
    }
}
