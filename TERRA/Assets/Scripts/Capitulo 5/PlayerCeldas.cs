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

    [SerializeField] private GameObject list;

    [SerializeField] private GameObject interZ;
    [SerializeField] private GameObject GroundC;

    [SerializeField] private GameObject Mini;

    [SerializeField] private GameObject enemyCol;



    static public bool s1, s2, hide, h, jail, GUsed, Complete_mini;
    public Sprite door ;
    private float hx, hy;

    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        Complete_mini = false;
        s1 = true;
        s2 = false;
        hide = false;
        jail = true;
        GUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Prueba.side + " - " + s2);
        if (!jail) enemyCol.transform.position = new Vector3(-8.75f, enemyCol.transform.position.y);
        if (Input.GetKeyUp(KeyCode.E) && h)//compara si hizo la colision con el objeto correcto
        {

            hy = transform.position.y;
            //StartCoroutine(push());
            hide = !hide;
            if (!hide)
            {
                transform.position = new Vector3(hx, -1.4f);
            }
           
        }

        if (hide)
        {
            //GetComponent<Collider2D>()

            GroundC.SetActive(false);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().sortingLayerName = "Level";
            GetComponent<SpriteRenderer>().sortingOrder = -2;
            Equip.GetComponent<SpriteRenderer>().sortingLayerName = "Level";
            Equip.GetComponent<SpriteRenderer>().sortingOrder = -1;
            GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(hx, -1.4f);
        }
        else if(!hide && !jail)
        {
            interZ.SetActive(true);
            GroundC.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            Equip.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            Equip.GetComponent<SpriteRenderer>().sortingOrder = 1;
            GetComponent<PlayerController>().enabled = true;
        }

        if (GUsed)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            radial.especiales[2]--;
            string normal = "ganzua";
            if (radial.especiales[2] <= 0) list.SendMessage("remove", normal);
            GUsed = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!hide && (collision.gameObject.name == "DoorOpenPanel 1" || collision.gameObject.name == "DoorOpenPanel 2" || 
            collision.gameObject.name == "DoorOpenPanel 3" || collision.gameObject.name == "DoorOpenPanel 4" ||
            collision.gameObject.name == "DoorOpenPanel 5" || collision.gameObject.name == "DoorOpenPanel 6" )){
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
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.name == "DoorLocked" && Complete_mini)//compara si hizo la colision con el objeto correcto
        {

            Door.GetComponent<SpriteRenderer>().sprite = door;
            Destroy(c1);
            Destroy(c2);
            Destroy(c3);
            jail = false;
            GUsed = true;
        }


        if (Input.GetKeyDown(KeyCode.J) && collision.gameObject.name == "DoorLocked" && PlayerController.Equip == "Especiales_2")//compara si hizo la colision con el objeto correcto
        {

            if (!Complete_mini)
            {
                Mini.SetActive(flag);
                GetComponent<PlayerController>().enabled = !flag;
                flag = !flag;

            }
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
        if ((Prueba.side == 0 && s1) && jail == false && collision.gameObject.name == "CargoElPayaso1" && !hide)
        {
            Debug.Log("Ha hecho colision con el jugador");



            GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(transform.position.x, -1.4f);


            StartCoroutine(push());
        }
        if (s2 && jail == false && collision.gameObject.name == "CargoElPayaso2" && !hide)
        {
            Debug.Log("Ha hecho colision con el jugador");



            GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(transform.position.x, -1.4f);


            StartCoroutine(push());
        }
        if (s2 && jail == false && collision.gameObject.name == "CargoElPayaso3" && !hide)
        {
            Debug.Log("Ha hecho colision con el jugador");



            GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(transform.position.x, -1.4f);


            StartCoroutine(push());
        }
    }


    public IEnumerator push()
    {
        
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
