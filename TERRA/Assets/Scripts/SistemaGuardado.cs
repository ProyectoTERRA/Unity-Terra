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
    int contador=1;
    List<string> listaPartidas = new List<string>();
    InputField name;

    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            guardarContador();
        }
        guardaAutomatico = Input.GetKeyDown(KeyCode.Space);
        
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

        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
        Debug.Log("se creo"+ name.text);
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
        }
        else { Debug.Log("No se encontro el archivo"); }
    }

    public void borrar()
    {
        if(File.Exists(Application.persistentDataPath + "/" + nombrePartida + ".d"))
        {
            File.Delete(Application.persistentDataPath + "/" + nombrePartida + ".d");
        }
        else
        {
            Debug.Log("No hay para borrar");
        }
    }

    public void get()
    {
        if (File.Exists(Application.persistentDataPath + "/contandoPartida.d"))
        {
            BinaryFormatter bf = new BinaryFormatter(); //Ayudante
            FileStream expediente = File.OpenRead(Application.persistentDataPath + "/contandoPartida.d");//Crea archivo datos.d
            DatosPartidas dato = new DatosPartidas(); //Dato es la variable de la clase que se serializa

            dato = bf.Deserialize(expediente) as DatosPartidas;

            contador = dato.contador;
            
            Debug.Log("Linea 100 dato.contador: " + dato.contador);
            
            name = GameObject.Find("InputField").GetComponent<InputField>();
            if(contador == 1)
            {
                listaPartidas.Add(name.text);
                nombrePartida = name.text;
                Debug.Log("Partida 1");
                contador += 1;
                guardar();
            }
            else if(contador == 2)
            {
                listaPartidas.Add(name.text);
                nombrePartida = name.text;
                Debug.Log("Partida 2");
                contador += 1;
                guardar();
            }
            else if(contador == 3)
            {
                listaPartidas.Add(name.text);
                nombrePartida = name.text;
                Debug.Log("Partida 3");
                contador += 1;
                guardar();
            }              
            else if(contador == 4)
            {
                Debug.Log("No se pueden crear mas de 3 partidas");
            }
            dato.nombre = listaPartidas;
            dato.contador = contador;
            expediente.Close();
            Debug.Log("Linea 137 dato.contador: " + dato.contador);
            foreach (string color in dato.nombre)
            {
                Debug.Log("Guardado en partida" + color);
            }
            guardarContador();            
        }
    }

    public void guardarContador()
    {
        BinaryFormatter bf = new BinaryFormatter(); //Ayudante
        FileStream expediente = File.Create(Application.persistentDataPath + "/contandoPartida.d");//Crea archivo datos.d
        DatosPartidas dato = new DatosPartidas(); //Daro es la variable de la clase que se serializa

        //Variables a guardar 

        dato.nombre = listaPartidas;
        dato.contador = contador;
        Debug.Log("Linea 150 dato.contador " + dato.contador);
        Debug.Log("Linea 150 contador " + contador);
        //Serializara los archivos
        bf.Serialize(expediente, dato);
        expediente.Close();
        Debug.Log("se creo arhivo contador partida");
    }
}

[Serializable()]//Datos listos para serializar
class DatosJuego:System.Object
{
    public String nombrePartida;
    public int basura;
}

[Serializable()]
class DatosPartidas:System.Object
{
    public List<string> nombre;
    public int contador;
}
