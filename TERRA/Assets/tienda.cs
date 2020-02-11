using UnityEngine;

public class tienda : MonoBehaviour
{
    public GameObject SaltoDoble;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SaltoDoble.SetActive(true);
            Debug.Log("Colision");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        SaltoDoble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
