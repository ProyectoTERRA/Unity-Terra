using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chulada : MonoBehaviour
{

    public GameObject Defender, PIC, BloqEle;
    public bool Recoger, DPIC;
    DefenderController def;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Chulada")
        {
            DPIC = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Recoger == true)
        {
            BloqEle.SetActive(true);
        }

        if(DPIC == true && Input.GetKeyDown(KeyCode.E))
        {
            PIC.SetActive(false);
            Defender.SetActive(true);
            Recoger = true;
        }
        
        if (def.IsDead == true)
        {
            BloqEle.SetActive(false);
        }
        

    }
}
