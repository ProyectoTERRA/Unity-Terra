using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitActivator : MonoBehaviour
{
    [SerializeField] private GameObject Parte1;
    [SerializeField] private GameObject Parte2;
    [SerializeField] private GameObject Parte3;
    [SerializeField] private GameObject Parte4;
    [SerializeField] private GameObject Parte5;
    // Start is called before the first frame update
    private float rmX, rmR;
    private int rmM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Action")
        {
            Debug.Log("Puto");
            rmM = Random.Range(1, 5);
            if (rmM == 1)
            {
                rmR = Random.Range(0f, 359f);
                rmX = Random.Range(-12.5f, 5f);
                Instantiate(Parte1, new Vector3(rmX, transform.position.y - 5f, 0f), Quaternion.Euler(0f, 0f, rmR));
            }
            else if (rmM == 2)
            {
                rmR = Random.Range(0f, 359f);
                rmX = Random.Range(-12.5f, 5f);
                Instantiate(Parte2, new Vector3(rmX, transform.position.y - 5f, 0f), Quaternion.Euler(0f, 0f, rmR));
            }
            else if (rmM == 3)
            {
                rmR = Random.Range(0f, 359f);
                rmX = Random.Range(-12.5f, 5f);
                Instantiate(Parte3, new Vector3(rmX, transform.position.y - 5f, 0f), Quaternion.Euler(0f, 0f, rmR));
            }
            else if (rmM == 4)
            {
                rmR = Random.Range(0f, 359f);
                rmX = Random.Range(-12.5f, 5f);
                Instantiate(Parte4, new Vector3(rmX, transform.position.y - 5f, 0f), Quaternion.Euler(0f, 0f, rmR));
            }
            else
            {
                rmR = Random.Range(0f, 359f);
                rmX = Random.Range(-12.5f, 5f);
                Instantiate(Parte5, new Vector3(rmX, transform.position.y - 5f, 0f), Quaternion.Euler(0f, 0f, rmR));
            }
        }
    }
}
