using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject Lk1, Lk2, Lk3, Lk4, Lk5, Bloqueo, KeyC;
    public bool L1, L2, L3, L4, L5,Key;
    void Start()
    {
        
    }

    private void Update()
    {
        if(L1 == true && Input.GetKeyDown(KeyCode.E))
        {
            Lk1.SetActive(true);
            L1 = false;
        }

       if (L2 == true && Input.GetKeyDown(KeyCode.E))
        {
            Lk2.SetActive(true);
            L2 = false;
        }

         if (L3 == true && Input.GetKeyDown(KeyCode.E))
        {
            Lk3.SetActive(true);
            L3 = false;
        }

       if (L4 == true && Input.GetKeyDown(KeyCode.E))
        {
            Lk4.SetActive(true);
            L4 = false;
        }

       if (L5 == true && Input.GetKeyDown(KeyCode.E))
        {
            Lk5.SetActive(true);
            L5 = false;
        }

        if (Key == true && Input.GetKeyDown(KeyCode.E)) 
        {
            Destroy(KeyC);
            Bloqueo.SetActive(false);

        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Lock1")
        {
            L1 = true;
        }

        if (col.gameObject.tag == "Lock2")
        {
            L2 = true;
        }

        if (col.gameObject.tag == "Lock3")
        {
            L3 = true;
        }

        if (col.gameObject.tag == "Lock4")
        {
            L4 = true;
        }

        if (col.gameObject.tag == "Lock5")
        {
            L5 = true;
        }

        if (col.gameObject.tag == "KeyCardTerra")
        {
            Key = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        L1 = false;
        L2 = false;
        L3 = false;
        L4 = false;
        L5 = false;
    }
}
