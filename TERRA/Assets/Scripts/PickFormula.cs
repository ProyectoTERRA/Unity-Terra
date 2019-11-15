using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFormula : MonoBehaviour
{
    bool invent;
    int numFormula;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag ==  "formula")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                invent = true;
                numFormula++;
            }
        }        
    }
}
