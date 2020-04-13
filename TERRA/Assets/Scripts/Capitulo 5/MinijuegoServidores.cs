using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinijuegoServidores : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    bool touch, enable, drag;
    float distance = 20;
    float inx, iny;
    [SerializeField] private GameObject Mini;
    [SerializeField] private GameObject Point;

    [SerializeField] private GameObject Mini1;

    [SerializeField] private GameObject Mini2;

    [SerializeField] private GameObject Mini3;
    public float Speed;
    Vector3 target;

    static public bool win;

    private bool G1, G2, G3;


    //[SerializeField] private GameObject Door;

    //public Sprite door;
    // Start is called before the first frame update
    void Start()
    {
        inx = 2.05f;
        iny = -2.5f;
        G1 = true;
        G2 = false;
        G3 = false;
        Mini1.SetActive(true);
        Mini2.SetActive(false);
        Mini3.SetActive(false);

        Speed = Speed * Time.deltaTime;
        enable = true;
        touch = false;
        drag = true;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!enable)
        {

            drag = false;
        }
        else
        {
            drag = true;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!enable)
        {
            drag = false;
            eventData.pointerDrag = null;
            enable = false;


        }
        if (drag)
        {
            Point.transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
            Point.GetComponent<CircleCollider2D>().radius = 0.02f;
            //Point.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            GetComponent<CircleCollider2D>().radius = 0.02f;
        }

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Point.transform.position = new Vector3(inx, iny, 0f);
        transform.position = new Vector3(inx, iny, 0f);
        Point.GetComponent<CircleCollider2D>().radius = 0.105f;
        GetComponent<CircleCollider2D>().radius = 0.105f;

    }
    /*
    void OnMouseDrag()
    {
        way.GetComponent<Collider2D>().enabled = true;
        Debug.Log("AHHH");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }*/

    // Update is called once per frame
    void Update()
    {
        Debug.Log("E: " + enable + " - D: " + drag);
        //Point.transform.position = transform.position;
        float distancia = Vector3.Distance(Point.transform.position, transform.position);
        distancia = distancia * 0.1f;
        Speed = Speed * Time.deltaTime;
        //Debug.Log(distancia);

        if (drag && enable)
        {
            target = Point.transform.position;
            target.z = 0;
            transform.position = Vector3.MoveTowards(transform.position, target, (2f / (distancia)) * Time.deltaTime);
            Debug.Log((3f / (distancia)) * Time.deltaTime);


        }



    }
    public void OnMouseOver()
    {
        touch = true;
    }
    void OnMouseExit()
    {
        touch = false;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.name != "Fondo 1" || collision.gameObject.name != "Fondo 2" || collision.gameObject.name != "Fondo 3")
        {

            enable = true;


        }
        else
        {
            enable = false;
        }
        if (collision.gameObject.name == "Fin1")
        {
            //PlayerCeldas.Complete_mini = true;
            inx = -1.6f;
            iny = -3.6f;
            enable = false;
            //Door.GetComponent<SpriteRenderer>().sprite = door;
            transform.position = new Vector3(inx, iny, 0f);
            Point.transform.position = new Vector3(inx, iny, 0f);
            G1 = false;
            G2 = true;
            Mini1.SetActive(false);
            Mini2.SetActive(true);

        }
        if (collision.gameObject.name == "Fin2")
        {
            inx = 0f;
            iny = -4.166667f;
            enable = false;
            transform.position = new Vector3(inx, iny, 0f);
            Point.transform.position = new Vector3(inx, iny, 0f);
            G2 = false;
            G3 = true;
            Mini2.SetActive(false);
            Mini3.SetActive(true);

        }
        if (collision.gameObject.name == "Fin3")
        {
            //PlayerCeldas.Complete_mini = true;

            //Door.GetComponent<SpriteRenderer>().sprite = door;
            win = true;
            Mini.SetActive(false);


        }

        if (collision.gameObject.name == "Fondo 1" || collision.gameObject.name == "Fondo 2" || collision.gameObject.name == "Fondo 3")
        {


            enable = false;
            StartCoroutine(Active());

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    IEnumerator Active()
    {
        yield return new WaitForSeconds(1f);
        transform.position = new Vector3(inx, iny, 0f);
        //Point.transform.position = new Vector3(inx, iny, 0f);
        Point.GetComponent<CircleCollider2D>().radius = 0.105f;
        GetComponent<CircleCollider2D>().radius = 0.105f;
    }
    IEnumerator Dr()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Está siendo arrastrado");
        Point.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

    }
}
