using System.Collections;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject objectToPick, pickedObject, mensaje2, mensaje3;
    public Transform interactionZone;
    void Update()
    {
        if (objectToPick != null && objectToPick.GetComponent<Pickable>().coger == true && pickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickedObject = objectToPick;
                pickedObject.GetComponent<Pickable>().coger = false;
                pickedObject.transform.SetParent(interactionZone);
                pickedObject.transform.position = interactionZone.position;
                pickedObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                pickedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                mensaje2.SetActive(true);
                StartCoroutine(test());
                if (objectToPick.tag == "lave")
                {
                    GameController.llave = 1;
                }
            }
        }
        else if (pickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickedObject.GetComponent<Pickable>().coger = true;
                pickedObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                pickedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                pickedObject = null;
                mensaje3.SetActive(true);
                StartCoroutine(test());
            }
        }
    }
    public IEnumerator test()
    {
        yield return new WaitForSeconds(3);
        mensaje2.SetActive(false);
        mensaje3.SetActive(false);
    }
}
