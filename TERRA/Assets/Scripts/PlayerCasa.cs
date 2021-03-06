﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCasa : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    [SerializeField] private GameObject Linterna;

    [SerializeField] private GameObject Key_DoorPlayer;
    [SerializeField] private GameObject Key_DoorLucySala;
    [SerializeField] private GameObject Key_DoorSalaLucy;
    [SerializeField] private GameObject Key_DoorCalle;

    [SerializeField] private GameObject Key_Lucy;
    [SerializeField] private GameObject Key_Linterna;


    private Image spr;
    public Sprite Flashlight;

    public bool lucy;
    public bool linterna;
    private int basuraL, basuraP, basuraC, basuraM;

    private bool agarrar, trash, CRoom1, CRoom2;
    private string nombre, tag;

    // Start is called before the first frame update
    void Start()
    {
        CRoom1 = false;
        CRoom2 = false;
        trash = false;
        Heart_Bar.Phearts = 6;

        Key_DoorPlayer.SetActive(false);
        Key_DoorLucySala.SetActive(false);
        Key_DoorCalle.SetActive(false);

        camera.transform.position = new Vector3(0.0f, 3.0f, -10.0f);
        camera.transform.localScale = new Vector3(1f, 1f, 1f);

        transform.position = new Vector3(-6.4f, 0.5f);
        transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

        basuraL = 0;
        basuraP = 0;
        basuraC = 0;
        basuraM = 0;

        lucy = false;
        linterna = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (basuraL >= 4 && basuraC >=2 && basuraP >= 2 && basuraM >=1 )
        {
            Key_DoorPlayer.SetActive(true);
            trash = true;
        }
        if (agarrar)
        {
            GameObject go = GameObject.Find("InvFunc");
            radial radial = go.GetComponent<radial>();
            if (tag == "LataFAKE")
            {

                //GameController.lata++;
                radial.basura[5]++;
                Destroy(GameObject.Find(nombre));
                basuraL++;

            }
            else if (tag == "CartonFAKE")
            {
                //GameController.carton++;
                radial.basura[2]++;
                Destroy(GameObject.Find(nombre));
                basuraC++;
            }
            else if (tag == "PlatanoFAKE")
            {
                //GameController.platano++;
                radial.basura[4]++;
                Destroy(GameObject.Find(nombre));
                basuraP++;
            }
            else if (tag == "ManzanaFAKE")
            {
                //GameController.manzana++;
                radial.basura[3]++;
                Destroy(GameObject.Find(nombre));
                basuraM++;
            }
            agarrar = false;
        }
        if (CRoom1)
        {
            transform.position = new Vector3(16.8f, 0.5f);
            transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

            camera.transform.position = new Vector3(18.0f, 3.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);
            CRoom1 = false;
        }
        if (CRoom2)
        {
            transform.position = new Vector3(30.6f, 0.5f);
            transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);

            camera.transform.position = new Vector3(36.0f, 3.0f, -10.0f);
            camera.transform.localScale = new Vector3(1f, 1f, 1f);
            CRoom2 = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LataFAKE" && PlayerController.Equip == "Recogedor")
        {

            tag = collision.gameObject.tag;
            nombre = collision.gameObject.name;
            agarrar = true;
        }
        if (collision.gameObject.tag == "PlatanoFAKE" && PlayerController.Equip == "Recogedor")
        {

            tag = collision.gameObject.tag;
            nombre = collision.gameObject.name;
            agarrar = true;
        }
        if (collision.gameObject.tag == "CartonFAKE" && PlayerController.Equip == "Recogedor")
        {

            tag = collision.gameObject.tag;
            nombre = collision.gameObject.name;
            agarrar = true;
        }

        if (collision.gameObject.tag == "ManzanaFAKE" && PlayerController.Equip == "Recogedor")
        {

            tag = collision.gameObject.tag;
            nombre = collision.gameObject.name;
            agarrar = true;
        }
        if (collision.gameObject.tag == "PuertaLucy" && trash)//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado la puerta3");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla e");
                CRoom1 = true;
            }
        }

        if (collision.gameObject.tag == "PuertaSala")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado la puerta3");
            if (Input.GetKeyDown(KeyCode.E) && lucy)
            {
                Debug.Log("Tecla e");
                CRoom2 = true;
            }
        }

        if (collision.gameObject.tag == "Lucy")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado a Lucy");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Tecla e");
                lucy = true;
                Key_DoorLucySala.SetActive(true);
                Key_Lucy.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "PuertaCalle")//compara si hizo la colision con el objeto correcto
        {

            if (Input.GetKeyDown(KeyCode.E) && linterna)
            {
                GameObject go = GameObject.Find("InvFunc");
                radial radial = go.GetComponent<radial>();
                GameController.pila = radial.basura[0];
                GameController.bolsa = radial.basura[1];
                GameController.carton = radial.basura[2];
                GameController.manzana = radial.basura[3];
                GameController.platano = radial.basura[4];
                GameController.lata = radial.basura[5];

                GameController.normal = radial.esfera[0];
                GameController.paralizante = radial.esfera[1];
                GameController.desactivadora = radial.esfera[2];
                GameController.tranquilizante = radial.esfera[3];
                GameController.pesada = radial.esfera[4];

                GameController.energia = radial.especiales[0];
                GameController.curacion = radial.especiales[1];
                GameController.ganzua = radial.especiales[2];
                Debug.Log("Salido");
                SceneManager.LoadScene("Calle");
            }
        }

        if (collision.gameObject.tag == "linterna")//compara si hizo la colision con el objeto correcto
        {
            Debug.Log("Has tocado a LINTERNA");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Linterna.SetActive(true);

                spr = Linterna.GetComponent<Image>();
                spr.sprite = Flashlight;
                Debug.Log("Has agarrado la linterna");
                linterna = true;
                Destroy(GameObject.Find("linterna"));
                Key_DoorCalle.SetActive(true);
                GameController.linterna = true;
                Key_Linterna.SetActive(false);
            }
        }



    }
}
