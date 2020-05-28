using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esconderse : MonoBehaviour

{
    [SerializeField] private GameObject interZ;
    [SerializeField] private GameObject GroundC;
    [SerializeField] private GameObject Equip;

    static public bool hide, h,dies,jail;
    private float hx, hy;
    private SpriteRenderer spr;
    void Start()
    {
        hide = false;
        dies = false;
        jail = true;
    }

    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.E) && h)//compara si hizo la colision con el objeto correcto
        {

            hy = transform.position.y;
            //StartCoroutine(push());
            hide = !hide;
            if (!hide)
            {
                transform.position = new Vector3(hx, hy);
            }

        }
        
        if (hide)
        {
            //GroundC.SetActive(false);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sortingLayerName = "Level";
            GetComponent<SpriteRenderer>().sortingOrder = -2;
            Equip.GetComponent<SpriteRenderer>().sortingLayerName = "Level";
            Equip.GetComponent<SpriteRenderer>().sortingOrder = -1;
            GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(hx, hy);
        }
        else if (!hide)
        {
            interZ.SetActive(true);
            //GroundC.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            Equip.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            Equip.GetComponent<SpriteRenderer>().sortingOrder = 1;
            GetComponent<PlayerController>().enabled = true;
            PlayerController.movement = true;
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!hide && (collision.gameObject.name == "DoorOpenPanel 1" || collision.gameObject.name == "DoorOpenPanel 2" ||
            collision.gameObject.name == "DoorOpenPanel 3" || collision.gameObject.name == "DoorOpenPanel 4" ||
            collision.gameObject.name == "DoorOpenPanel 5" || collision.gameObject.name == "DoorOpenPanel 6" || collision.gameObject.name == "DoorOpenPanel 6"))
        {
            h = false;
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DoorOpenPanel 1")//compara si hizo la colision con el objeto correcto
        {
            hx = 231.33f;
            hy = 24.45f;
            h = true;
            //spr.color = Color.black;
            PlayerController.movement = false;
        }
        if (collision.gameObject.name == "DoorOpenPanel 2")//compara si hizo la colision con el objeto correcto
        {
            hx = 311.6f;
            hy = 26.85f;
            h = true;
            //spr.color = Color.black;
            PlayerController.movement = false;
        }
        if (collision.gameObject.name == "DoorOpenPanel 3")//compara si hizo la colision con el objeto correcto
        {
            hx = 323.04f;
            hy = 26.85f;
            h = true;
            //spr.color = Color.black;
            PlayerController.movement = false;
        }
        if (collision.gameObject.name == "DoorOpenPanel 4")//compara si hizo la colision con el objeto correcto
        {
            hx = 389.65f;
            hy = 26.85f;
            h = true;
            //spr.color = Color.black;
            PlayerController.movement = false;
        }
        if (collision.gameObject.name == "DoorOpenPanel 5")//compara si hizo la colision con el objeto correcto
        {
            hx = 403f;
            hy = 26.85f;
            h = true;
            //spr.color = Color.black;
            PlayerController.movement = false;
        }
        if (collision.gameObject.name == "DoorOpenPanel 6")//compara si hizo la colision con el objeto correcto
        {
            hx = 421.02f;
            hy = 26.9f;
            h = true;
            //spr.color = Color.black;
            PlayerController.movement = false;
        }
        if (collision.gameObject.name == "DoorOpenPanel 7")//compara si hizo la colision con el objeto correcto
        {
            hx = 244.45f;
            hy = 24.45f;
            h = true;
            //spr.color = Color.black;
            PlayerController.movement = false;
        }
    }

    }
