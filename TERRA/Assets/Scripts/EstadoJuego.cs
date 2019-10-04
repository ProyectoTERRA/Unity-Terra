using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine.UI;

public class EstadoJuego : MonoBehaviour
{
    public InputField nombre;
    public Text setNombre;
    public string nombrePartida="", nuevoNombre="";
    private string rutaArchivo;

    public static EstadoJuego estadoJuego;


    void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/datos.dat";
        if(estadoJuego==null)
        {
            estadoJuego = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(estadoJuego != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        guardar();
        Cargar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);

        getName();

        DatosGuardados datos = new DatosGuardados();
        datos.nombre = nombrePartida;

        bf.Serialize(file, nombrePartida);

        file.Close();
    }

    public void getName()
    {
        nombrePartida = nombre.text;
    }

    void Cargar()
    {
        if(File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);

            DatosGuardados datos = (DatosGuardados)bf.Deserialize(file);

            nuevoNombre = datos.nombre;

            setNombre.text = nuevoNombre;

            file.Close();
        }
        else
        {
            setNombre.text = "No funciono";
        }
        
    }

    [Serializable]
    class DatosGuardados
    {
        public String nombre;
    }

}
