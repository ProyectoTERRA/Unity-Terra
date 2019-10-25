using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject objectToPick, pickedObject, mensaje2, mensaje3;
    public Transform interactionZone;

    void Update()
    {
        
        if (objectToPick != null && objectToPick.GetComponent<Pickable>().coger == true && pickedObject == null)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {                
                pickedObject = objectToPick;
                pickedObject.GetComponent<Pickable>().coger = false;
                pickedObject.transform.SetParent(interactionZone);
                pickedObject.transform.position = interactionZone.position;
                pickedObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                pickedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                mensaje2.SetActive(true);
                StartCoroutine(test());
            }
        }
        else if(pickedObject!=null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {                
                pickedObject.GetComponent<Pickable>().coger = true;
                pickedObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                pickedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                pickedObject = null;
                mensaje3.SetActive(true);
                StartCoroutine(enumerator());
            }
        }
    }
    public IEnumerator test()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Si se espero");
        mensaje2.SetActive(false);
    }
    public IEnumerator enumerator()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Si se espero");
        mensaje3.SetActive(false);
    }
}
