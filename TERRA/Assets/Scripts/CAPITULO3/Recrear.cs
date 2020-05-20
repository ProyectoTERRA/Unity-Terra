using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recrear : MonoBehaviour
{
    // Start is called before the first frame update
    private bool iniciar;
    void Start()
    {
        iniciar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (iniciar)
        {
            if (GameController.l1)
            {
                Destroy(GameObject.Find("l1"));
            }
            if (GameController.l2)
            {
                Destroy(GameObject.Find("l2"));
            }
            if (GameController.l3)
            {
                Destroy(GameObject.Find("l3"));
            }
            if (GameController.l4)
            {
                Destroy(GameObject.Find("l4"));
            }
            if (GameController.l5)
            {
                Destroy(GameObject.Find("l5"));
            }
            if (GameController.m1)
            {
                Destroy(GameObject.Find("m1"));
            }
            if (GameController.m2)
            {
                Destroy(GameObject.Find("m2"));
            }
            if (GameController.m3)
            {
                Destroy(GameObject.Find("m3"));
            }
            if (GameController.m4)
            {
                Destroy(GameObject.Find("m4"));
            }
            if (GameController.m5)
            {
                Destroy(GameObject.Find("m5"));
            }
            iniciar = false;
        }
    }
}
