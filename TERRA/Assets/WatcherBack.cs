using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherBack : MonoBehaviour
{
    public GameObject Watcher;
    void Start()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Watcher.transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            Watcher.transform.localScale = new Vector3(1, 1, 0);
        }
    }
   
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
