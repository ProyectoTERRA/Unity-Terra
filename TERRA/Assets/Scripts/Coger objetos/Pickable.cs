using UnityEngine;

public class Pickable : MonoBehaviour
{
    public bool coger = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInteractionZone")
        {
            collision.GetComponentInParent<PickUpObject>().objectToPick = this.gameObject;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerInteractionZone")
        {
            collision.GetComponentInParent<PickUpObject>().objectToPick = null;
        }
    }

}
