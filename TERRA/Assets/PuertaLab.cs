﻿using UnityEngine;



public class PuertaLab : MonoBehaviour
{

    public bool P1Ar, P2Ar, P3Ar, P1Ab, P2Ab, P3Ab, PI1,PD1, PDD, PDI;
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D collision)
    {
        #region Puertas
        if (collision.name == "PuertaFI1")
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
        
        if(collision.name == "PD1")
        {
            PD1 = true;
        }
        if (collision.name == "PI1")
        {
            PI1 = true;
        }

        if (collision.name == "PDI")
        {
            PDI = true;
        }
        if (collision.name == "PDD")
        {
            PDD = true;
        }

        #endregion

        #region Escaleras
        if (collision.name == "EscP12")
        {
            P1Ar = true;
        }
        if (collision.name == "EscP21")
        {
            P1Ab = true;
        }

        if (collision.gameObject.tag == "EscP23")
        {
            P2Ar = true;
        }
        if (collision.name == "EscP32")
        {
            P2Ab = true;
        }
        #endregion
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        P1Ar = false;
        P1Ab = false;
        P2Ar = false;
        P2Ab = false;
        PD1 = false;
        PI1 = false;
        PDI = false;
        PDD = false;
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        if(P1Ar == true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(424.89f, 26.98f, 0);
            P1Ar = false;
        }

        if (P1Ab == true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(366.5f, -10f, 0);
            P1Ab = false;
        }

        if (P2Ar == true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(193.92f, 65.97f, 0);
            P2Ar = false;
        }

        if (P2Ab == true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(196.4f, 24.5f, 0);
            P2Ab = false;
        }
        
        if (PD1 == true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(197.4f, 24.5f, 0);
            PD1 = false;
        }

        if (PI1 == true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(201f, 24.5f, 0);
            PI1 = false;
        }

        if (PDD == true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(509f, 66.30f, 0);
            PD1 = false;
        }

        if (PDI == true && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(513f, 66.30f, 0);
            PI1 = false;
        }

    }

}


