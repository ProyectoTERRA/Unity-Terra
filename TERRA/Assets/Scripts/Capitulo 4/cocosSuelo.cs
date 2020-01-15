using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocosSuelo : MonoBehaviour
{
    public GameObject coco1, coco2, coco3, coco4, coco5, coco6, coco7, coco8, coco9, coco10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "coco1")
        {
            coco1.transform.position = new Vector2(-4, 5);
            coco1.SetActive(false);
        }
        if (collision.name == "coco2")
        {
            coco2.transform.position = new Vector2(-4, 5);
            coco2.SetActive(false);
        }
        if (collision.name == "coco3")
        {
            coco3.transform.position = new Vector2(0, 5);
            coco3.SetActive(false);
        }
        if (collision.name == "coco4")
        {
            coco4.transform.position = new Vector2(0, 5);
            coco4.SetActive(false);
        }
        if (collision.name == "coco5")
        {
            coco5.transform.position = new Vector2(4f, 5);
            coco5.SetActive(false);
        }
        if (collision.name == "coco6")
        {
            coco6.transform.position = new Vector2(4f, 5);
            coco6.SetActive(false);
        }
        if (collision.name == "coco7")
        {
            coco7.transform.position = new Vector2(8f, 5);
            coco7.SetActive(false);
        }
        if (collision.name == "coco8")
        {
            coco8.transform.position = new Vector2(8f, 5);
            coco8.SetActive(false);
        }
        if (collision.name == "coco9")
        {
            coco9.transform.position = new Vector2(12f, 5);
            coco9.SetActive(false);
        }
        if (collision.name == "coco10")
        {
            coco10.transform.position = new Vector2(12f, 5);
            coco10.SetActive(false);
        }
    }
}
