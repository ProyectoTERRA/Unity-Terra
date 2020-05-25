using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCap6 : MonoBehaviour
{
    public GameObject Compu;
    public bool Active, DI, DD;
    DivIzqM DivI;
    MiniPuto2 DivD;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DI == true && DD == true && Active == true && Input.GetKeyDown(KeyCode.E))
        {
            Compu.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Active = true;
        }
    }

    void DivIzqDesact()
    {
        DI = true;
    }

    void DivDerDesact()
    {
        DD = true;
    }
}
