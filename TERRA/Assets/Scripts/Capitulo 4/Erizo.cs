using UnityEngine;

public class Erizo : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.SendMessage("EnemyKnockBack", transform.position.x);
        }
    }
}
