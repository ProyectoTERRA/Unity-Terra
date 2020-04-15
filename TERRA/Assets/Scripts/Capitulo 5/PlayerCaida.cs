using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaida : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput*speed * Time.deltaTime, 0, 0);
        float newx = Mathf.Clamp(transform.position.x, -12.5f, 5f);
        transform.position = new Vector3(newx, transform.position.y, 0);


    }
}
