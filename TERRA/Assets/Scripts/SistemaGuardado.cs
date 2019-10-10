using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SistemaGuardado : MonoBehaviour
{

    public String nombrePartida = "";
    public String buscarNombre = "", prueba;
    bool cargarInicio;
    public int basura;
    bool guardaAutomatico;
    // Start is called before the first frame update
    void Start()
    {
        guardaAutomatico = Input.GetKeyDown(KeyCode.Space);
        Debug.Log(Application.persistentDataPath);
        Debug.Log("Hola");
        if(cargarInicio)
        {
            cargar();
        }
        if (guardaAutomatico)
        {
            guardar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButton("btnAceptar"))
        {

        }*/
    }

    public void guardar()
    {
        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/" + nombrePartida + ".d");//Crea archivo datos.d
        DatosJuego dato = new DatosJuego(); //Daro es la variable de la clase que se serializa

        //Variables a guardar
        dato.nombrePartida = nombrePartida;
        dato.basura = 4;
        //Serializara los arrchivos
        bf.Serialize(expediente, dato);
        expediente.Close();

        Debug.Log("COOL");
    }

    public void cargar()
    {
        if(File.Exists(Application.persistentDataPath+"/"+buscarNombre+".d"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/" + buscarNombre + ".d");
            DatosJuego datos = new DatosJuego();

            datos = bf.Deserialize(expediente) as DatosJuego;

            prueba = datos.nombrePartida;
            basura = datos.basura;

            Debug.Log("COOL");
        }
        else { Debug.Log("No se encontro el archivo"); }
    }

    public void get(InputField name)
    {
        nombrePartida = name.text;
        guardar();
    }

}

[Serializable()]//Datos listos para serializar

class DatosJuego:System.Object
{
    public String nombrePartida;
    public int basura;
}
