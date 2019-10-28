using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
<<<<<<< HEAD
    public string manzana;
=======
    


    // Start is called before the first frame update
>>>>>>> 9cec2d7defee081eddb517639edc4aa7fc4a8708
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
<<<<<<< HEAD
        manzana = other.gameObject.name;

        if (manzana =="manzana")
        {
            radial.basura[3]++;
            Destroy(GameObject.Find(manzana));
        }
    }
=======
        
        
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

>>>>>>> 9cec2d7defee081eddb517639edc4aa7fc4a8708
}

