using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Minijuego_1 : MonoBehaviour
{
    [SerializeField] private Button btn_1;
    [SerializeField] private Button btn_2;
    [SerializeField] private Button btn_3;
    [SerializeField] private Button btn_4;
    [SerializeField] private Button btn_5;
    [SerializeField] private Button btn_6;

    [SerializeField] private GameObject Led_1;
    [SerializeField] private GameObject Led_2;
    [SerializeField] private GameObject Led_3;
    [SerializeField] private GameObject Led_4;
    [SerializeField] private GameObject Led_5;
    [SerializeField] private GameObject Led_6;

    [SerializeField] private GameObject Escalera;

    [SerializeField] private GameObject Interruptor;

    public Image spr;
    public Sprite On;
    public Sprite Off;

    public Sprite I_On;

    static public bool start;
    static public bool win;
    public bool fail;
    public int cont;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        win = false;
        fail = false;
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (cont >= 6)
        {
            win = true;
            btn_1.enabled = false;
            btn_2.enabled = false;
            btn_3.enabled = false;
            btn_4.enabled = false;
            btn_5.enabled = false;
            btn_6.enabled = false;

            Interruptor.GetComponent<SpriteRenderer>().sprite = I_On;

            Escalera.transform.position = new Vector3(1.0f, -2.0f);


        }

        if (fail)
        {
            fail = false;
            cont = 0;
        }

        act_LEDs();

    }

    void act_LEDs()
    {
        if (cont == 0)
        {
            spr = Led_1.GetComponent<Image>();
            spr.sprite = Off;
            spr = Led_2.GetComponent<Image>();
            spr.sprite = Off;
            spr = Led_3.GetComponent<Image>();
            spr.sprite = Off;
            spr = Led_4.GetComponent<Image>();
            spr.sprite = Off;
            spr = Led_5.GetComponent<Image>();
            spr.sprite = Off;
            spr = Led_6.GetComponent<Image>();
            spr.sprite = Off;

        }
        else if (cont == 1)
        {
            spr = Led_1.GetComponent<Image>();
            spr.sprite = On;
        }
        else if (cont == 2)
        {
            spr = Led_2.GetComponent<Image>();
            spr.sprite = On;
        }
        else if (cont == 3)
        {
            spr = Led_3.GetComponent<Image>();
            spr.sprite = On;
        }
        else if (cont == 4)
        {
            spr = Led_4.GetComponent<Image>();
            spr.sprite = On;
        }
        else if (cont == 5)
        {
            spr = Led_5.GetComponent<Image>();
            spr.sprite = On;
        }
        else if (cont == 6)
        {
            spr = Led_6.GetComponent<Image>();
            spr.sprite = On;
        }
    }

    public void btn_act1()
    {
        if (cont == 1)
        {
            cont++;
        }
        else
        {
            fail = true;
        }
    }
    public void btn_act2()
    {
        if (cont == 3)
        {
            cont++;
        }
        else
        {
            fail = true;
        }
    }
    public void btn_act3()
    {
        if (cont == 5)
        {
            cont++;
        }
        else
        {
            fail = true;
        }
    }
    public void btn_act4()
    {
        if (cont == 0)
        {
            cont++;
        }
        else
        {
            fail = true;
        }
    }
    public void btn_act5()
    {
        if (cont == 2)
        {
            cont++;
        }
        else
        {
            fail = true;
        }
    }
    public void btn_act6()
    {
        if (cont == 4)
        {
            cont++;
        }
        else
        {
            fail = true;
        }
    }

   
}
