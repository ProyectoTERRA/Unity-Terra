using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getText : MonoBehaviour
{

    public InputField nombre;
    public Text setNombre;
    public void setGet()
    {
        
        setNombre.text ="Nombre: "+nombre.text;
        Debug.Log(nombre+"        "+nombre.text);
    }
}
