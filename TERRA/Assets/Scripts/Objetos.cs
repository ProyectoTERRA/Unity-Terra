using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    
    public string manzana;
    


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
        if(other.gameObject.tag =="manzana")
        {
            manzana = other.gameObject.name;
            Debug.Log("Ha habido una colision con la manzana");
            radial.basura[3]++;

            Destroy(GameObject.Find(manzana));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

