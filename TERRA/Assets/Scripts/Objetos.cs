using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public void Start()
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();
        radial.basura[0] = GameController.pila;
        radial.basura[1] = GameController.bolsa;
        radial.basura[2] = GameController.carton;
        radial.basura[3] = GameController.manzana;
        radial.basura[4] = GameController.platano;
        radial.basura[5] = GameController.lata;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = GameObject.Find("InvFunc");
        radial radial = go.GetComponent<radial>();

        if (other.gameObject.tag == "pila")
        {
            GameController.pila++;
            string nombre = other.gameObject.name;
            radial.basura[0]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "bolsa")
        {
            GameController.bolsa++;
            string nombre = other.gameObject.name;
            radial.basura[1]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "carton")
        {
            GameController.carton++;
            string nombre = other.gameObject.name;
            radial.basura[2]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "manzana")
        {
            GameController.manzana++;
            string nombre = other.gameObject.name;
            radial.basura[3]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "platano")
        {
            GameController.platano++;
            string nombre = other.gameObject.name;
            radial.basura[4]++;
            Destroy(GameObject.Find(nombre));
        }

        if (other.gameObject.tag == "lata")
        {
            GameController.lata++;
            string nombre = other.gameObject.name;
            radial.basura[5]++;

            Destroy(GameObject.Find(nombre));
        }
    }

}

