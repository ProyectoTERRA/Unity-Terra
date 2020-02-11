using UnityEngine;

public class PickUpPuerta : MonoBehaviour
{
    public GameObject llave;
    public GameObject pasar;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Chapa")
        {
            Debug.Log("Chapa esta tocando la puerta");
            llave.SetActive(true);
        }
        if (collision.tag == "Llave")
        {
            Debug.Log("LLave esta tocando la puerta");
            pasar.SetActive(true);
        }
    }
}
