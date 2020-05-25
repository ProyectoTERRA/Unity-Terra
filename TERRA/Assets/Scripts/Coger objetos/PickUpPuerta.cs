using UnityEngine;

public class PickUpPuerta : MonoBehaviour
{
    public GameObject llave;
    public GameObject pasar, key12;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Chapa")
        {
            llave.SetActive(true);
        }
        if (collision.tag == "Llave")
        {
            pasar.SetActive(true);
            key12.SetActive(false);
        }
    }
}
