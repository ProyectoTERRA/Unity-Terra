using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCap6 : MonoBehaviour
{
    public GameObject Form1, Form2;
    public bool Part1, Part2;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Form1")
        {
            Part1 = true;
        }
        if (collision.gameObject.tag == "Form2")
        {
            Part2 = true;
        }


    }

    void Update()
    {
        if(Part1 == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(Form1);
        }
        if (Part2 == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(Form2);
        }
    }
}
