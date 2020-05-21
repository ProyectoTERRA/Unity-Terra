using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerrotarWatcher : MonoBehaviour
{
    public GameObject btnDesact, btnAct;
    public Animator anim;
    public bool Act, Desact, PressA, PressD, Enable;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BtnAct" && Act == true)
        {
            PressA = true;
        }
        if (collision.gameObject.tag == "BtnDes" && Desact == true)
        {
            PressD = true;
        }
    }

    void Start()
    {
        Act = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(PressA == true && Input.GetKeyDown(KeyCode.E))
        {
            Activado();
        }
        else if (PressD == true && Input.GetKeyDown(KeyCode.E))
        {
            Desactivado();
        }

    }

    void Activado()
    {
        btnAct.SetActive(false);
        anim.SetTrigger("Open");
        anim.SetTrigger("StayO");
        Desact = true;
        Act = false;
        PressA = false;
        btnDesact.SetActive(true);
    }
    
    void Desactivado()
    {
        btnDesact.SetActive(false);
        anim.SetTrigger("Close");
        anim.SetTrigger("StayC");
        Desact = false;
        Act = true;
        PressD = false;
        btnAct.SetActive(true);
    }

}
