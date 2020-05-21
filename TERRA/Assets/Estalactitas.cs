using UnityEngine;

public class Estalactitas : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Estalactita")
        {
            collision.SendMessage("EnemyKnockBack", transform.position.x + 1);
        }
    }
}
