using UnityEngine;

public class PickFormula : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "formula")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameController.formula++;
                Destroy(GameObject.Find(collision.gameObject.tag));
            }
        }
        if (collision.gameObject.tag == "formula1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("FORMULA 1");
                GameController.formula++;
                Destroy(GameObject.Find(collision.gameObject.tag));
                Debug.Log("GAME OBJECT " + collision.gameObject.tag);
            }
        }
        Debug.Log("Totalde formula "+ GameController.formula);
    }
}
