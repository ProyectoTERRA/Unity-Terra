using UnityEngine;

public class PickFormula : MonoBehaviour
{
    public static string nombre;
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
        if (collision.gameObject.tag == "bolsa" && PlayerController.Equip == "Recogedor")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("FORMULA 1");
                GameController.formula++;
                Destroy(GameObject.Find(collision.gameObject.tag));
            }
        }
        if (collision.gameObject.tag == "BolsaFAKE" && PlayerController.Equip == "Recogedor")
        {

            nombre = collision.gameObject.name;
            agarrar = true;

        }

        Debug.Log("Totalde formula "+ GameController.formula);
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
    }
}
