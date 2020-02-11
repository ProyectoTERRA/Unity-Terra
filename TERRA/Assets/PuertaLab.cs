using UnityEngine;



public class PuertaLab : MonoBehaviour
{

    public bool puertaIzq, puertaDer, Salir, Entrar, EntrFabr, SalidaFab, PuertaFD1, PuertaFD2, PuertaFI1, PuertaFI2;
    public bool PuertaFD3, PuertaFI3, EscP12, EscP21, EscP23, EscP32;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PuertaDer")//compara si hizo la colision con el objeto correcto
        {
            puertaDer = true;
        }
        if (collision.name == "PuertaIzq")
        {
            puertaIzq = true;
        }
        if (collision.name == "Salir")
        {
            Salir = true;
        }
        if (collision.name == "Entrar")
        {
            Entrar = true;
        }
        if (collision.name == "EntrFabr")
        {
            EntrFabr = true;
        }
        if (collision.name == "SalidaFab")
        {
            SalidaFab = true;
        }
        if (collision.name == "PuertaFD1")
        {
            PuertaFD1 = true;
        }
        if (collision.name == "PuertaFI1")
        {
            PuertaFI1 = true;
        }
        if (collision.name == "PuertaFD2")
        {
            PuertaFD2 = true;
        }
        if (collision.name == "PuertaFI2")
        {
            PuertaFI2 = true;
        }
        if (collision.name == "PuertaFD3")
        {
            PuertaFD3 = true;
        }
        if (collision.name == "PuertaFI3")
        {
            PuertaFI3 = true;
        }
        if (collision.name == "EscP12")
        {
            EscP12 = true;
        }
        if (collision.name == "EscP21")
        {
            EscP21 = true;
        }
        if (collision.name == "EscP23")
        {
            EscP23 = true;
        }
        if (collision.name == "EscP32")
        {
            EscP32 = true;
        }
    }

    public void OnTriggerExit2D(Collider2D LabDoor)
    {
        puertaDer = false;
        puertaIzq = false;
        Salir = false;
        Entrar = false;
        EntrFabr = false;
        SalidaFab = false;
        PuertaFD1 = false;
        PuertaFD2 = false;
        PuertaFI1 = false;
        PuertaFI2 = false;
        PuertaFI3 = false;
        PuertaFI3 = false;
        EscP12 = false;
        EscP21 = false;
        EscP23 = false;
        EscP32 = false;
    }

    // Update is called once per frame


    void FixedUpdate()
    {

        //Puertas Laboratorio
        if (puertaIzq == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(5.42f, -1.82f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaIzq = false;

        }
        if (puertaDer == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(2.67f, -1.82f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            puertaDer = false;
        }

        if (Salir == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(34.9f, -3.2f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            Salir = false;
        }

        if (Entrar == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(27.28f, -1.88f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            Entrar = false;
        }

        //Puertas Fabrica

        if (EntrFabr == true & Input.GetKey(KeyCode.E))
        {
            transform.position = new Vector3(196.9f, 7.95f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            EntrFabr = false;
        }
        if (SalidaFab == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(133.3f, 6.1f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            SalidaFab = false;
        }
        if (PuertaFD1 == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(324.41f, 7.99f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            PuertaFD1 = false;
        }
        if (PuertaFI1 == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(329.86f, 7.99f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            PuertaFI1 = false;
        }
        if (PuertaFD2 == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(348.98f, 7.99f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            PuertaFD2 = false;
        }
        if (PuertaFI2 == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(353.62f, 7.99f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            PuertaFI2 = false;
        }
        if (PuertaFD3 == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(361.7f, 7.99f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            PuertaFD3 = false;
        }
        if (PuertaFI3 == true & Input.GetKey(KeyCode.E) & Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(366.48f, 7.99f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            PuertaFI3 = false;
        }

        //Puertas Escaleras
        if (EscP12 == true & Input.GetKey(KeyCode.E))
        {
            transform.position = new Vector3(424.4f, 35.1f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            EscP12 = false;
        }
        if (EscP21 == true & Input.GetKey(KeyCode.E))
        {
            transform.position = new Vector3(367.9f, 8f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            EscP21 = false;
        }
        if (EscP23 == true & Input.GetKey(KeyCode.E))
        {
            transform.position = new Vector3(195.7f, 66.2f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            EscP21 = false;
        }
        if (EscP32 == true & Input.GetKey(KeyCode.E))
        {
            transform.position = new Vector3(195.7f, 32.9f, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            EscP21 = false;
        }



    }

}


