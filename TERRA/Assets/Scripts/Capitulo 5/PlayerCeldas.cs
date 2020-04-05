using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCeldas : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject Equip;
    [SerializeField] private GameObject Door;

    [SerializeField] private GameObject c1;
    [SerializeField] private GameObject c2;
    [SerializeField] private GameObject c3;


    public bool s1, s2, hide, h, jail;
    public Sprite door;
    private float hx;
    // Start is called before the first frame update
    void Start()
    {
        s1 = true;
        s2 = false;
        hide = false;
        jail = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && h)//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("plop");

            //StartCoroutine(push());
            hide = !hide;
        }
        Debug.Log(hide);
        if (hide)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Level";
            GetComponent<SpriteRenderer>().sortingOrder = -2;
            Equip.GetComponent<SpriteRenderer>().sortingLayerName = "Level";
            Equip.GetComponent<SpriteRenderer>().sortingOrder = -1;
            GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(hx, transform.position.y);
        }
        else if(!hide && !jail)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            Equip.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            Equip.GetComponent<SpriteRenderer>().sortingOrder = 1;
            GetComponent<PlayerController>().enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DoorOpenPanel 1" || collision.gameObject.name == "DoorOpenPanel 2" || 
            collision.gameObject.name == "DoorOpenPanel 3" || collision.gameObject.name == "DoorOpenPanel 4" ||
            collision.gameObject.name == "DoorOpenPanel 5" || collision.gameObject.name == "DoorOpenPanel 6" )//compara si hizo la colision con el objeto correcto
        {
            h = false;
        }
        if (collision.gameObject.name == "Tran1" && s1)//compara si hizo la colision con el objeto correcto
        {


            s1 = false;
            s2 = true;
            camera.transform.position = new Vector3(18.0f, 0.0f, -10.0f);


        }

        if (collision.gameObject.name == "Tran2" && s2)//compara si hizo la colision con el objeto correcto
        {

            s1 = true;
            s2 = false;
            camera.transform.position = new Vector3(0.0f, 0.0f, -10.0f);


        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.name == "DoorLocked")//compara si hizo la colision con el objeto correcto
        {
           
            Door.GetComponent<SpriteRenderer>().sprite = door;
            Destroy(c1);
            Destroy(c2);
            Destroy(c3);
            jail = false;
        }
        if (collision.gameObject.name == "DoorOpenPanel 1")//compara si hizo la colision con el objeto correcto
        {
            hx = -3f;
            h = true;
        }
        if (collision.gameObject.name == "DoorOpenPanel 2")//compara si hizo la colision con el objeto correcto
        {
            hx = 2f;
            h = true;
        }
        if (collision.gameObject.name == "DoorOpenPanel 3")//compara si hizo la colision con el objeto correcto
        {
            hx = 7f;
            h = true;
        }
        if (collision.gameObject.name == "DoorOpenPanel 4")//compara si hizo la colision con el objeto correcto
        {
            hx = 11.1f;
            h = true;
        }
        if (collision.gameObject.name == "DoorOpenPanel 5")//compara si hizo la colision con el objeto correcto
        {
            hx = 16.1f;
            h = true;
        }
        if (collision.gameObject.name == "DoorOpenPanel 6")//compara si hizo la colision con el objeto correcto
        {
            hx = 25.1f;
            h = true;
        }

    }


    public IEnumerator push()
    {
        
        yield return new WaitForSeconds(.5f);
        Debug.Log("p1: " + hide);
        hide = !hide;
        Debug.Log("p2: " + hide);
    }
}
