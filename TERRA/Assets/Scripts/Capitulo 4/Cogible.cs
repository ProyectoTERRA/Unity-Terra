using UnityEngine;

public class Cogible : MonoBehaviour
{
    public bool coger = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LataInteractionZone")
        {
            collision.GetComponentInParent<CogerLatas>().objectToPick = this.gameObject;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LataInteractionZone")
        {
            collision.GetComponentInParent<CogerLatas>().objectToPick = null;
        }
    }
}
