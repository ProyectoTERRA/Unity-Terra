﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Minijuego_2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // Start is called before the first frame update
    bool touch,enable,drag;
    float distance = 20;
    float inx = 21.5f, iny = -3.5f;
    [SerializeField] private GameObject Mini;
    [SerializeField] private GameObject Jugador;
    [SerializeField] private GameObject list;

    [SerializeField] private GameObject Key_Mouse;
    void Start()
    {
        
        enable = false;
        touch = false;
        drag = false;

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
        Key_Mouse.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!enable)
        {
            drag = false;
            eventData.pointerDrag = null;
            enable = false;

            
        }
        if(drag)
        {
            Debug.Log("Está siendo arrastrado");
            transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
            transform.position = new Vector3(transform.position.x, transform.position.y, 10f);
            GetComponent<CircleCollider2D>().radius = 0.01f;
        }
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Key_Mouse.SetActive(true);
        transform.position = new Vector3(inx, iny, 10f);
        GetComponent<CircleCollider2D>().radius = 0.39f;
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
        Debug.Log(enable);
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

        if (collision.gameObject.name == "Minijuego 2-2")
        {

            enable = true;

        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Fin")
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            radial.especiales[2]--;
            GameController.ganzua--;
            string normal = "ganzua";
            if (radial.especiales[2] <= 0) list.SendMessage("remove", normal);

            PlayerSuper.Complete_mini = true;
            Jugador.GetComponent<PlayerController>().enabled = true;
            Destroy(Mini);

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Minijuego 2-2")
        {
            Key_Mouse.SetActive(true);
            transform.position = new Vector3(inx, iny, 10f);
            enable = false;
            GetComponent<CircleCollider2D>().radius = 0.39f;
        }
    }
}
