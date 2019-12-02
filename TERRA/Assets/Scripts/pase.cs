using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pase : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "limite")
        {
            transform.position = new Vector2(-11.36f, -4.3f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (collision.gameObject.tag == "alcantarilla")
        {
            GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            heart_Bar.hearts -= 2;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "life")
        {
            GameObject vida = GameObject.Find("Heart Bar - HUD_0");
            Heart_Bar heart_Bar = vida.GetComponent<Heart_Bar>();
            heart_Bar.hearts--;
        }
    }

}
