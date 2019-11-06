using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasa : MonoBehaviour
{
    [SerializeField] private GameObject camera;


    public bool lucy;
    public bool linterna;

    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(0.0f, 0.0f, - 10.0f);
        camera.transform.localScale = new Vector3(1f, 1f, 1f);

        transform.position = new Vector3(-6.4f, 0.5f);
        transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

        lucy = false;
        linterna = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PuertaLucy")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado la puerta3");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla e");
                transform.position = new Vector3(16.8f, 0.5f);
                transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

                camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);
                camera.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (collision.gameObject.tag == "PuertaSala")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado la puerta3");
            if (Input.GetKeyDown(KeyCode.E) && lucy)
            {
                Debug.Log("Tecla e");
                transform.position = new Vector3(30.6f, 0.5f);
                transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

                camera.transform.position = new Vector3(36.0f, 0.0f, -10.0f);
                camera.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (collision.gameObject.tag == "Lucy")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado a Lucy");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla e");
                lucy = true;
            }
        }

        if (collision.gameObject.tag == "PuertaCalle")//compara si hizo la colision con el objeto correcto
        {
            
            if (Input.GetKeyDown(KeyCode.E) && linterna)
            {

                Debug.Log("Salido");
            }
        }

        if (collision.gameObject.tag == "linterna")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado a LINTERNA");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Has agarrado la linterna");
                linterna = true;
                Destroy(GameObject.Find("linterna"));

            }
        }



    }
}
