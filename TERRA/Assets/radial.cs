using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radial : MonoBehaviour
{
    [SerializeField] private GameObject rad;
    [SerializeField] private GameObject equip;
    [SerializeField] private GameObject fab;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject herr;

    [SerializeField] private Text num_Manzana;
    [SerializeField] private Text num_Platano;
    [SerializeField] private Text num_Carton;
    [SerializeField] private Text num_Bolsa;
    [SerializeField] private Text num_Lata;
    [SerializeField] private Text num_Pila;

    [SerializeField] private Text num_Normal;
    [SerializeField] private Text num_Paralizante;
    [SerializeField] private Text num_Desactivadora;
    [SerializeField] private Text num_Tranquilizante;
    [SerializeField] private Text num_Pesada;

    [SerializeField] private Text num_CelEnergia;
    [SerializeField] private Text num_ObjCuracion;
    [SerializeField] private Text num_Ganzuas;

    [SerializeField] private Button btn_Normal;
    [SerializeField] private Button btn_Paralizante;
    [SerializeField] private Button btn_Desactivadora;
    [SerializeField] private Button btn_Tranquilizante;
    [SerializeField] private Button btn_Pesada;

    [SerializeField] private Button btn_CelEnergia;
    [SerializeField] private Button btn_ObjCuracion;
    [SerializeField] private Button btn_Ganzuas;

    [SerializeField] private Button btn_fab;

    [SerializeField] private GameObject img_fab;
    [SerializeField] private GameObject img_fab_1;
    [SerializeField] private GameObject img_fab_2;

    static public bool pl1, pl2, pl;

    static public string objFab  = "none";

    public Image req1;
    public Image req2;
    public Image req;
    public Sprite Palanca1;
    public Sprite Palanca2;

    private bool esc;
    private bool ivn;
    public int[] basura;
    public int[] esfera;
    public int[] especiales;

    public int latas_recharge;

    // Start is called before the first frame update

    void Start()
    {
        rad.SetActive(false);
        equip.SetActive(false);
        fab.SetActive(false);
        obj.SetActive(false);
        herr.SetActive(false);


        btn_fab.interactable = false;

        pl = false;
        pl1 = false;
        pl2 = false;

        esc = false;
        ivn = false;

        req1 = img_fab_1.GetComponent<Image>();
        req2 = img_fab_2.GetComponent<Image>();
        req = img_fab.GetComponent<Image>();

        req.color = Color.gray;
        req1.color = Color.gray;
        req2.color = Color.gray;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            esc = !esc;
            ivn = false;
        }
        if (!esc)
        {
            rad.SetActive(false);
            equip.SetActive(false);
            fab.SetActive(false);
            obj.SetActive(false);
            herr.SetActive(false);
        }
        else if (esc && !ivn)
        {
            rad.SetActive(true);
        }
        else if (esc && ivn)
        {
            rad.SetActive(false);
        }

        txt_Basura();
        txt_Esferas();
        txt_Especiales();

        valCraft();

        if (objFab == "Palanca")
        {
            checkPl();
        }

    }

    public void checkPl()
    {
        if (pl1)
        {
            req1.color = Color.white;
        }
        else
        {
            req1.color = Color.gray;
        }

        if (pl2)
        {
            req2.color = Color.white;
        }
        else
        {
            req2.color = Color.gray;
        }

        if (pl1 && pl2)
        {
            btn_fab.interactable = true;
        }
    }

    public void fabPl()
    {
        pl = true;
        List.select.Add(img_fab);
        req.color = Color.white;
        btn_fab.interactable = false;
        pl1 = false;
        pl2 = false;
    }

    public void txt_Basura ()
    {
        if (basura[0] < 10)
        {
            num_Pila.text = "x0" + basura[0];
        }
        else
        {
            num_Pila.text = "x" + basura[0];
        }

        if (basura[1] < 10)
        {
            num_Bolsa.text = "x0" + basura[1];
        }
        else
        {
            num_Bolsa.text = "x" + basura[1];
        }

        if (basura[2] < 10)
        {
            num_Carton.text = "x0" + basura[2];
        }
        else
        {
            num_Carton.text = "x" + basura[2];
        }

        if (basura[3] < 10)
        {
            num_Manzana.text = "x0" + basura[3];
        }
        else
        {
            num_Manzana.text = "x" + basura[3];
        }

        if (basura[4] < 10)
        {
            num_Platano.text = "x0" + basura[4];
        }
        else
        {
            num_Platano.text = "x" + basura[4];
        }

        if (basura[5] < 10)
        {
            num_Lata.text = "x0" + basura[5];
        }
        else
        {
            num_Lata.text = "x" + basura[5];
        }
    }

    public void txt_Esferas()
    {
        if (esfera[0] < 10)
        {
            num_Normal.text = "x0" + esfera[0];
        }
        else
        {
            num_Normal.text = "x" + esfera[0];
        }

        if (esfera[1] < 10)
        {
            num_Paralizante.text = "x0" + esfera[1];
        }
        else
        {
            num_Paralizante.text = "x" + esfera[1];
        }

        if (esfera[2] < 10)
        {
            num_Desactivadora.text = "x0" + esfera[2];
        }
        else
        {
            num_Desactivadora.text = "x" + esfera[2];
        }

        if (esfera[3] < 10)
        {
            num_Tranquilizante.text = "x0" + esfera[3];
        }
        else
        {
            num_Tranquilizante.text = "x" + esfera[3];
        }

        if (esfera[4] < 10)
        {
            num_Pesada.text = "x0" + esfera[4];
        }
        else
        {
            num_Pesada.text = "x" + esfera[4];
        }


    }

    public void txt_Especiales()
    {
        if (especiales[0] < 10)
        {
            num_CelEnergia.text = "x0" + especiales[0];
        }
        else
        {
            num_CelEnergia.text = "x" + especiales[0];
        }

        if (especiales[1] < 10)
        {
            num_ObjCuracion.text = "x0" + especiales[1];
        }
        else
        {
            num_ObjCuracion.text = "x" + especiales[1];
        }

        if (especiales[2] < 10)
        {
            num_Ganzuas.text = "x0" + especiales[2];
        }
        else
        {
            num_Ganzuas.text = "x" + especiales[2];
        }

    }

    //-----------------------EQUIP---------------------------

    public void radial_equipo()
    {
        ivn = !ivn;
        equip.SetActive(true);
    }

    public void equipo_radial()
    {
        ivn = !ivn;
        equip.SetActive(false);
    }
//-----------------------OBJ---------------------------
    public void radial_objetos()
    {
        ivn = !ivn;
        obj.SetActive(true);
    }

    public void objetos_radial()
    {
        ivn = !ivn;
        obj.SetActive(false);
    }

 //-----------------------HERR---------------------------

    public void radial_herramientas()
    {
        ivn = !ivn;
        herr.SetActive(true);
    }

    public void herramientas_radial()
    {
        ivn = !ivn;
        herr.SetActive(false);
    }

//-----------------------FAB---------------------------
    public void radial_fabricacion()
    {
        ivn = !ivn;
        fab.SetActive(true);
    }

    public void fabricacion_radial()
    {
        ivn = !ivn;
        fab.SetActive(false);
    }

    public void valCraft()
    {
        if (basura[5] < 3)
        {
            btn_Normal.interactable = false;
        }
        else
        {
            btn_Normal.interactable = true;
        }

        if (basura[1] < 2 || basura[3] < 1) 
        {
            btn_Paralizante.interactable = false;
        }
        else
        {
            btn_Paralizante.interactable = true;
        }

        if (basura[5] < 2 || basura[0] < 2)
        {
            btn_Desactivadora.interactable = false;
        }
        else
        {
            btn_Desactivadora.interactable = true;
        }

        if (basura[5] < 2 || basura[4] < 2 || basura[2] < 1)
        {
            btn_Tranquilizante.interactable = false;
        }
        else
        {
            btn_Tranquilizante.interactable = true;
        }

        if (latas_recharge < 5)
        {
            btn_Pesada.interactable = false;
        }
        else
        {
            btn_Pesada.interactable = true;
        }

        if (basura[0] < 1 || basura[5] < 1 || basura[4] < 1)
        {
            btn_CelEnergia.interactable = false;
        }
        else
        {
            btn_CelEnergia.interactable = true;
        }

        if (basura[3] < 3 || basura[4] < 1 || basura[2] < 1)
        {
            btn_ObjCuracion.interactable = false;
        }
        else
        {
            btn_ObjCuracion.interactable = true;
        }

        if (basura[5] < 2)
        {
            btn_Ganzuas.interactable = false;
        }
        else
        {
            btn_Ganzuas.interactable = true;
        }
    }

//-----------------------Fabricación de esferas---------------------------

    public void Fab_Nl()
    {
        basura[5] = basura[5] - 3;
        esfera[0]++;
    }

    public void Fab_Pl()
    {
        basura[1] = basura[1] - 2;
        basura[3] = basura[3] - 1;
        esfera[1]++;
    }

    public void Fab_Dc()
    {
        basura[5] = basura[5] - 2;
        basura[0] = basura[0] - 2;
        esfera[2]++;
    }

    public void Fab_Tl()
    {
        basura[5] = basura[5] - 2;
        basura[4] = basura[4] - 2;
        basura[2] = basura[2] - 1;
        esfera[3]++;
    }

    public void Fab_Pd()
    {
        latas_recharge = latas_recharge - 5;
        esfera[5]++;
    }

    //-----------------------Fabricación de especiales---------------------------

    public void Fab_CE()
    {
        basura[0] = basura[0] - 1;
        basura[4] = basura[4] - 1;
        basura[5] = basura[5] - 1;
        especiales[0]++;
    }

    public void Fab_OC()
    {
        basura[3] = basura[3] - 3;
        basura[4] = basura[4] - 1;
        basura[2] = basura[2] - 1;
        especiales[1]++;
    }

    public void Fab_GN()
    {
 
        basura[5] = basura[5] - 2;
        especiales[2]++;
    }
}

