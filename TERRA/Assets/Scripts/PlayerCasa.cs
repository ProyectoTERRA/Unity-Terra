using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasa : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(0.0f, 0.0f, - 10.0f);
        camera.transform.localScale = new Vector3(1f, 1f, 1f);
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
        

    }
}
