using System.Collections;
using UnityEngine;

public class Botones : MonoBehaviour
{
    string nombre = "";
    public GameObject cartel, boton1, boton2, boton3, boton4, boton5, bt1, bt2, bt3, bt4, bt5;
    public GameObject puertaA1, puertaC1, puertaA2, puertaC2, puertA4, puertaC4, jugador, key1, key2;
    public GameObject mensaje, interruptor1, interruptor2, interruptor3, interruptor4, interruptor5, interruptor6, jefe, bossLife;
    public static int enemigos = 0;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Limit")
        {
            jugador.transform.position = new Vector2(-27.8f, -2.52f);
            Heart_Bar.Phearts--;
        }

    }
    private void Update()
    {
        Debug.Log("Enemigos eliminados " + enemigos);
        if (enemigos >= 8)
        {
            key2.SetActive(false);
            puertaA2.SetActive(true);
            puertaC2.SetActive(false);
        }
        if (nombre.Length >= 5)
        {

            if (nombre == "reusa")
            {
                key1.SetActive(false);
                Debug.Log("Nombre correcto " + nombre);
                cartel.SetActive(true);
                StartCoroutine(apagarcartel());
                puertaA1.SetActive(true);
                puertaC1.SetActive(false);
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
    IEnumerator apagarMensaje()
    {
        yield return new WaitForSeconds(2);
        mensaje.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "interruptores")
        {
            Debug.Log("Interruptres");
            if (Input.GetKeyDown(KeyCode.E))
            {
                mensaje.SetActive(true);
                StartCoroutine(apagarMensaje());
                interruptor1.SetActive(false);
                interruptor2.SetActive(false);
                interruptor3.SetActive(false);
                interruptor4.SetActive(false);
                interruptor5.SetActive(false);
                interruptor6.SetActive(false);
                puertaC4.SetActive(true);
                puertA4.SetActive(false);
                jugador.transform.position = new Vector2(105.8f, -2.52f);
                jefe.SetActive(true);
                bossLife.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "interruptor")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Heart_Bar.Phearts--;
            }
        }
        if (collision.gameObject.name == "puertaPA3")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                jugador.transform.position = new Vector2(19.5f, -2.52f);
            }
        }
        if (collision.gameObject.name == "puertaPA4")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                jugador.transform.position = new Vector2(14.18f, -2.52f);
            }
        }
        if (collision.gameObject.name == "puertaPA1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                jugador.transform.position = new Vector2(72.6f, -2.52f);
            }
        }
        if (collision.gameObject.name == "puertaPA2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                jugador.transform.position = new Vector2(66f, -2.52f);
            }
        }
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
