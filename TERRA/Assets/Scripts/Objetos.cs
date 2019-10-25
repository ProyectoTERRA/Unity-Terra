﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {

        




    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();
        
        
        Debug.Log("Hay una colision");
        

        if (other.gameObject.tag == "pila")
        {
            string nombre = other.gameObject.name;
            radial.basura[0]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "bolsa")
        {
            string nombre = other.gameObject.name;
            radial.basura[1]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "carton")
        {
            string nombre = other.gameObject.name;
            radial.basura[2]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "manzana")
        {
            string nombre = other.gameObject.name;
            radial.basura[3]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "platano")
        {
            string nombre = other.gameObject.name;
            radial.basura[4]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "lata")
        {
            string nombre = other.gameObject.name;
            radial.basura[5]++;

            Destroy(GameObject.Find(nombre));
        }
    }

}
