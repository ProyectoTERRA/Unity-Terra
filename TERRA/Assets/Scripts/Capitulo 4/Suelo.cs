using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    public GameObject enemigo;
    Vector2 regresar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "JefeMisterioso")
        {
            enemigo.transform.position = new Vector2(enemigo.transform.position.x, -0.3f);
        }
    }
}
