using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esconderse : MonoBehaviour

{
    public Transform Agujero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Agujero" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = Agujero.position;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Agujero" && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = Agujero.position;
            GetComponent<Collider2D>().enabled = true;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
