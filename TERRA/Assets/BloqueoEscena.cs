using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueoEscena : MonoBehaviour
{
    private BoxCollider2D BC2D;

    private void Start()
    {
        BC2D = GetComponent<BoxCollider2D>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            BC2D.isTrigger = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        BC2D.isTrigger = false;
    }

}
