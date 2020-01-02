using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PuertaLab : MonoBehaviour
{

    public bool puertaIzq, puertaDer;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D LabDoor)
    {
        if (LabDoor.name == "PuertaIzq")
        {          
                puertaIzq = true;
                Debug.Log("Colision Izq");
        }

            if (LabDoor.name == "PuertaDer")
            {
                puertaDer = true;
                Debug.Log("Colision Der");

            }
        }
    

    /*
    public void OnTriggerExit2D(Collider2D LabDoor)
    {

        if (LabDoor.gameObject.tag == "Player" && LabDoor.gameObject.tag == "PuertaIzq")
        {
           
                puertaIzq = false;

        }

            if (LabDoor.gameObject.tag == "Player" && LabDoor.gameObject.tag == "PuertaDer")
            {
                puertaDer = false;
            }
    }
    */
    // Update is called once per frame
    void FixedUpdate()
    {
        if (puertaIzq == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(5.42f, -1.82f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaIzq = false;

        }
        if (puertaDer == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            Player.transform.position = new Vector3(2.67f, -1.82f, 0);
            Player.transform.localScale = new Vector3(1f, 1f, 1f);
            puertaDer = false;
        }
    }
}
