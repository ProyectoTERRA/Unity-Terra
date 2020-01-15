using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    string nombre = "";
    public GameObject cartel, boton1, boton2, boton3, boton4, boton5, bt1, bt2, bt3, bt4, bt5;
    // Start is called before the first frame update
    private void Update()
    {
        if (nombre.Length >= 5)
        {
            
            if (nombre == "reusa")
            {
                Debug.Log("Nombre correcto " + nombre);
                cartel.SetActive(true);
                StartCoroutine(apagarcartel());
                
            }
            else
            {
                Debug.Log("Nombre incorrecto " + nombre);
                nombre = "";
                boton1.SetActive(false);
                boton2.SetActive(false);
                boton3.SetActive(false);
                boton4.SetActive(false);
                boton5.SetActive(false);
                bt1.SetActive(true);
                bt2.SetActive(true);
                bt3.SetActive(true);
                bt4.SetActive(true);
                bt5.SetActive(true);
            }
        }
    }
    IEnumerator apagarcartel()
    {
        yield return new WaitForSeconds(5);
        cartel.SetActive(false);
        nombre = "";
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coco")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                string letra = collision.gameObject.name;
                if (letra == "botonApagado")
                {
                    nombre += "e";
                    boton1.SetActive(true);
                    bt1.SetActive(false);
                }
                if (letra == "botonApagado1")
                {
                    nombre += "r";
                    boton2.SetActive(true);
                    bt2.SetActive(false);
                }
                if (letra == "botonApagado2")
                {
                    nombre += "u";
                    boton3.SetActive(true);
                    bt3.SetActive(false);
                }
                if (letra == "botonApagado3")
                {
                    nombre += "a";
                    boton4.SetActive(true);
                    bt4.SetActive(false);
                }
                if (letra == "botonApagado4")
                {
                    nombre += "s";
                    boton5.SetActive(true);
                    bt5.SetActive(false);
                }
                Debug.Log("Nombre " + nombre);
            }

        }
    }
}
