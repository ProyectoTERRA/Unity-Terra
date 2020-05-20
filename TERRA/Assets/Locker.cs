using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject Lk1, Lk2, Lk3, Lk4, Lk5;
    public bool L1, L2, L3, L4, L5;
    void Start()
    {
        Lk1 = GetComponent<GameObject>();
        Lk2 = GetComponent<GameObject>();
        Lk3 = GetComponent<GameObject>();
        Lk4 = GetComponent<GameObject>();
        Lk5 = GetComponent<GameObject>();
    }

    private void Update()
    {
        if(L1 == true && Input.GetKey(KeyCode.E))
        {
            Lk1.SetActive(true);
            L1 = false;
        }

        else if (L2 == true && Input.GetKey(KeyCode.E))
        {
            Lk2.SetActive(true);
            L2 = false;
        }

        else if (L3 == true && Input.GetKey(KeyCode.E))
        {
            Lk3.SetActive(true);
            L3 = false;
        }

        else if (L4 == true && Input.GetKey(KeyCode.E))
        {
            Lk4.SetActive(true);
            L4 = false;
        }

        else if (L5 == true && Input.GetKey(KeyCode.E))
        {
            Lk5.SetActive(true);
            L5 = false;
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
    }
}
