using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class List : MonoBehaviour
{
    public GameObject esf_N;
    public GameObject esf_P;
    public GameObject esf_D;
    public GameObject esf_T;
    public GameObject esf_H;
    public GameObject esp_G;
    public GameObject esp_H;
    public GameObject esp_E;
    public GameObject Hand;


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
        select.Add(esf_P);
        select.Add(esf_D);
        select.Add(esf_T);


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
        i = select.Count;
        if (Input.GetKeyDown(KeyCode.V))
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

        }
        if (Input.GetKeyDown(KeyCode.C))
        {

            if (index >= 0 && index <= i)
            {
                if (index <= 0) index = i;
                index--;


            }

            }
            if (select[index].name == "Hand")
            {
                Equipado.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                Equipado.GetComponent<SpriteRenderer>().sprite = select[index].GetComponent<SpriteRenderer>().sprite;
            }

        

       
        GetComponent<SpriteRenderer>().sprite = select[index].GetComponent<SpriteRenderer>().sprite;
        PlayerController.Equip = select[index].name;
        Debug.Log("Equipado: "+PlayerController.Equip);
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
    }

    public void remove(string n)
    {
        if (n == "normal") select.Remove(esf_N);
        if (n == "paraliz") select.Remove(esf_P);
        if (n == "desac") select.Remove(esf_D);
        if (n == "tranqui") select.Remove(esf_T);
        if (n == "heavy") select.Remove(esf_H);
        if (n == "ganzua") { Debug.Log("Recibido"); select.Remove(esp_G); }
        index = 0;
        Equipado.GetComponent<SpriteRenderer>().sprite = null;

    }

}
