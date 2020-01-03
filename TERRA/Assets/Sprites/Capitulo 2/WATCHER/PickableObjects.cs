using UnityEngine;

public class PickableObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPickable = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "InteraccionWatcher")
        {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = this.gameObject;
        }
    }
}
