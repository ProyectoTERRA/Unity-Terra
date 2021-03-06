﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCasaReturn : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    [SerializeField] private GameObject Linterna;

    [SerializeField] private GameObject FOOD;

    [SerializeField] private GameObject OBJ_LATA1;
    [SerializeField] private GameObject OBJ_LATA2;
    [SerializeField] private GameObject OBJ_AWA;


    [SerializeField] private GameObject Key_DoorSalaLucy;

    [SerializeField] private GameObject Key_Lucy;
    [SerializeField] private GameObject Key_Food;

    public bool lucy;

    private Image spr;
    public Sprite Flashlight;

    private bool Food;

    // Start is called before the first frame update
    void Start()
    {
        FOOD.SetActive(false);
        Food = false;
     
        //Heart_Bar.Phearts = 6;

        Key_DoorSalaLucy.SetActive(false);


        lucy = false;


    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "PuertaLucy" && Food)//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado la puerta3");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla e");
                transform.position = new Vector3(16.8f, 0.5f);
                transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

                camera.transform.position = new Vector3(18.0f, 3.0f, -10.0f);
                camera.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }


        if (collision.gameObject.tag == "Lucy")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado a Lucy");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla e");
                lucy = true;
                Key_Lucy.SetActive(false);
            }
        }

        if (collision.gameObject.name == "DejarFood")//compara si hizo la colision con el objeto correcto
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                OBJ_LATA1.SetActive(false);
                OBJ_LATA2.SetActive(false);
                OBJ_AWA.SetActive(false);
                FOOD.SetActive(true);
                Food = true;
                Key_DoorSalaLucy.SetActive(true);
                Key_Food.SetActive(false);
            }
        }



    }
}
