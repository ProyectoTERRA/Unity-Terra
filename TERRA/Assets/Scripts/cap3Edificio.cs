using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cap3Edificio : MonoBehaviour
{
    public GameObject mensaje1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        while (collision.gameObject.tag == "florero")
        {
            mensaje1.SetActive(true);
        }
    }
}
