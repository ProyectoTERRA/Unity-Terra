using UnityEngine;

public class Estalactitas : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Colision Jugador");
            SendMessage("Knockback");
        }
    }
}
