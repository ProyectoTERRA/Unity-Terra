using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public string manzana;
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();
        manzana = other.gameObject.name;

        if (manzana =="manzana")
        {
            radial.basura[3]++;
            Destroy(GameObject.Find(manzana));
        }
    }
}

