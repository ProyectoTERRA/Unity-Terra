using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CargarPartida : MonoBehaviour
{

    private String rutaArchivo = Application.persistentDataPath + "/datos.dat";
    // Start is called before the first frame update
    void Start()
    {
        EstadoJuego datosCargados = GameObject.Find("Guardar").GetComponent<EstadoJuego>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    
    
}
