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

    private bool esc;
    private bool ivn;
    // Start is called before the first frame update

    void Start()
    {
        rad.SetActive(false);
        equip.SetActive(false);
        fab.SetActive(false);
        obj.SetActive(false);
        herr.SetActive(false);

        esc = false;
        ivn = false;

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

}
