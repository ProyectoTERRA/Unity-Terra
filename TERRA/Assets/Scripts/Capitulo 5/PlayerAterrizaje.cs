using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAterrizaje : MonoBehaviour
{
    [SerializeField] private GameObject Key_Diana;
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
        if (collision.gameObject.name== "Diana" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Cap6");

            Key_Diana.SetActive(false);
        }
      
    }
}
