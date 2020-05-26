using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLMAO : MonoBehaviour
{
    public GameObject LMAOB;
    Transform LMAOMAO;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LMAOMAO.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            LMAOMAO.localScale = new Vector3(1, 1, 0);
        }
    }

    void Update()
    {
        
    }
}
