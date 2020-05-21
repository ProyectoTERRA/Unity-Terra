using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerrotarWatcher : MonoBehaviour
{
    public GameObject btnDesact, btnAct;
    Animator anim;
    public bool Act, Desact;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
