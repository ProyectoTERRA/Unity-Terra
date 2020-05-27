using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeCayo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.SendMessage("TresCorazones");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
