using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class List : MonoBehaviour
{
    public GameObject Recogedor;
    public GameObject esf_N;
    public GameObject esf_P;
    public GameObject esf_D;
    public GameObject esf_T;
    public GameObject esf_H;
    public GameObject esp_G;
    public GameObject esp_H;
    public GameObject esp_E;
    public GameObject Hand;

    public Text Count;

    public GameObject Equipado;

    public List<string> hrr;

    public static List<GameObject> select;
    public static int index;
    public int i;


    // Start is called before the first frame update
    void Start()
    {
        index = 0;

        select = new List<GameObject>();

        
        select.Add(Hand);
        select.Add(Recogedor);
        select.Add(esf_P);
        select.Add(esf_D);
        select.Add(esf_T);
        

        //132

        /*----- PRUEBAS --------         
        select.Add(esf_N);
        select.Add(esf_H);

        select.Add(esp_E);
        select.Add(esp_H);
        select.Add(esp_G);
        */


        if (GameController.ganzua > 0)
        {
            select.Add(esp_G);
        }
        if (GameController.normal > 0)
        {
            select.Add(esf_N);
        }
        if (GameController.energia > 0)
        {
            select.Add(esp_E);
        }




        hrr = new List<string>();
        hrr.Add("esf_N");
        hrr.Add("esf_P");
        hrr.Add("esf_D");
        hrr.Add("esf_T");
        hrr.Add("esf_H");

        PlayerController.Equip = hrr[0];
        Debug.Log(PlayerController.Equip);

        GetComponent<SpriteRenderer>().sprite = Resources.Load("Esferas_0", typeof(Sprite)) as Sprite;
        if (select[index].name == "Hand")
        {
            Equipado.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Equipado.GetComponent<SpriteRenderer>().sprite = select[index].GetComponent<SpriteRenderer>().sprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (select[index].name == "Hand")
        {
            Equipado.GetComponent<SpriteRenderer>().sprite = null;
        }
        i = select.Count;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index >= 0 && index <= i)
            {
                index++;
                if (index >= i) index = 0;
            }

            if (select[index].name == "Hand")
            {
                Equipado.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                Equipado.GetComponent<SpriteRenderer>().sprite = select[index].GetComponent<SpriteRenderer>().sprite;
            }

            if(select[index].name == "Recogedor")
            {
                Equipado.transform.rotation = Quaternion.Euler(0f, 0f,PlayerController.side *132f);
            }
            else
            {
                Equipado.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (index >= 0 && index <= i)
            {
                if (index <= 0) index = i;
                index--;


            }
            if (select[index].name == "Hand")
            {
                Equipado.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                Equipado.GetComponent<SpriteRenderer>().sprite = select[index].GetComponent<SpriteRenderer>().sprite;
            }
            if (select[index].name == "Recogedor")
            {
                Equipado.transform.rotation = Quaternion.Euler(0f, 0f, PlayerController.side * 132f);
            }
            else
            {
                Equipado.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

        }
           



        GetComponent<SpriteRenderer>().sprite = select[index].GetComponent<SpriteRenderer>().sprite;
        PlayerController.Equip = select[index].name;
        //Debug.Log("Equipado: "+PlayerController.Equip);



        if (PlayerController.Equip == "Esfera Normal")
        {
            Count.text = radial.n_Normal;
            Count.enabled = true;
            
        }
        else if (PlayerController.Equip == "Esfera Paraliz")
        {
            Count.text = radial.n_Paraliz;
            Count.enabled = true;
        }
        else if (PlayerController.Equip == "Esfera Tranqui")
        {
            Count.text = radial.n_Tranqui;
            Count.enabled = true;
        }
        else if (PlayerController.Equip == "Esfera Desac")
        {
            Count.text = radial.n_Desac;
            Count.enabled = true;
        }
        else if (PlayerController.Equip == "Esfera Pesada")
        {
            Count.text = radial.n_Pesada;
            Count.enabled = true;
        }
        else if (PlayerController.Equip == "Especiales_0")
        {
            Count.text = radial.n_Energy;
            Count.enabled = true;
        }
        else if (PlayerController.Equip == "Especiales_1")
        {
            Count.text = radial.n_Health;
            Count.enabled = true;
        }
        else if (PlayerController.Equip == "Especiales_2" || PlayerController.Equip == "Ganzua")
        {
            Count.text = radial.n_Ganzua;
            Count.enabled = true;
        }
        else
        {
            Count.enabled = false;
        }
    }

    public void add(string n)
    {
        Debug.Log("Recibido");
        if (n == "normal") select.Add(esf_N);
        if (n == "paraliz") select.Add(esf_P);
        if (n == "desac") select.Add(esf_D);
        if (n == "tranqui") select.Add(esf_T);
        if (n == "heavy") select.Add(esf_H);
        if (n == "ganzua") { Debug.Log("Recibido"); select.Add(esp_G); }
        if (n == "health") { Debug.Log("Recibido"); select.Add(esp_H); }
        if (n == "energy") { Debug.Log("Recibido"); select.Add(esp_E); }
    }

    public void remove(string n)
    {
        if (n == "normal") select.Remove(esf_N);
        if (n == "paraliz") select.Remove(esf_P);
        if (n == "desac") select.Remove(esf_D);
        if (n == "tranqui") select.Remove(esf_T);
        if (n == "heavy") select.Remove(esf_H);
        if (n == "ganzua") { Debug.Log("Recibido"); select.Remove(esp_G); }
        if (n == "health") { Debug.Log("Recibido"); select.Remove(esp_H); }
        if (n == "energy") { Debug.Log("Recibido"); select.Remove(esp_E); }
        index = 0;
        Equipado.GetComponent<SpriteRenderer>().sprite = null;

    }

}
