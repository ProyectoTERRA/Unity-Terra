using UnityEngine;



public class PuertaLab : MonoBehaviour
{

    public bool puertaIzq, puertaDer;
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "PuertaFI1")
        {
            transform.position = new Vector3(328f, -10f, 0);
        }
        if (collision.name == "PuertaFD1")
        {
            transform.position = new Vector3(322f, -10f, 0);
        }

        if (collision.name == "PuertaFI2")
        {
            transform.position = new Vector3(351.5f, -10f, 0);
        }
        if (collision.name == "PuertaFD2")
        {
            transform.position = new Vector3(346f, -10f, 0);
        }

        if (collision.name == "PuertaFI3")
        {
            transform.position = new Vector3(364.5f, -10f, 0);
        }
        if (collision.name == "PuertaFD3")
        {
            transform.position = new Vector3(359f, -10f, 0);
        }

        if (collision.name == "EscP12")
        {
            transform.position = new Vector3(424.89f, 26.98f, 0);
        }
        if (collision.name == "EscP21")
        {
            transform.position = new Vector3(366.5f, -10f, 0);
        }
    }

    public void OnTriggerExit2D(Collider2D LabDoor)
    {
        
    }

    // Update is called once per frame


    void FixedUpdate()
    {

        //Puertas Laboratorio
        if (puertaIzq == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(24.75f, -2.82f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaIzq = false;

        }
        if (puertaDer == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(19.5f, -2.82f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaDer = false;
        }

    }

}


