using UnityEngine;

public class CogerLatas : MonoBehaviour
{
    public GameObject objectToPick, pickedObject;
    public Transform interactionZone;

    private void Start()
    {
        Heart_Bar.Phearts = GameController.corazones;
        Heart_Bar.life = GameController.vidas;
        //Heart_Bar.Phearts = 3;
        //Heart_Bar.life = 2;
        //GameController.TypeLife = 2;
    }
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
        if (collision.gameObject.tag == "coco")
        {
            Heart_Bar.Phearts--;
        }
    }
}
