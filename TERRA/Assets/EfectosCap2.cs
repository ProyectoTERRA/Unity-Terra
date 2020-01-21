using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosCap2 : MonoBehaviour
{
    public bool PlatD, PlatSD, PlatI, PlatSI;
    Rigidbody2D myrb;
    
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PlatD")//compara si hizo la colision con el objeto correcto
        {
            PlatD = true;
        }

        if (collision.name == "PlatSD")//compara si hizo la colision con el objeto correcto
        {
            PlatSD = true;
        }
        
        if (collision.name == "PlatI")//compara si hizo la colision con el objeto correcto
        {
            PlatI = true;
        }

        if (collision.name == "PlatSI")//compara si hizo la colision con el objeto correcto
        {
            PlatSI = true;
        }
    }

    //Funciones de Impulso para las plataformas

    void ImpulsePlatD()
    {
        myrb.AddForce(new Vector2(10f, 0.2f), ForceMode2D.Impulse);
    }

    void ImpulsePlatSD()
    {
        myrb.AddForce(new Vector2(15f, 0.2f), ForceMode2D.Impulse);

    }

    void ImpulsePlatI()
    {
        myrb.AddForce(new Vector2(-10f, 0.2f), ForceMode2D.Impulse);

    }

    void ImpulsePlatSI()
    {
        myrb.AddForce(new Vector2(-15f, 0.2f), ForceMode2D.Impulse);

    }


    public void OnTriggerExit2D(Collider2D LabDoor)
    {
        PlatD = false;
        PlatSD = false;
        PlatI = false;
        PlatSI = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlatD == true)
        {
            ImpulsePlatD();
        }

        if (PlatSD == true)
        {
            ImpulsePlatSD();
        }

        if (PlatI == true)
        {
            ImpulsePlatI();
        }

        if (PlatSI == true)
        {
            ImpulsePlatSI();
        }
    }
}
