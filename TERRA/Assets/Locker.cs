using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject LockerAbierto;
    void Start()
    {
        LockerAbierto = GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("ColisionLocker");
            LockerAbierto.SetActive(true);

        }

    }
}
