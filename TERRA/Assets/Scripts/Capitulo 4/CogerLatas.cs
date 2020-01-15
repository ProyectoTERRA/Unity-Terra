using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerLatas : MonoBehaviour
{
    public GameObject objectToPick, pickedObject;
    public Transform interactionZone;
    void Update()
    {
        if (objectToPick != null && objectToPick.GetComponent<Cogible>().coger == true && pickedObject == null)
        {   
                Debug.Log("Objeto " + objectToPick.tag);
                pickedObject = objectToPick;
                pickedObject.GetComponent<Cogible>().coger = false;
                pickedObject.transform.SetParent(interactionZone);
                pickedObject.transform.position = interactionZone.position;
                pickedObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                pickedObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else if (pickedObject != null)
        {
                pickedObject.GetComponent<Cogible>().coger = true;
                pickedObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                pickedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                pickedObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coco")
        {
            GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            heart_Bar.hearts--;
        }
    }
}
