using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class EstadoJuego : MonoBehaviour
{

    public string nombrePartida="nada";
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);

        nombrePartida = "kaa";

        bf.Serialize(file, nombrePartida);

        file.Close();
    }
}
