using UnityEngine;
using UnityEngine.SceneManagement;

public class PickFormula : MonoBehaviour
{
    public static string nombre;
    int contador;
    private void Start()
    {
        contador = 0;
    }
    public void Update()
    {
        if(PlayerController.Equip == "Recogedor")
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "formula")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameController.formula++;
                Destroy(GameObject.Find(collision.gameObject.tag));
            }
        }
        if (collision.gameObject.tag == "formula1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameController.formula++;
                Destroy(GameObject.Find(collision.gameObject.tag));
            }
        }
        if(collision.gameObject.name == "cientifico1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                contador++;
                if(contador >= 3)
                {
                    GameController.LobbyCAP = 3;
                    SceneManager.LoadScene("LOBBY");
                }                
            }
        }

        Debug.Log("Totalde formula "+ GameController.formula);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bolsa" && PlayerController.Equip == "Recogedor")
        {
            nombre = collision.gameObject.name;
            codificador();
        }
        if (collision.gameObject.tag == "lata" && PlayerController.Equip == "Recogedor")
        {
            nombre = collision.gameObject.name;
            codificador();
        }
        if (collision.gameObject.tag == "manzana" && PlayerController.Equip == "Recogedor")
        {
            nombre = collision.gameObject.name;
            codificador();
        }
    }
    private void codificador()
    {
        Debug.Log("NNNNNNNNNNNNNNNNNNNNNNNNNOMMMMMMBREEEE " + nombre);
        if (nombre == "b1")
        {
            GameController.b1 = true;
        }
        if (nombre == "b2")
        {
            GameController.b2 = true;
        }
        if (nombre == "b3")
        {
            GameController.b3 = true;
        }
        if (nombre == "b4")
        {
            GameController.b4 = true;
        }
        if (nombre == "b5")
        {
            GameController.b5 = true;
        }

        if (nombre == "l1")
        {
            GameController.l1 = true;
        }
        if (nombre == "l2")
        {
            GameController.l2 = true;
        }
        if (nombre == "l3")
        {
            GameController.l3 = true;
        }
        if (nombre == "l4")
        {
            GameController.l4 = true;
        }
        if (nombre == "l5")
        {
            GameController.l5 = true;
        }

        if (nombre == "m1")
        {
            GameController.m1 = true;
        }
        if (nombre == "m2")
        {
            GameController.m2 = true;
        }
        if (nombre == "m3")
        {
            GameController.m3 = true;
        }
        if (nombre == "m4")
        {
            GameController.m4 = true;
        }
        if (nombre == "m5")
        {
            GameController.m5 = true;
        }
    }
}
